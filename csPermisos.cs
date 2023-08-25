using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalLabSoft
{
    static class csPermisos
    {
        public static string comprobarPermisos(string permisos)
        {
            return permisos;
        }
        public static bool tienePermiso(int posicion)
        {
            bool permiso = false;
            if (Program.infoUsuarioConectado[2].Substring(posicion, 1) == "1")
            {
                permiso = true;
            }
            return permiso;
        }
    }
}
