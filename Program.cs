using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VitalLabSoft
{
    static class Program
    {
        #region variablesGlobales
        public static string[] infoUsuarioConectado = new string[] { "", "", "", "", ""};
        //                                             idUsuario, nUsuario, Permisos, correo, idempleado, rutaArchivos
        public static string[] infoConexion = new string[] { "", "", "", "", "" }; 
        //                                              instancia, usuario password, BD
        public static bool conexionEstablecida = false;
        public static string textoBitacora = "";
        #endregion
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
        public static TextBox evaluaCamposLigero(TextBox texto, int posicion)
        {
            string original = texto.Text;
            texto.Text = texto.Text.Replace("*", "").Replace("'", "").Replace("\"", "").Replace("%", "").Replace("&", "").Replace("=", "").Replace("?", "").Replace("$", "");
            if (texto.Text != original)
            {
                MessageBox.Show("Favor de introducir solo caracteres alfanuméricos.", "Caracteres inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            texto.Select(posicion, 0);
            return texto;
        }
        public static TextBox evaluaCamposFuerte(TextBox texto)
        {
            string original = texto.Text;
            texto.Text = Regex.Replace(texto.Text, @"[^\w\.@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            if (texto.Text != original)
            {
                MessageBox.Show("Favor de introducir solo caracteres alfanuméricos.", "Caracteres inválidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //texto.Select(texto.Text.Length, 0);
            return texto;
        }
        public static Boolean formateoEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Favor de introducir una dirección email válida", "Email incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Favor de introducir una dirección email válida", "Email incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        public static string codificaSHA1(string value)
        {
            if (value != "sinpass:1")
            {
                var data = Encoding.ASCII.GetBytes(value);
                var hashData = new SHA1Managed().ComputeHash(data);
                var hash = string.Empty;
                foreach (var b in hashData)
                {
                    hash += b.ToString("X2");
                }
                return hash;
            }
            else
            {
                return value;
            }
        }

        public static string codifica(string Palabra)
        {
            string Salida = "";
            char tChr;
            int vChr = 0;
            for (int i = 0; i < Palabra.Length; i++)
            {
                tChr = Convert.ToChar(Palabra.Substring(i, 1));
                vChr = char.ConvertToUtf32(Palabra, i);
                if (i % 2 == 0)
                    vChr = vChr + 5;
                else
                    vChr = vChr - 5;
                Salida = Salida + Convert.ToString(char.ConvertFromUtf32(vChr));
            }
            return Salida;
        }

        public static string deCodifica(string Palabra)
        {
            string Salida = "";
            char tChr;
            int vChr = 0;
            for (int i = 0; i < Palabra.Length; i++)
            {
                tChr = Convert.ToChar(Palabra.Substring(i, 1));
                vChr = char.ConvertToUtf32(Palabra, i);
                if (i % 2 == 0)
                    vChr = vChr - 5;
                else
                    vChr = vChr + 5;
                Salida = Salida + Convert.ToString(char.ConvertFromUtf32(vChr));
            }
            return Salida;
        }


        public static string FormateoFechaHora(DateTime tFecha)
        {
            try
            {
                string sFecha;
                string tStr;

                sFecha = Convert.ToString(tFecha.Year);
                tStr = Convert.ToString(tFecha.Month);
                if (tStr.Length == 1)
                    tStr = "0" + tStr;
                sFecha = sFecha + tStr;
                tStr = Convert.ToString(tFecha.Day);
                if (tStr.Length == 1)
                    tStr = "0" + tStr;
                sFecha = sFecha + tStr + " ";
                tStr = Convert.ToString(tFecha.Hour);
                if (tStr.Length == 1)
                    tStr = "0" + tStr;
                sFecha = sFecha + tStr + ":";
                tStr = Convert.ToString(tFecha.Minute);
                if (tStr.Length == 1)
                    tStr = "0" + tStr;
                sFecha = sFecha + tStr + ":";
                tStr = Convert.ToString(tFecha.Second);
                if (tStr.Length == 1)
                    tStr = "0" + tStr;
                sFecha = sFecha + tStr;

                return sFecha;
            }
            catch
            {
                return "20090101 12:00:00";
            }
        }
        public static string FormateoFecha(DateTime tFecha)
        {
            try
            {
                string sFecha;
                string tStr;
                sFecha = Convert.ToString(tFecha.Year);
                tStr = Convert.ToString(tFecha.Month);
                if (tStr.Length == 1)
                {
                    tStr = "0" + tStr;
                }
                sFecha = sFecha + tStr;
                tStr = Convert.ToString(tFecha.Day);
                if (tStr.Length == 1)
                {
                    tStr = "0" + tStr;
                }
                sFecha = sFecha + tStr;
                return sFecha;
            }
            catch
            {
                return "20090101";
            }
        }
        public static string FormateoFechaDesdeCombo(string tFecha)
        {
            try
            {
                string[] cFechaArray = tFecha.Split('/');
                string cFecha = cFechaArray[2] + cFechaArray[1] + cFechaArray[0];
                return cFecha;
            }
            catch
            {
                return "20090101";
            }
        }
        public static string[] CalculaExistenciaActual(int _idProducto, bool entrada, bool lPorFecha, string cFechaCadu)
        {
            string[] Cantidades = new string[] { "0", "Unidades" };
            try
            {
                double CantidadSalida = 0, CantidadActual = 0, CantidadEntrada = 0;
                CantidadEntrada = ExtraerDato.NumeroReal("select SUM(CantidadInicial) from ExistenciaPorFecha where idProducto = " + _idProducto + (lPorFecha ? " and dtCaducidad " + (cFechaCadu.Length > 0 ? " = '" + cFechaCadu + "'" : "is null") :""));
                if (CantidadEntrada > 0)
                {
                    CantidadActual = ExtraerDato.NumeroReal("select SUM(Cantidad) from ExistenciaPorFecha where idProducto = " + _idProducto + (lPorFecha ? "and dtCaducidad " + (cFechaCadu.Length > 0 ? " = '" + cFechaCadu + "'" : "is null") : ""));
                    if (CantidadEntrada > CantidadSalida)
                    {
                        string[] infoProducto = ExtraerDato.CadenaArrayFila("select contenido, Presentacion, UMUso from Productos where idproducto = " + _idProducto);
                        CantidadSalida = (CantidadEntrada - CantidadActual);
                        if (entrada)
                        {
                            Cantidades[0] = CantidadActual.ToString();
                            Cantidades[1] = infoProducto[1];
                        }
                        else
                        {
                            Cantidades[0] = (Math.Round(CantidadActual * double.Parse(infoProducto[0]), 3)).ToString();
                            Cantidades[1] = infoProducto[2];
                        }
                    }
                }
            }
            catch
            { }
            return Cantidades;
        }
        public static string FechaDiagonales(DateTime tFecha)
        {
            try
            {
                string sFecha;
                string tStr;

                tStr = Convert.ToString(tFecha.Day);
                if (tStr.Length == 1)
                    tStr = "0" + tStr;
                sFecha = tStr + "/";
                tStr = Convert.ToString(tFecha.Month);
                if (tStr.Length == 1)
                    tStr = "0" + tStr;
                sFecha = sFecha + tStr + "/" + Convert.ToString(tFecha.Year);

                return sFecha;
            }
            catch
            {
                return "01/01/2009";
            }
        }
        public static DateTime FechaDesdeGrid(string tFecha)
        {
            try
            {
                string[] fecha = tFecha.Split('/');
                return new DateTime(int.Parse(fecha[2]), int.Parse(fecha[1]), int.Parse(fecha[0]));
            }
            catch
            {
                return DateTime.Now;
            }
        }
    }
}