using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Proyecto2
{
    public class Producto
    {
        //Declaracion de las variables
        public string codigo
         { get; set; }
        public string descripcion 
        { get; set; }
        public double precio 
        { get; set; }
        public int departamento 
        { get; set; }
        public int likes
         { get; set; }

//Asignamos el constructor para la asignacion de valores para cada objeto
        
        public Producto(string code, string description, double price, int depto, int Likes)
        {
             codigo = code; 
             descripcion = description;
             precio = price; 
             departamento = depto; 
             likes = Likes;
        }

        public enum FileType
        {
            Texto,
            Binario
        }
        public  Producto()
        {

        }
        
    }
    //Clase ProductoDB
    public static class ProductoDB
    {
        //Usamos un contructor para nuestro archivo de texto, que usaremos para escribir los datos
        //de los codigos, departamentos, precio, etc.
        public static void EscribeProductosTXT(string archivo, List<Producto> Productos ,FileType FormatoT = FileType.Text )
        {
            switch (FormatoT)
            {
                case FileType.Text:
                    EscribeTXT(archivo, productos);
                    break;

                case FileType.Binary:
                    EscribeBIN(archivo, productos);
                    break;
            }
//Accion para que vea el archivo, abrirlo y escribir en el
            FileStream archivoFS = new FileStream(archivo , FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter txtOut = new StreamWriter(archivoFS);

            foreach(Producto prod in Productos)
            {
                //Nuestro objeto Productos, que lleva la ruta, le asignamos la informacion de 
                //las listas de Producto al archivo producto.txt
             //Y la "prod" esta leyendo la lista de codigos que escribimos
                txtOut.WriteLine(prod.codigo);
                txtOut.WriteLine(prod.descripcion);
                txtOut.WriteLine(prod.precio);
                txtOut.WriteLine(prod.departamento);
                txtOut.WriteLine(prod.likes);
            }
            //Para cerrar la lista de informacion
            txtOut.Close();
        }
        //Leer producto TXT
        public static List<Producto> LeeProductosTXT(string archivo)
        {
            //Lista para leer los producto que se encuetran en el archivo productos.txt
        List<Producto> Productos = new List<Producto>();     
        FileStream archivoFS = new FileStream(archivo , FileMode.Open, FileAccess.Read);   
//Metodo que se utilia para leer los archivos
        using( StreamReader txtIn = new StreamReader(archivoFS))
        {
            while( txtIn.Peek() != -1 )
            {//Lectura de las variables de la clase Productos
                Producto producto = new Producto();
                producto.codigo = txtIn.ReadLine();
                producto.descripcion = txtIn.ReadLine();
                producto.precio = txtIn.Read();
                producto.departamento = txtIn.Read();
                producto.likes = txtIn.Read();
                Productos.Add(producto);
            }
        }
        return Productos;
        }
        //Escribimos el archivo en Binario
        public static void EscribeProductosBIN(string archivo, List<Producto> Productos)
        {
            FileStream archivoFS= new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter binOut = new BinaryWriter(archivoFS);
            foreach(Producto prod in Productos)
            {
                //Nuestro objeto Productos, que lleva la ruta, le asignamos la informacion de 
                //las listas de Producto al archivo producto.txt, pero ahora a binario
             //Y la "prod" esta leyendo la lista de codigos que escribimos
                binOut.Write(prod.codigo);
                binOut.Write(prod.descripcion);
                binOut.Write(prod.precio);
                binOut.Write(prod.departamento);
                binOut.Write(prod.likes);
            }
            binOut.Close();
        }
        
    }
    class Program
    {

        static void Main(string[] args)
        {
            
            
            //Lista para agregar la informacion
            List<Producto> Productos = new List<Producto>();
            //Info va en orden(codigo, descripcion, precio, Departamento, Likes)
            Productos.Add(new Producto("BASICOS"+"\n", "Guantes , Guias "+"\n", 13.00 , 3 , 130));

            Productos.Add(new Producto("FUERA"+"\n", "Pala Picos , Rastrillos"+"\n", 50.200 , 3 , 543));

            Productos.Add(new Producto("SEMILLA Y PLANTAS"+"\n", "Pasto Girasol Rosales"+"\n", 2.000, 4 , 21));
            
            Productos.Add(new Producto(" MACETA Y ABONO "+"\n" , "Maceta de Plastico Maceta de ceramica"+"\n", 37.000, 1 , 100));
            //Transmite la informacion anterior a texto
            ProductoDB.EscribeProductosTXT(@"Productos.txt", Productos);
            //Transmite la informacion anterior a Binario
            ProductoDB.EscribeProductosBIN(@"Productos.txt", Productos);


            //Lecturas del archivo 
            //Imprime de lectura TXT
            List<Producto> productos_leidos = ProductoDB.LeeProductosTXT("Productos.txt");

                foreach(Producto p in productos_leidos)
                {    
                    Console.WriteLine(p.codigo);
                    Console.WriteLine(p.descripcion);
                    Console.WriteLine(p.precio);
                    Console.WriteLine(p.departamento);
                    Console.WriteLine(p.likes);
                }
            

        }
    }
}
