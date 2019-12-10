using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
namespace Proyecto
{
   public class Producto
    {
        public string codigo 
        {
            get;
            set;
        }
        public string descripcion
        {
            get;
            set;
        }
        public Double precio
        {
            get;
            set;
        }
        public Int16 departamento
        {
            get;
            set;
        }

        public Int16 likes
        {
            get;
            set;
        }


        public Producto(string code, string description, decimal price, int depto, int like)
        {
            codigo = code;
            descripcion = description;
            precio= price;
            departamento =depto;
            likes = like;
        }

    }
    public class ProductoDB
    {
     
    }
    public class Program
    {
        static void Main(string[] args)
        {
             Producto producto = new Producto();
             try{
                 //Paso 1
            //Escribi la lista de los codigo
            List<string> ListaCodigos = new List<string>() {("CONSOLECO","LAPPTOPP")};
            //Escribi la lista de las Descripciones
            List<string> ListaDescripcion = new List<string>() {"1. Negro, Incluye dos juegos", "2. Azul Marino, Incluye mouse" };
            //Escribi la lista de los Precios
            List<Decimal> ListaPrecio = new List<Decimal>() { 2500, 5000 };
            //Escribi la lista del Departamento
            List<int> ListaDepartamento = new List<int>() { 012, 080 };
            //Escribi la lista del Likes
            List<int> ListaLikes = new List<int>() { 1000, 589 };
            using (StreamWriter EscribirDatos = new StreamWriter(@"D:\Proyecto_Producto\Datos.txt"))
            {
                //En el texto para que se vea estetico, ponemos que es cada lista
                EscribirDatos.WriteLine("INFORMACION");
                foreach (string c in ListaCodigos)
                    {
                    //Nuestro objeto Datos, que lleva la ruta, le asignamos la informacion de las listas a nuestro archivo Datos.txt
                    //Y la "c" esta leyendo la lista de codigos que escribimos
                        EscribirDatos.WriteLine(c.code);
                        EscribirDatos.WriteLine(c.description);
                        EscribirDatos.WriteLine(c.price);
                        EscribirDatos.WriteLine(c.depto);
                        EscribirDatos.WriteLine(c.like);
                    }
                //En el texto para que se vea estetico, ponemos que es cada lista
                EscribirDatos.WriteLine("LISTA DE DESCRIPCION");
                foreach (string d in ListaDescripcion)
                {
                    
                   //Y la "d" esta leyendo la lista de descripciones que escribimos
                    EscribirDatos.WriteLine(d);
                }

                //En el texto para que se vea estetico, ponemos que es cada lista
                EscribirDatos.WriteLine("LISTA DE PRECIOS");
                foreach (Decimal p in ListaPrecio)
                {
                    //Y la "p" esta leyendo la lista de precios que escribimos
                    EscribirDatos.WriteLine(p);
                }

                //En el texto para que se vea estetico, ponemos que es cada lista
                EscribirDatos.WriteLine("LISTA DEL DEPARTAMENTO");
                foreach (int Dep in ListaDepartamento)
                {
                    //Y la "Dep" esta leyendo la lista de departamento que escribimos
                    EscribirDatos.WriteLine(Dep);
                }
                //En el texto para que se vea estetico, ponemos que es cada lista
                EscribirDatos.WriteLine("LISTA DEL LIKES");
                foreach (int l in ListaLikes)
                {
                    //Y la "l" esta leyendo la lista de likes que escribimos
                    EscribirDatos.WriteLine(l);
                }
            }
            }
            
            catch
            { }
            
            Console.ReadKey();
        }
    }
}

            
   