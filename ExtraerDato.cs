using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace VitalLabSoft
{
    public class ExtraerDato
    {
        /// <summary>
        /// Extrae un dato tipo String, solo extrae la primera fila del primer campo
        /// </summary>
        /// <param name="StrSQL">Secuencia SQL de busqueda</param>
        /// <returns>Devuelve vacío si no encontro nada, o el dato a buscar</returns>
        public static string Cadena(string StrSQL)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader lee;
            string Salida = "";
            try
            {
                cnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
                cnn.Open();
                cmd = new SqlCommand(StrSQL, cnn);
                lee = cmd.ExecuteReader();
                if (lee.Read())
                {
                    if (!lee.IsDBNull(0))
                    {
                        Salida = lee.GetValue(0).ToString();
                    }
                }
                lee.Close();
                cnn.Close();
            }
            catch { }
            return Salida;
        }
        
        /// <summary>
        /// Devuelve una Imagen con código QR estándart de cualquier texto recibido
        /// </summary>
        /// <param name="texto"></param>
        /// <returns>imagen de QR 400 x 400</returns>
        public static Image aQR(string texto, int sizeQR)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(texto, out qrCode);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(sizeQR, QuietZoneModules.Zero), Brushes.DarkBlue, Brushes.White);
            MemoryStream ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            Image temporal = Image.FromStream(ms);
            Image QR = new Bitmap(temporal, new Size(new Point(sizeQR, sizeQR)));
            return QR;
        }

        /// <summary>
        /// Inserta una imágen en la base de datos
        /// </summary>
        /// <param name="StrSQL">Secuencia SQL de busqueda, el dato de imágen debe ser enviado para ser agregado como parámetro adicional</param>
        /// <param name="pbImagen">Contenido de un PictureBox</param>
        /// <returns>Devuelve true o false dependiendo si el proceso de guardado ha sido exitoso</returns>
        public static bool guardaImagen(string StrSQL, PictureBox pbImagen)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader lee;
            bool Salida = false;
            try
            {
                cnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
                cnn.Open();
                try
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    cmd = new SqlCommand(StrSQL, cnn);
                    cmd.Parameters.Add("@imagen", SqlDbType.Image);
                    try
                    {
                        pbImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        cmd.Parameters["@imagen"].Value = ms.GetBuffer();
                    }
                    catch
                    {
                        cmd.Parameters["@imagen"].Value = DBNull.Value;
                    }
                    lee = cmd.ExecuteReader();
                    Salida = true;
                }
                catch { }
                cnn.Close();
            }
            catch {}
            return Salida;
        }

        /// <summary>
        /// Extrae una lista de imágenes en la base de datos
        /// </summary>
        /// <param name="StrSQL">Secuencia SQL de busqueda, el dato de imágen debe ser enviado para ser agregado como parámetro adicional</param>
        /// <param name="pbImagen">Contenido de un PictureBox</param>
        /// <returns>Devuelve true o false dependiendo si el proceso de guardado ha sido exitoso</returns>
        public static ArrayList listadoImagenes(string StrSQL)
        {
            SqlConnection cnn;
            DataTable dtImagenes = new DataTable();
            ArrayList listaImagenes = new ArrayList();
            try
            {
                cnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
                cnn.Open();
                try
                {
                    SqlDataAdapter dalistado = new SqlDataAdapter(StrSQL, cnn);
                    dalistado.Fill(dtImagenes);
                    foreach (DataRow fila in dtImagenes.Rows)
                    {
                        byte[] datos = new byte[0];
                        datos = (byte[])fila[0];
                        System.IO.MemoryStream ms = new System.IO.MemoryStream(datos);
                        listaImagenes.Add(System.Drawing.Bitmap.FromStream(ms));
                    }
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Ocurrio el siguiente error al intentar cargar los datos:\n" + ex1.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cnn.Close();
            }
            catch {}
            return listaImagenes;
        }

        /// <summary>
        /// Extrae una imagen de la base de datos
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>Devuelve una imagen de la base de datos</returns>
        public static Image imagen(string sql)
        {
            SqlConnection cnn;
            cnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
            cnn.Open();
            SqlCommand command1 = new SqlCommand(sql, cnn);
            byte[] img = (byte[])command1.ExecuteScalar();
            MemoryStream str = new MemoryStream();
            str.Write(img, 0, img.Length);
            Bitmap bit = new Bitmap(str);
            cnn.Close();
            return bit;
        }
        
        /// <summary>
        /// Convierte arreglo de bit en imagen
        /// </summary>
        /// <param name="img">Arreglo de Bits</param>
        /// <returns>Devuelve una imagen desde un arreglo de bits.</returns>
        public static Image byteToImagen(byte[] img)
        {
            MemoryStream str = new MemoryStream();
            str.Write(img, 0, img.Length);
            Bitmap bit = new Bitmap(str);
            return bit;
        }

        /// <summary>
        /// Si una imagen es demasiado grande, la redimensiona.
        /// </summary>
        /// <param name="Foto">Foto/imagen que se desea redimensionar</param>
        /// <param name="tipo">Indica si la redimensión será en extremo pequeña (720 pixeles horizontales)</param>
        /// <returns>Devuelve true o false dependiendo si el proceso de guardado ha sido exitoso</returns>
        public static Bitmap redimensionar(Image Foto, int tipo)
        {
            //tipo
            // 1 - Logo empresa/sucursal
            // 2 - Foto empleado

            //Se crea el BitMap desde la ruta de la PC
            Bitmap image = (Bitmap)Foto;
            //Identificamos que tan grande es la imagen
            double porcentaje = 1;
            switch (tipo)
            {
                case 1:
                    if (image.Width >= 341) //Si es mayor a FHD se reduce a 1920x1080
                    {
                        porcentaje = Math.Round((double)(34100 / image.Width), 4) / 100;
                    }
                    break;
                case 2:
                    if (image.Height >= 268) //Si es mayor a 268 se reduce.
                    {
                        porcentaje = Math.Round((double)(26800 / image.Height), 4) / 100;
                    }
                    break;
            }
            //Obtenemos el actual ancho y alto.
            int destinoWidth = (int)(image.Width * porcentaje);
            int destinoHeight = (int)(image.Height * porcentaje);
            //Y aquí es donde redimensionamos la imagen, creamos un segundo bitmap de la imagen con las nuevas medidas
            Bitmap Imagen2 = new Bitmap(destinoWidth, destinoHeight);
            //Y creamos la imagen con la clase Graphics
            using (Graphics g = Graphics.FromImage((Image)Imagen2)) { g.DrawImage(image, 0, 0, destinoWidth, destinoHeight); }
            //Por último eliminamos referencias y devolvemos la imagen al método que ha llamado a esta clase.
            image.Dispose();
            return (Imagen2);
        }
        /// <summary>
        /// Extrae un arreglo de datos tipo String, Solo regresa la primera columna de la busqueda
        /// </summary>
        /// <param name="StrSQL">Secuencia SQL de busqueda</param>
        /// <returns>Devuelve null si no encontro datos, de lo contrario el arreglo con los datos encontrados</returns>
        public static string[] CadenaArray(string StrSQL)
        {
            string[] Salida = null;

            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader lee;

            ArrayList Listado = new ArrayList();

            try
            {
                cnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
                cnn.Open();

                try
                {
                    cmd = new SqlCommand(StrSQL, cnn);
                    lee = cmd.ExecuteReader();
                    while (lee.Read())
                    {
                        Listado.Add(lee.GetValue(0));
                    }
                    lee.Close();

                    if (Listado.Count > 0)
                    {
                        Salida = new string[Listado.Count];
                        for (int i = 0; i < Listado.Count; i++)
                        {
                            Salida[i] = Listado[i].ToString();
                        }
                    }
                }
                catch //(Exception ex1)
                {
                    // MessageBox.Show("Ocurrio el siguiente error al intentar cargar los datos:\n" + ex1.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                cnn.Close();
            }
            catch //(Exception ex)
            {
                // MessageBox.Show("Ocurrio el siguiente error al intentar conectar con la base de datos:\n" + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return Salida;
        }

        /// <summary>
        /// Extrae un listado de datos tipo ArrayList, Solo regresa la primera columna de la busqueda
        /// </summary>
        /// <param name="StrSQL">Secuencia SQL de busqueda</param>
        /// <returns>Devuelve null si no encontro datos, de lo contrario el arreglo con los datos encontrados</returns>
        public static ArrayList listadoColumna(string StrSQL)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader lee;

            ArrayList Listado = new ArrayList();
            try
            {
                cnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
                cnn.Open();

                try
                {
                    cmd = new SqlCommand(StrSQL, cnn);
                    lee = cmd.ExecuteReader();
                    while (lee.Read())
                    {
                        Listado.Add(lee.GetValue(0));
                    }
                    lee.Close();

                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Ocurrio el siguiente error al intentar cargar los datos:\n" + ex1.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                cnn.Close();
            }
            catch //(Exception ex)
            {
                // MessageBox.Show("Ocurrio el siguiente error al intentar conectar con la base de datos:\n" + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return Listado;
        }
        /// <summary>
        /// Extrae un arreglo de datos tipo String, Solo regresa la primera fila de la busqueda
        /// </summary>
        /// <param name="StrSQL">Secuencia SQL de busqueda</param>
        /// <returns>Devuelve null si no encontro datos, de lo contrario el arreglo con los datos encontrados</returns>
        public static string[] CadenaArrayFila(string StrSQL)
        {
            string[] Salida = null;

            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader lee;

            ArrayList Listado = new ArrayList();

            //try
            //{
            cnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
            cnn.Open();

            //try
            //{
            cmd = new SqlCommand(StrSQL, cnn);
            lee = cmd.ExecuteReader();
            lee.Read();
            if (lee.FieldCount > 0)
            {
                Salida = new string[lee.FieldCount];
                for (int i = 0; i < lee.FieldCount; i++)
                {
                    try
                    {
                        Salida[i] = lee.GetValue(i).ToString();
                    }
                    catch (Exception ex)
                    {
                        string que = ex.ToString();
                        break;
                    }
                }
            }
            lee.Close();

            return Salida;
        }
        public static string formatoPesos(double cantidad)
        {
            try
            {
                bool negativo = false;
                if (cantidad < 0)
                {
                    cantidad = cantidad * (-1);
                    negativo = true;
                }
                string sCantidad = cantidad.ToString();
                if (cantidad < 10)
                {
                    sCantidad = cantidad.ToString("$ 0.00");
                }
                else
                {
                    if (cantidad < 100)
                    {
                        sCantidad = cantidad.ToString("$ 00.00");
                    }
                    else
                    {
                        if (cantidad < 1000)
                        {
                            sCantidad = cantidad.ToString("$ 000.00");
                        }
                        else
                        {
                            if (cantidad < 10000)
                            {
                                sCantidad = cantidad.ToString("$ 0,000.00");
                            }
                            else
                            {
                                if (cantidad < 100000)
                                {
                                    sCantidad = cantidad.ToString("$ 00,000.00");
                                }
                                else
                                {
                                    if (cantidad < 1000000)
                                    {
                                        sCantidad = cantidad.ToString("$ 000,000.00");
                                    }
                                    else
                                    {
                                        if (cantidad < 10000000)
                                        {
                                            sCantidad = cantidad.ToString("$ 0,000,000.00");
                                        }
                                        else
                                        {
                                            if (cantidad < 100000000)
                                            {
                                                sCantidad = cantidad.ToString("$ 00,000,000.00");
                                            }
                                            else
                                            {
                                                if (cantidad < 1000000000)
                                                {
                                                    sCantidad = cantidad.ToString("$ 000,000,000.00");
                                                }
                                                else
                                                {
                                                    if (cantidad < 10000000000)
                                                    {
                                                        sCantidad = cantidad.ToString("$ 0,000,000,000.00");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (negativo)
                {
                    sCantidad = "- " + sCantidad;
                }
                return sCantidad;
            }
            catch
            {
                return cantidad.ToString();
            }
        }
        /// <summary>
        /// Extrae un dato tipo númerico real, solo extrae la primera fila del primer campo
        /// </summary>
        /// <param name="StrSQL">Secuencia SQL de busqueda</param>
        /// <returns>Devuelve vacío si no encontro nada, o el dato a buscar</returns>
        public static double NumeroReal(string StrSQL)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader lee;

            double Salida = 0;

            try
            {
                cnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
                cnn.Open();

                try
                {
                    cmd = new SqlCommand(StrSQL, cnn);
                    lee = cmd.ExecuteReader();
                    if (lee.Read())
                    {
                        //lee.Read();
                        if (!lee.IsDBNull(0))
                            Salida = Convert.ToDouble(lee.GetValue(0));
                    }
                    lee.Close();
                }
                catch //(Exception ex1)
                {
                    //MessageBox.Show("Ocurrio el siguiente error al intentar cargar los datos:\n" + ex1.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                cnn.Close();
            }
            catch //(Exception ex)
            {
                // MessageBox.Show("Ocurrio el siguiente error al intentar conectar con la base de datos:\n" + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return Salida;
        }
        /// <summary>
        /// Extrae un dato tipo númerico entero de 16 bits, solo extrae la primera fila del primer campo
        /// </summary>
        /// <param name="StrSQL">Secuencia SQL de busqueda</param>
        /// <returns>Devuelve vacío si no encontro nada, o el dato a buscar</returns>
        public static int Entero16(string StrSQL)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader lee;

            int Salida = 0;

            try
            {
                cnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
                cnn.Open();

                try
                {
                    cmd = new SqlCommand(StrSQL, cnn);
                    lee = cmd.ExecuteReader();
                    if (lee.Read())
                    {
                        //lee.Read();
                        if (!lee.IsDBNull(0))
                            Salida = Convert.ToInt16(lee.GetValue(0));
                    }
                    lee.Close();
                }
                catch //(Exception ex1)
                {
                    //MessageBox.Show("Ocurrio el siguiente error al intentar cargar los datos:\n" + ex1.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                cnn.Close();
            }
            catch //(Exception ex)
            {
                // MessageBox.Show("Ocurrio el siguiente error al intentar conectar con la base de datos:\n" + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return Salida;
        }
        /// <summary>
        /// Extrae un dato tipo Fecha, solo extrae la primera fila del primer campo
        /// </summary>
        /// <param name="StrSQL">Secuencia SQL de busqueda</param>
        /// <returns>Devuelve la fecha del día actual si no encontro nada, o el dato a buscar</returns>
        public static DateTime Fecha(string StrSQL)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader lee;

            //DateTime Salida = DateTime.Now;
            DateTime Salida = Convert.ToDateTime("01/01/1900");
            try
            {
                /* IDbConnection cnn;
                 IDbCommand cmd;
                 IDataReader lee;

                 if (Program.bddWEB)
                 {
                     string connStr = String.Format("server={0};uid={1};pwd={2};database={3}", Program.MySQLServidor, Program.MySQLUsuario, Program.MySQLPassword, Program.sBaseMySQL);
                     cnn = new MySqlConnection(connStr);
                     cnn.Open();
                 }
                 else
                 {*/
                cnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
                cnn.Open();
                //}

                try
                {
                    cmd = new SqlCommand(StrSQL, cnn);
                    /* if (Program.bddWEB)
                     {
                         cmd = new MySqlCommand();
                         cmd.Connection = cnn;
                         cmd.CommandText = StrSQL;
                     }
                     else
                     {
                         cmd = new SqlCommand();
                         cmd.Connection = cnn;
                         cmd.CommandText = StrSQL;
                     }*/
                    lee = cmd.ExecuteReader();
                    if (lee.Read())
                    {
                        //lee.Read();
                        if (!lee.IsDBNull(0))
                            Salida = lee.GetDateTime(0);
                    }
                    lee.Close();
                }
                catch //(Exception ex1)
                {
                    //MessageBox.Show("Ocurrio el siguiente error al intentar cargar los datos:\n" + ex1.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                cnn.Close();
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Ocurrio el siguiente error al intentar conectar con la base de datos:\n" + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return Salida;
        }
        /// <summary>
        /// Determina si tiene registros el Query dado
        /// </summary>
        /// <param name="StrSQL">Secuencia SQL de busqueda</param>
        /// <returns>Verdadero si tiene registros, en caso contrario devuelve false</returns>
        public static bool TieneFilas(string StrSQL)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader lee;
            bool Salida = false;
            try
            {
                cnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
                cnn.Open();
                try
                {
                    cmd = new SqlCommand(StrSQL, cnn);
                    lee = cmd.ExecuteReader();
                    if (lee.Read())
                    {
                        Salida = true;
                    }
                    lee.Close();
                }
                catch //(Exception ex1)
                {
                    // MessageBox.Show("Ocurrio el siguiente error al intentar cargar los datos:\n" + ex1.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cnn.Close();
            }
            catch //(Exception ex)
            {
                //  MessageBox.Show("Ocurrio el siguiente error al intentar conectar con la base de datos:\n" + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return Salida;
        }
        /// <summary>
        /// Ejecuta la acción dada a través de la sentencia SQL
        /// </summary>
        /// <param name="StrSQL">Secuencia SQL de Acción</param>
        /// <returns>Devuelve verdadero si ejecuto correctamente la acción, falso si marca error</returns>
        public static bool AccionQuery(string StrSQL)
        {
            SqlConnection cnn;
            SqlCommand cmd;

            bool Salida = false;

            // DeNuez:
            try
            {
                cnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
                cnn.Open();
                try
                {
                    cmd = new SqlCommand(StrSQL, cnn);
                    cmd.ExecuteNonQuery();
                    Salida = true;
                }
                catch (Exception ex1)
                {
                    //MessageBox.Show("Ocurrio el siguiente error al intentar cargar los datos:\n" + ex1.Message, "Error de conexión al aplicar Accion Query", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cnn.Close();
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Ocurrio el siguiente error al intentar conectar con la base de datos:\n" + ex.Message + "\nSe intentará de nuevo", "Error de conexión Accion Query", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                // goto DeNuez;
            }
            return Salida;
        }
        public static DataTable listadoDatos(string Consulta)
        {
            SqlConnection cnn;
            // SqlCommand cmd;
            DataTable dtlistado = new DataTable();
            cnn = new SqlConnection("Server=" + Program.infoConexion[0] + "; database=" + Program.infoConexion[3] + "; user=" + Program.infoConexion[1] + "; pwd=" + Program.infoConexion[2]);
            //  cnn.Open();
            // string qlistado = "select * from qAuto";
            try
            {
                SqlDataAdapter dalistado = new SqlDataAdapter(Consulta, cnn);
                dalistado.Fill(dtlistado);
            }
            catch (Exception e)
            {
                //MessageBox.Show("No se pudo realizar la operación");
                //MessageBox.Show(e.ToString());
            }
            return dtlistado;
        }
    }
}