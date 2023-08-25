using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VitalLabSoft
{
    public partial class frmSucursales: Form
    {
        public frmSucursales()
        {
            InitializeComponent();
        }
        private void frmSucursales_Load(object sender, EventArgs e)
        {
            cargaGrid();
        }

        private void cargaGrid()
        {
            DataTable dtBusqueda = ExtraerDato.listadoDatos("select idSucursal, NOMBRE as 'NOMBRE DE SUCURSAL', imagen, Direccion as 'DIRECCIÓN', telefono as 'TELÉFONO', RFC, dns, puerto, usuario, pass, remotoActivo as 'CONEXIÓN REMOTA' from sucursales order by nombre");
            infoGridSucursales.DataSource = dtBusqueda;
            infoGridSucursales.Columns[0].Visible = false;
            infoGridSucursales.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            infoGridSucursales.Columns[2].Visible = false;
            infoGridSucursales.Columns[3].Visible = false;
            infoGridSucursales.Columns[4].Visible = false;
            infoGridSucursales.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            infoGridSucursales.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            infoGridSucursales.Columns[7].DefaultCellStyle.Format = "C";
            infoGridSucursales.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            infoGridSucursales.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            infoGridSucursales.Columns[8].Visible = false;
            PintaGrid(infoGridSucursales);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Realmente desea eliminar esta sucursal? Esta operación no se puede deshacer.", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Eliminar
            }
        }

        private void PintaGrid(DataGridView _infoGridSucursales)
        {

        }

        private void pbLogoSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                //Abrir.FileName = "";
                //Abrir.Multiselect = true;
                //Abrir.Filter = "Archivos de imágen |*.jpg;*.jpeg;*.png";
                //Abrir.ShowDialog();
                //bool Carga = true;
                //string rutaReal = Abrir.FileName;
                //int i = -1;
                //if (this.serieOT == "OPR")
                //{
                //    foreach (var item in Abrir.FileNames)
                //    {
                //        i++;
                //        rutaReal = item;
                //        if (rutaReal != "")
                //        {
                //            pictureBox2.Image = ExtraeDato.redimensionar(rutaReal, false);
                //            try
                //            {
                //                if (0 != (this.index = int.Parse(ExtraeDato.Cadena("select idImagen from imagenIncidencia where candado = '" + candado + "' and idIncidencia = " + this.idincidencia + " and imageninicial = 1 and nombreArchivo = '" + Abrir.FileNames[i].Replace("'", "") + "'"))))
                //                {
                //                    MessageBox.Show("Esta imágen ya había sido agregada con anterioridad");
                //                    Carga = false;
                //                }
                //            }
                //            catch
                //            {
                //                string sentenciaSQL = "insert into imagenIncidencia (idIncidencia, imagen, candado, nombreArchivo, idOTR, imageninicial) values (" + this.idincidencia + ", @imagen, '" + candado + "', '" + Abrir.FileNames[i].Replace("'", "") + "', " + sIdOP + ", 1)";
                //                if (!ExtraeDato.guardaImagen(sentenciaSQL, pictureBox2))
                //                {
                //                    MessageBox.Show("No se pudo agregar imágen. Intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //                }
                //                else
                //                {
                //                    Carga = true;
                //                }
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    foreach (var item in Abrir.FileNames)
                //    {
                //        i++;
                //        rutaReal = item;
                //        if (rutaReal != "")
                //        {
                //            pictureBox2.Image = ExtraeDato.redimensionar(rutaReal, false);
                //            try
                //            {
                //                if (0 != (this.index = int.Parse(ExtraeDato.Cadena("select idImagen from imagenesGenerales where idMaestro = " + sIdOP + " and idtipo = 0 and Descripcion = 'Imagen de OT' and Titulo = '" + Abrir.FileNames[i].Replace("'", "") + "'"))))
                //                {
                //                    MessageBox.Show("Esta imágen ya había sido agregada con anterioridad");
                //                    Carga = false;
                //                }
                //            }
                //            catch
                //            {
                //                //Tipo = 0 ---> Imagen de OT
                //                string sentenciaSQL = "insert into imagenesGenerales (idTipo, Titulo, Descripcion, imagen, idMaestro) values (0, '" + Abrir.FileNames[i].Replace("'", "") + "', 'Imagen de OT', @imagen, " + sIdOP + ")";
                //                if (!ExtraeDato.guardaImagen(sentenciaSQL, pictureBox2))
                //                {
                //                    MessageBox.Show("No se pudo agregar imágen. Intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //                }
                //                else
                //                {
                //                    Carga = true;
                //                }
                //            }
                //        }
                //    }
                //}
                //cargaPicture2(Carga, index, serieOT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocurrio el siguiente error");
            }
        }
    }
}