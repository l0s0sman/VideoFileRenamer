using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VideoFileRenamer
{
    class FileObserver
    {
        // Variables
        public static string Ruta;
        public static string NombreBase;

        public static string[] NombreFicheros;
        public static int NumeroFicheros = 0;


        // Constructor 
        public FileObserver (string Txt, string Txt2)
        {
            Ruta = Txt;
            NombreBase = Txt2;


        }

        private void ObtenerFicheros(string Ruta)
        {

        }
    }
}
