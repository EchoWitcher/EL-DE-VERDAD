
using System;
//Esto es para binario por que no aparece
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Proyecto
{
    //Clase Producto
    public class Producto
    {
        //Declaramos las variables
        public string Codigo 
        { get;
         set; }
        public string Descripcion
        { get; 
        set; }
        public double Precio
        { get; 
        set; }
        public int Departamento 
        { get;
         set; }
        public int Likes 
        { get; 
        set; }

        public Producto(string code, string description, double price, int dpto, int like)
        {//Asignar valores a las variales
            Codigo = code;
            Descripcion = description;
            Precio = price;
            Departamento = dpto;
            Likes = like;
        }
    }
    //Tipos de archivo
    //En este caso solo tenemos dos que ocupamos, texto y binario
    public enum FileType
    {
        Text, Binary
    }
    //Clase ProductoDB
    public static class ProductoDB
    {
        //Escogemos donde guardaremos el archivo, escribiremos
        public static void Escribe(string archivo, List<Producto> productos, FileType Exo = FileType.Text)
        {
            switch (Exo)
            {
                //En caso de ser de texto
                case FileType.Text:
                    EscribeTXT(archivo, productos);
                    break;
                    //En caso de ser un archivo binario

                case FileType.Binary:
                    EscribeBIN(archivo, productos);
                    break;
            }
        }
        //Para escribir archivo tipo texto
        private static void EscribeTXT(string archivo, List<Producto> productos)
        {
            try
            {
                if (!archivo.ToLower().Contains(".txt"))
                    throw new IOException("Formato incorrecto (Formato correcto '.txt')");

                using (StreamWriter sw = new StreamWriter(new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write)))
                {
                    foreach (Producto Prod in productos)
                    {
                        sw.WriteLine("{0}|{1}|{2}|{3}|{4}", Prod.Codigo, Prod.Descripcion, Prod.Precio, Prod.Departamento, Prod.Likes);
                    }
                }
            }
            //una posible exepcion
            catch (IOException Er)
            {
                Console.WriteLine("Error al escribir el archivo {0} {1}", archivo, Er.Message);
            }
        }
        //Para escribir archivo tipo binario
        private static void EscribeBIN(string archivo, List<Producto> productos)
        {
            try
            {
                if (!archivo.ToLower().Contains(".bin"))
                    throw new IOException("No se puede (La manera correcta de utilizarse es de esta forma'.bin')");

                using (BinaryWriter bw = new BinaryWriter(new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write)))
                {
                    foreach (Producto Prod in productos)
                    {
                        bw.Write(Prod.Codigo);
                        bw.Write(Prod.Descripcion);
                        bw.Write(Prod.Precio);
                        bw.Write(Prod.Departamento);
                        bw.Write(Prod.Likes);
                    }
                }
            }
            //Posibles excepciones
            catch (IOException Er)
            {
                Console.WriteLine("Error al escribir el archivo {0} {1}", archivo, Er.Message);
            }
        }
        //Seleccionamos el tipo de archivo
        public static List<Producto> Leer(string archivo, FileType Exo = FileType.Text)
        {
            switch (Exo)
            {
                case FileType.Text:
                    return LeerTXT(archivo);

                case FileType.Binary:
                    return LeerBIN(archivo);

                default:
                    return new List<Producto>();
            }
        }
        //Para leer archivo tipo texto
        private static List<Producto> LeerTXT(string archivo)
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                if (!archivo.ToLower().Contains(".txt"))
                    throw new IOException("Formato incorrecto (Formato correcto '.txt')");

                using (StreamReader sr = new StreamReader(archivo))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] columnas = line.Split('|');
                        if (columnas.Length < 5)
                            continue;
                        productos.Add(new Producto(columnas[0], columnas[1], Double.Parse(columnas[2]), int.Parse(columnas[3]), int.Parse(columnas[4])));
                    }

                }
            }
            //Posibles excepciones
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error no se encontro el archivo {0}", archivo);
            }
            catch (IOException Er)
            {
                Console.WriteLine("Error al leer el archivo {0} {1}", archivo, Er.Message);
            }
            return productos;
        }
        //Para leer archivo tipo binario
        private static List<Producto> LeerBIN(string archivo)
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                if (!archivo.ToLower().Contains(".bin"))
                    throw new IOException("Error de formato (El formato correcto es '.bin')");

                using (BinaryReader br = new BinaryReader(new FileStream(archivo, FileMode.Open, FileAccess.Read)))
                {
                    while (br.PeekChar() != -1)
                    {
                        productos.Add(new Producto(br.ReadString(), br.ReadString(), br.ReadDouble(), br.ReadInt32(), br.ReadInt32()));
                    }

                }
            }
            //Posibles excepciones
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error no se encontro el archivo {0}", archivo);
            }
            catch (IOException Er)
            {
                Console.WriteLine("Error al leer el archivo {0} {1}", archivo, Er.Message);
            }
            return productos;
        }
        //Para ordenar por departamento
        public static void GetDepartment(int Depto, string archivo)
        {
            List<Producto> productos;

            if (archivo.ToLower().Contains(".txt"))
            {
                productos = LeerTXT(archivo);
            }
            else if (archivo.ToLower().Contains(".bin"))
            {
                productos = LeerBIN(archivo);
            }
            else
            {
                Console.WriteLine("Formato incorrecto (Formato correcto '.txt')", archivo);
                return;
            }
            
            IEnumerable<Producto> producto =
                from Prod in productos
                where Prod.Departamento == Depto
                select Prod;
            
            Console.WriteLine("Productos del Departamento {0}", Depto);
            //Se asigna un mayor que o menor que para que no pueda ecederse y si lo hace que aparezca que no existe
            if(Depto>4)
            { Console.WriteLine("NO EXISTE ESE DEPARTAMENTO"); }

            foreach (Producto Prod in producto)
            {
                Console.WriteLine("Departamento:{0} Codigo:{1} Producto:'{2}' Su costo es de : ${3} ({4} Likes)", Prod.Departamento, Prod.Codigo, Prod.Descripcion, Prod.Precio, Prod.Likes);
            }
        }
        //Para ordenar por likes
        public static void OrderByLikes(string archivo)
        {
            List<Producto> productos;
            if (archivo.ToLower().Contains(".txt"))
            {
                productos = LeerTXT(archivo);
            }
            else if (archivo.ToLower().Contains(".bin"))
            {
                productos = LeerBIN(archivo);
            }
            else
            {
                Console.WriteLine("No hay sistema (La manera correcta de implementarlo es de esta forma '.txt')", archivo);
                return;
            }

            IEnumerable<Producto> productol =
                from Prod in productos
                orderby Prod.Likes descending
                select Prod;
            
            Console.WriteLine("Productos con mas agrado del publico:");

            foreach (Producto Prod in productol)
            {
                Console.WriteLine("Departamento:{0} Clave:{1} Producto:'{2}' costo: ${3} ({4} Likes)", Prod.Departamento, Prod.Codigo, Prod.Descripcion, Prod.Precio, Prod.Likes);
            }
        }
    }
    class Program
    {
        //Programa Principal
        static void Main(string[] args)
        {
            {
                //Aqui se asigna lo que aparecera en el menu 
                int e;
                int description;
                List<Producto> productos = new List<Producto>();
                productos.Add(new Producto("JARDIN", "Macetas", 15.00d, 1, 82));
                productos.Add(new Producto("JARDIN", "Abono Ultra", 6.25, 1, 80));
                productos.Add(new Producto("JARDIN", "Abono Eco", 3.99d, 1, 72));
                productos.Add(new Producto("JARDIN", "Semillas Shrutte", 14.99d, 1 ,98));
                productos.Add(new Producto("JARDIN", "Semillas Ultra", 13.99d, 1 , 99));
                productos.Add(new Producto("JARDIN", "Aditivo CreceGrow ", 27.50d, 1, 96));
                productos.Add(new Producto("COCINA", "Manual de cocina 'Cualquiera puede cocinar'", 35.99, 2, 4));
                productos.Add(new Producto("COCINA", "Estufa marca Dracarys", 25.99, 2, 78));
                productos.Add(new Producto("COCINA", "Utencilios de cocina marca Boyle", 99.00d, 2, 99));
                productos.Add(new Producto("COCINA", "Juego de cuchillos AmericanP", 99.00d, 2, 91));
                productos.Add(new Producto("COCINA", "Juego de Ceramica", 10.00d, 2, 13));
                productos.Add(new Producto("ELECTRONICOS", "Television Plasma", 356.00d, 3, 89));
                productos.Add(new Producto("ELECTRONICOS", "Television 4K ", 500.99d, 3, 100));
                productos.Add(new Producto("ELECTRONICOS", "Audifonos Beats", 358.99d, 3, 29));
                productos.Add(new Producto("ELECTRONICOS", "Audifonos JBL", 192.45d, 3, 89));
                productos.Add(new Producto("PAPEPELRIA", "Papel Dunder Mifflin (OFERTA)", 13.00d, 4, 205));
                productos.Add(new Producto("PAPEPELRIA", "Papel Dunder Mifflin (OFERTA)", 13.00d, 4, 205));
                productos.Add(new Producto("PAPEPELRIA", "Papel Dunder Mifflin (OFERTA)", 13.00d, 4, 205));
                

                Console.WriteLine("Productos Enlistados");
                Console.WriteLine("");
                foreach (Producto Prod in productos)
                {
                    Console.WriteLine("Departamento:{0} Codigo Asignado:{1} Nombre de su Producto:'{2}' Costo del Producto: ${3} ({4} Likes del producto)",Prod.Departamento,Prod.Codigo, Prod.Descripcion, Prod.Precio, Prod.Likes);
                }
                //Metodo para guardar archivo de texto
                ProductoDB.Escribe(@"productos.txt", productos, FileType.Text);
                //Metodo para guardar archivo binario
                ProductoDB.Escribe(@"productos.bin", productos, FileType.Binary);

                Console.WriteLine("");
                Console.WriteLine("BUEN DIA");
                Console.WriteLine("En que podemos ayudarle el dia de hoy?");
                Console.WriteLine("1.-Ver una lista de nuestros departamentos");
                Console.WriteLine("2.-Ver los productos con mas Likes");
                Console.WriteLine("PRESIONE EL NUMERO A ELEGIR");
                Console.WriteLine("");
                e = int.Parse(Console.ReadLine());

                if(e==1)
                {
                    //Metodo para ordenar por departamento
                    Console.WriteLine("Bienvenido");
                    Console.WriteLine("Presione el numero del departamento que desea");
                    
                    Console.WriteLine("[1]-JARDINERIA");
                    Console.WriteLine("[2]-COCINA");
                    Console.WriteLine("[3]-ELECTRONICOS");
                    Console.WriteLine("[4]-PAPELERIA");
                    
                    Console.WriteLine("");
                    description = int.Parse(Console.ReadLine());
                    ProductoDB.GetDepartment(description, @"productos.txt");

                }
                else if(e==2)
                {
                //Metodo para ordenar por likes
                ProductoDB.OrderByLikes(@"productos.txt");
                }
                else
                {
                    Console.WriteLine("Vuelva a intentarlo");
                }
            }

        }
    }
}
