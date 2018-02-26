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
        public string Ruta;

        // Constructor sin parametros
        public Parametros()
        {
            Ruta = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("Introduce el nombre base de los ficheros de video");
            NombreFicheros = Console.ReadLine();
        }

        // Constructor con un parametro
        public Parametros(string Txt)
        {
            if (!IsValidPath(Txt))
            {
                // Si el unico parametro introducido es el nombre de los ficheros, el path sera el directorio base
                Ruta = AppDomain.CurrentDomain.BaseDirectory;
                NombreFicheros = Txt;
            }
            else
            {
                // Si el unico parametro introducido es el path, hay que solicitar el path
                Ruta = Txt;
                Console.WriteLine("Introduce el nombre base de los ficheros de video");
                NombreFicheros = Console.ReadLine();
            }
        }

        // Constructor con dos parametros
        public Parametros(string Txt,string Txt2)
        {
            // El primer parametro es un path y el segundo es el nombre
            if ((IsValidPath(Txt)) && (!IsValidPath(Txt2)))
            {
                Ruta = Txt;
                NombreFicheros = Txt2;
            }
            else
            {
                //El primer parametro es el nombre y el segundo es un path
                if ((!IsValidPath(Txt)) && (IsValidPath(Txt2)))
                {
                    Ruta = Txt2;
                    NombreFicheros = Txt;
                }
                else
                {
                    // Los dos parametros pueden ser path valido o son nombres 
                    // Por lo que es un error 
                    Console.WriteLine("Error, Parametros confusos, no se pueden identificar la ruta del nombre para los ficheros");
                    Console.WriteLine(string.Format("Primer Parametro: {0}", Txt));
                    Console.WriteLine(string.Format("Segundo Parametro: {0}", Txt2));
                    Ruta = null;
                    NombreFicheros = null;
                }
            }
        }

        // Funcion que evalua sin un texto es un path valido
        private bool IsValidPath(string path)
        {
            bool isValid = true;
            try
            {
                string root = Path.GetPathRoot(path);
                isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
            }
            catch (Exception ex)
            {
                isValid = false;
            }
            return isValid;
        }

        // Funcion que rellena el nombre para los ficheros de video
        public void SetNombre (string Txt) { NombreFicheros = Txt; }
        
        // Funcion que rellena el path donde buscar los ficheros de video
        public void SetPath (string Txt) { Ruta = Txt; }

    }

    class Program
    {
        public static Parametros Config;

        static void Main(string[] args)
        {
            bool Continuar = true;
            
            // Carga de parametros 
            if (args.Length == 0) { Config = new Parametros(); }
            if (args.Length == 1) { Config = new Parametros(args[0]); }
            if (args.Length == 2) { Config = new Parametros(args[0], args[1]); }
            if (args.Length > 2)
            {
                Console.WriteLine("Error, demasiados parametros.");
                Console.WriteLine("Solo se admiten como maximo dos parametros:");
                Console.WriteLine("Una ruta y un nombre base para los ficheros de video. ");
                Continuar = false;
            }

            // Evaluacion de que los parametros estan rellenos 
            if (Continuar)
            {
                if ((string.IsNullOrEmpty(Config.Ruta)) && (string.IsNullOrEmpty(Config.NombreFicheros)))
                { Continuar = false; }
            }
            
            // Resumen de la carga de parametros
            if (Continuar)
            {
                Console.WriteLine(string.Format("Se buscaran los ficheros de video del path: {0}", Config.Ruta));
                Console.WriteLine(string.Format("El nombre para los ficheros sera: {0}", Config.NombreFicheros));                
            }


        }
    }

}

