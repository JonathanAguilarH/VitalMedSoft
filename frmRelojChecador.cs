using AxZKFPEngXControl;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace VitalLabSoft
{
    public partial class frmRelojChecador : Form
    {
        private int iDelay = 0;
        private bool borrar = false;
        private AxZKFPEngX ZkFprint = new AxZKFPEngX();
        DataTable dtHuellas;
        string template = "";
        bool preparado = false;
        bool calidad = false;
        bool esperando = false;
        string idActual = "0";
        public frmRelojChecador()
        {
            InitializeComponent();
        }
        private void frmRelojChecador_Load(object sender, EventArgs e)
        {
            Controls.Add(ZkFprint);
            pbHuella.Visible = false;
            PanelRelojChecador.Visible = false;
            InicializaReloj();
            pbHuella.Visible = true;
            this.preparado = true;
            try { ZkFprint.CancelEnroll(); } catch { }
            PreparaLector();
            activaEsperando();
            PanelRelojChecador.Visible = true;
        }
        private void reloj_Tick(object sender, EventArgs e)
        {
            this.lHora.Text = DateTime.Now.ToLongTimeString();
            if ((this.iDelay >= 1) & this.borrar)
            {
                this.iDelay = 0;
                this.borrar = false;
                Thread.Sleep(1500);
            }
            else
            {
                this.iDelay++;
            }
        }
        private void InicializaReloj()
        {
            DateTime now = DateTime.Now;
            this.reloj.Enabled = true;
            this.lHora.Text = DateTime.Now.ToLongTimeString();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PreparaLector()
        {
            try
            {
                ZkFprint.OnImageReceived += zkFprint_OnImageReceived;
                ZkFprint.OnFeatureInfo += zkFprint_OnFeatureInfo;
                ZkFprint.OnEnroll += zkFprint_OnEnroll;
                if (ZkFprint.InitEngine() == 0)
                {
                    ZkFprint.FPEngineVersion = "9";
                    ZkFprint.EnrollCount = 3;
                    lblInfoLector.Text = "Dispositivo detectado";
                    this.preparado = true;
                }
            }
            catch (Exception ex)
            {
                this.preparado = false;
                lblInfoLector.Text = "Error al inicializar.";
                MessageBox.Show("Error al inicializar el lector de huella. Error: " + ex.Message);
            }
        }
        private void zkFprint_OnImageReceived(object sender, IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            if (this.preparado & pbHuella.Visible & this.esperando)
            {
                Graphics g = pbHuella.CreateGraphics();
                Bitmap bmp = new Bitmap(pbHuella.Width, pbHuella.Height);
                g = Graphics.FromImage(bmp);
                int dc = g.GetHdc().ToInt32();
                ZkFprint.PrintImageAt(dc, 0, 0, bmp.Width, bmp.Height);
                g.Dispose();
                pbHuella.Image = bmp;
            }
        }
        private void zkFprint_OnFeatureInfo(object sender, IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            if (this.preparado & pbHuella.Visible & this.esperando)
            {
                String strTemp = string.Empty;
                if (ZkFprint.LastQuality > 85)
                {
                    this.calidad = true;
                    lblInfoLector.Text = "Calidad de imagen: " + ZkFprint.LastQuality;
                    activaEsperando();
                }
                else
                {
                    this.calidad = false;
                    lblInfoLector.Text = "Calidad insuficiente. Intente de nuevo";
                }
            }
        }
        private void zkFprint_OnEnroll(object sender, IZKFPEngXEvents_OnEnrollEvent e)
        {
            if (e.actionResult & this.esperando & this.calidad)
            {
                this.template = ZkFprint.EncodeTemplate1(e.aTemplate);
                if (this.template != "")
                {
                    if (buscarHuella())
                    {
                        lblInfoLector.Text = "Se ha registrado una nueva entrada";
                    }
                    else
                    {
                        lblInfoLector.Text = "No se encontró coincidencia";
                    }
                }
            }
        }
        private void activaEsperando()
        {
            this.esperando = true;
            ZkFprint.CancelEnroll();
            ZkFprint.EnrollCount = 1;
            ZkFprint.BeginEnroll();
        }
        private bool buscarHuella()
        {
            bool encontrado = false;
            this.dtHuellas = new DataTable();
            try
            {
                this.dtHuellas = ExtraerDato.listadoDatos("SELECT idEmpleado, Codigo, Imagen, Nombres + ' ' + ApellidoP + ' ' + ApellidoM as nombre, Titulo, Puesto, HuellaTemplateTexto FROM Empleados where activo = 1");
                foreach (DataRow fila in dtHuellas.Rows)
                {
                    if (ZkFprint.VerFingerFromStr(ref template, fila[6].ToString().Trim(), false, ref encontrado))
                    {
                        encontrado = ExtraerDato.AccionQuery("insert into asistencias (idEmpleado, fechaHora, fechaHoraServidor) values (" + fila[0].ToString() + ", '" + Program.FormateoFechaHora(DateTime.Now) + "', getDate())");
                        llenarCampos(fila);
                        break;
                    }
                }
            }
            catch { }
            return encontrado;
        }
        private void llenarCampos(DataRow fila)
        {
            this.idActual = fila[0].ToString();
            byte[] data = (byte[])fila[2];
            MemoryStream ms = new MemoryStream(data);
            pbEmpleado.Image = Image.FromStream(ms);
            lblNombre.Text = fila[3].ToString().Trim();
            lblTitulo.Text = fila[4].ToString().Trim();
            lblPuesto.Text = fila[5].ToString().Trim();
            lblFaltas.Visible = false;
            lblRetardos.Visible = false;
            calculaAsistencias(idActual);
        }
    private void calculaAsistencias(string idEmpleado)
        {
            DataTable infoEmpleado = ExtraerDato.listadoDatos("select tipoNomina, entrada from configuracionesAdicionales inner join turnos on turnoPreferido = idTurno where idEmpleado = " + idEmpleado);
            string idPeriodo = ExtraerDato.Cadena("select idPeriodo from periodos where fechaInicio < '" + Program.FormateoFecha(DateTime.Now) + "' and fechaFin > '" + Program.FormateoFecha(DateTime.Now) + "' and tipo = " + infoEmpleado.Rows[0][0].ToString());
            // Calcula faltas y retardos
            int faltas = 0;
            int retardos = 0;
            DateTime dtInicio = ExtraerDato.Fecha("select fechainicio from periodos where idPeriodo = " + idPeriodo);
            DateTime dtFin = DateTime.Today;
            do
            {
                DateTime dtPrimerRegistro = ExtraerDato.Fecha("select top(1) fechaHora from asistencias where fechaHora <= '" + Program.FormateoFechaHora(dtInicio.AddDays(1).AddMilliseconds(-1)) + "' and fechaHora >= '" + Program.FormateoFechaHora(dtInicio) + "' and idEmpleado = " + idEmpleado);
                if (dtPrimerRegistro != Convert.ToDateTime("01/01/1900"))
                {
                    TimeSpan Entrada = (TimeSpan)infoEmpleado.Rows[0][1];
                    int retardoDia = (int)Math.Round(dtPrimerRegistro.TimeOfDay.TotalMinutes) - (int)Math.Round(Entrada.TotalMinutes);
                    if (retardoDia > 0)
                    {
                        retardos = retardos + retardoDia;
                    }
                }
                else
                {
                    if (dtInicio.DayOfWeek != 0)
                    {
                        faltas++;
                    }
                }
                dtInicio = dtInicio.AddDays(1);
            } while (dtFin >= dtInicio);
            lblFaltas.Text = "FALTAS: " + faltas.ToString() + " día(s)";
            lblRetardos.Text = "RETARDOS: " + retardos.ToString() + " minutos";
            lblFaltas.Visible = true;
            lblRetardos.Visible = true;
        }
    }
}