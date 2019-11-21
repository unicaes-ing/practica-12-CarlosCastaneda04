using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace guia12
{
    class ejercicio3
    {
        [Serializable]
        public struct Alumno
        {

            public string carnet;
            public string nombre;
            public string carrera;
            private double cum;



            private Dictionary<string, Alumno> dicAlumno;
            private BinaryFormatter formater;
            private const string archivo = "alumnos.bin";


            static void Main(string[] args)
            {
                Alumno alumno = new Alumno();
                int opc2 = 0;
                Console.WriteLine("1. Agregar alumno");
                Console.WriteLine("2. Mostrar alumnos");
                Console.WriteLine("3. Buscar alumno");
                Console.WriteLine("4. editar alumno");
                Console.WriteLine("5. Agregar alumno");
                Console.Write("Su opcion:");
                opc2 = Convert.ToInt32(Console.ReadLine());
                switch (opc2)
                {
                    case 1:
                        Console.Clear();
                        alumno.agregarAlumno();
                        break;
                    case 2:
                        Console.Clear();
                        alumno.mostrarDic();
                        break;
                    case 3:
                        Console.Clear();
                        alumno.buscarAlumno();
                        break;
                    case 4:
                        Console.Clear();
                        alumno.editarAlumno();
                        break;
                    case 5:
                        Console.Clear();
                        alumno.eliminarAlum();
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            }

            public void agregarAlumno()
            {
               
                Alumno alumno = new Alumno();
                FileStream fs;
                BinaryFormatter formatter = new BinaryFormatter();
                const string alumnos = "alumno.bin";
                Console.WriteLine("Nombre: ");
                alumno.nombre = Console.ReadLine();
                Console.WriteLine("Carnet: ");
                alumno.carnet = Console.ReadLine();
                Console.WriteLine("Carrera: ");
                alumno.carrera = Console.ReadLine();
                Console.WriteLine("CUM");
                alumno.cum = Convert.ToDouble(Console.ReadLine());
                fs = new FileStream(alumnos, FileMode.Create, FileAccess.Write);
                formatter.Serialize(fs, alumno);
                fs.Close();
                Console.WriteLine("\nLos datos fueron agregados");
            }
            

            public bool guardarDic(Dictionary<string, Alumno> dic)
            {
                formater = new BinaryFormatter();

                FileStream fs = new FileStream(archivo, FileMode.Create, FileAccess.Write);
                try
                {

                    formater.Serialize(fs, dic);
                    fs.Close();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    fs.Close();
                    Console.WriteLine("No se guardo");
                    return false;

                }
            }

            public bool mostrarDic()
            {
                FileStream fs = new FileStream(archivo, FileMode.Open, FileAccess.Read);
                try
                {

                    dicAlumno = (Dictionary<string, Alumno>)formater.Deserialize(fs);
                    fs.Close();

                    Console.WriteLine("alumnos");
                    Console.WriteLine("****************************************************************************************");
                    Console.WriteLine("****************************************************************************************");
                    Console.WriteLine("{0, 6} {1, 12} {2, 20} {0, 25}", "Carnet", "nombre", "Carrera", "CUM");
                    foreach (KeyValuePair<string, Alumno> item in dicAlumno)
                    {
                        Alumno alum = item.Value;
                        Console.WriteLine("{0, 6} {1, 12} {2, 20} {0, 25}", alum.carnet, alum.nombre, alum.carrera, alum.cum);
                    }
                    return true;
                }
                catch (Exception)
                {
                    fs.Close();
                    return false;

                }

            }

            public void buscarAlumno()
            {
                Console.WriteLine("Coloque el carnet del alumno a buscar");
                string carnet = Console.ReadLine();

                if (dicAlumno.ContainsKey(carnet))
                {
                    Console.WriteLine("Este alumno existe en el diccionario");
                }
                else
                {
                    Console.WriteLine("El alumno no fue encontrado");
                }
            }

            public void editarAlumno()
            {
                Console.WriteLine("Coloque el carnet del alumno que desea editar");
                string carnet = Console.ReadLine();

                if (dicAlumno.ContainsKey(carnet))
                {
                    var alum = dicAlumno[carnet];

                    Console.WriteLine("Coloque el nuevo nombre:");
                    alum.nombre = Console.ReadLine();
                    Console.WriteLine("Coloque la nueva carrera");
                    alum.carrera = Console.ReadLine();
                    Console.WriteLine("Coloque el nuevo carnet");
                    alum.carnet = Console.ReadLine();
                    Console.WriteLine("Coloque el nuevo cum");
                    alum.cum = Convert.ToDouble(Console.ReadLine());
                    FileStream fs = new FileStream(archivo, FileMode.Open, FileAccess.Write);

                    formater.Serialize(fs, alum);


                }
            }
            

            public void eliminarAlum()
            {
                Console.WriteLine("Coloque el carnet del alumno que desea eliminar");
                string carnet = Console.ReadLine();

                if (dicAlumno.ContainsKey(carnet))
                {
                    var alum = dicAlumno[carnet];
                    dicAlumno.Remove(carnet);
                }
            }
        }
    }
}