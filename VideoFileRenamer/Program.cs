using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VideoFileRenamer
{

    class Parametros
    {
        // Si los argumentos pasados son 0 --> Se pedira almenos el nombre general para los ficheros
        // Si los argumentos pasados son 1 --> Sera el nombre de los ficheros.
        // Si los argumentos pasados son 2 --> Uno sera el nombre de los ficheros y el otro sera el path a los ficheros

        public string NombreFicheros;
        public string Path;

        public Parametros()
        {
            Path = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("Introduce el nombre base de los ficheros de video");
            NombreFicheros = Console.ReadLine();
        }

        public Parametros(string Txt)
        {
            Path = AppDomain.CurrentDomain.BaseDirectory;
            NombreFicheros = Txt;
        }

        public Parametros(string Txt,string Txt2)
        {
            if ((IsValidPath(Txt)) && (!IsValidPath(Txt2)))
            {
                Path = Txt;
                NombreFicheros = Txt2;
            }
            else
            {
                if ((!IsValidPath(Txt)) && (IsValidPath(Txt2)))
                {
                    Path = Txt2;
                    NombreFicheros = Txt;
                }
                else
                {
                    Path = "";
                    NombreFicheros = "";
                }
            }
        }

        private bool IsValidPath(string path)
        {
            bool isValid = true;
            try
            {
                string root = System.IO.Path.GetPathRoot(path);
                isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
            }
            catch (Exception ex)
            {
                isValid = false;
            }
            return isValid;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) { Parametros test = new Parametros(); }
            if (args.Length == 1) { Parametros test = new Parametros(args[0]); }
            if (args.Length == 2) { Parametros test = new Parametros(args[0], args[1]); }
        }
    }

}

