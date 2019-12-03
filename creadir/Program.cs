using System;

namespace creadir
{
    class Producto
    {
        public string codigo, descripcion;
        public double precio;

        public Producto(string c, string d, double p) 
        {
            codigo = c; descripcion = d; precio = p;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Producto> productos = new List<Producto>();

            productos.Add(new Producto("AQW","Lapiz Azul w2",12.23));
            productos.Add(new Producto("AQW","Lapiz Verde w2",12.23));
            productos.Add(new Producto("AQW","Pluma Roja w2",12.23));
            productos.Add(new Producto("AQW","Plumon w2",12.23));
        
            FileStream fs = new FileStream(@"productos.txt",FileMode.OpenOrCreate,FieldAccessException.Write);
            StreamWriter txtOut = new StreamWriter(fs);

            foreach(Producto p in productos)
            {
                txtOut.Write(p.descripcion + " ");
                txtOut.WriteLine(p.precio);

            }

            fs.Close();
            
        }
    }
}
