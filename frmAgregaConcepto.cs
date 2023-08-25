using System;
using System.Data;
using System.Windows.Forms;

namespace VitalLabSoft
{
    public partial class frmAgregaConcepto : Form
    {
        int tipo = 0; // 
        int percepcion = 1;
        int idEmpleado;
        int idPeriodo;
        DataTable dtConceptos;
        public frmAgregaConcepto(int tipo, int idEmpleado, int periodo)
        {
            InitializeComponent();
            this.tipo = tipo;
            this.idEmpleado = idEmpleado;
            this.idPeriodo = periodo;
            if (tipo == 1)
            {
                cbConceptoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else
            {
                cbConceptoPago.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }
        private void frmAgregaConcepto_Load(object sender, EventArgs e)
        {
            ActualizaComboConceptos();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbPercepcion_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPercepcion.Checked)
            {
                this.percepcion = 1;
            }
            else
            {
                this.percepcion = 0;
            }
            ActualizaComboConceptos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.tipo == 1)
            {
                if (ExtraerDato.AccionQuery("insert into conceptosempleados (idEmpleado, fijo, Concepto, pago, percepcion, pagado, idConcepto) values (" + this.idEmpleado + ", 1, '" + cbConceptoPago.Text.Trim().ToUpper() + "', " + nPago.Value + ", " + this.percepcion + ", 0, " + this.dtConceptos.Rows[cbConceptoPago.SelectedIndex][0].ToString() + ")"))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar guardar el conceto. Si el problema persiste, contacte al administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (ExtraerDato.AccionQuery("insert into conceptosempleados (idEmpleado, fijo, idPeriodo, Concepto, pago, percepcion, pagado) values (" + this.idEmpleado + ", 0, " + this.idPeriodo + ", '" + cbConceptoPago.Text.Trim().ToUpper() + "', " + nPago.Value + ", " + this.percepcion + ", 0)"))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar guardar el conceto. Si el problema persiste, contacte al administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void cbConceptoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                nPago.Value = decimal.Parse(cbConceptoPago.SelectedValue.ToString());
            }
            catch { }
        }
        private void ActualizaComboConceptos()
        {
            try
            {
                this.dtConceptos = ExtraerDato.listadoDatos("select idConcepto, Concepto, Pago from ConceptosAdicionales where percepcion = " + this.percepcion + " order by concepto");
                cbConceptoPago.DataSource = dtConceptos;
                cbConceptoPago.DisplayMember = "Concepto";
                cbConceptoPago.ValueMember = "Pago";
                nPago.Value = decimal.Parse(cbConceptoPago.SelectedValue.ToString());
            }
            catch { }
        }
    }
}