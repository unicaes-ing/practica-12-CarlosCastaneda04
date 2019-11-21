using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
//CarlosCastaneda
namespace practica12
{
    //Ejercicio 1 y 2
    class Program
    {
        [Serializable]
        public struct Mascota
        {
            public string nombre;
            public string especie;
            public string raza;
            public string sexo;
            public int edad;
            public void setEdad(int edad)
            {
                if (edad > 0)
                {
                    this.edad = edad;
                }
            }
            public int getEdad()
            {
                return edad;
            }
        }
        static void Main(string[] args)
        {
            Mascota mascota = new Mascota();
            FileStream fs;
            BinaryFormatter formatter = new BinaryFormatter();
            const string mascotas = "mascota.bin";
            try
            {
                Console.WriteLine("******DATOS DE MASCOTAS*******");
                Console.WriteLine();
                Console.Write("Nombre: ");
                mascota.nombre = Console.ReadLine();
                Console.Write("Especie: ");
                mascota.especie = Console.ReadLine();
                Console.Write("Raza: ");
                mascota.raza = Console.ReadLine();
                Console.Write("Sexo: ");
                mascota.sexo = Console.ReadLine();
                Console.Write("Edad: ");
                mascota.setEdad(Convert.ToInt32(Console.ReadLine()));
                fs = new FileStream(mascotas, FileMode.Create, FileAccess.Write);
                formatter.Serialize(fs, mascota);
                fs.Close();
                Console.WriteLine();
                Console.WriteLine("La Mascota fue almacenado correctamente...");
                Console.WriteLine("precione <ENTER> para mostrar los datos");
                Console.ReadKey();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.Clear();
            Console.WriteLine("Mostrando datos: ");
            fs = new FileStream(mascotas, FileMode.Open, FileAccess.Read);
            var mascotareesp = (Mascota)formatter.Deserialize(fs);
            Console.WriteLine("Nombre de mascota: ");
            Console.WriteLine(mascotareesp.nombre);
            Console.WriteLine("Especie de mascota: ");
            Console.WriteLine(mascotareesp.especie);
            Console.WriteLine("Raza de mascota: ");
            Console.WriteLine(mascotareesp.raza);
            Console.WriteLine("Sexo de mascota: ");
            Console.WriteLine(mascotareesp.sexo);
            Console.WriteLine("Edad de mascota: ");
            Console.WriteLine(mascotareesp.edad);
            Console.ReadKey();

            fs.Close();
        }
    }
}
