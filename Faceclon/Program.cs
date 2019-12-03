using System;

namespace Faceclon
{
    abstract class Publicacion
    {
        protected string nombre;
        protected int fecha;
        protected int reacciones;

        public Publicacion(string nombre, int fecha, int reacciones)
        {
            this.nombre = nombre;
            this.fecha = fecha;
            this.reacciones = reacciones;
        }

        public abstract void imprime();

    }

    class Estado : Publicacion
    {
        public string mensaje = "";

        public Estado(string nombre, int fecha, int reacciones, string mensaje):base(nombre,fecha,reacciones)
        {
            this.mensaje = mensaje;
        }

        override public void imprime()
        {
            Console.WriteLine("Estado de {0} del año {1} \n {2} \n {3} reacciones", nombre,fecha,mensaje,reacciones);
        }

    }

    class Foto : Publicacion
    {
        public string foto="";
        public string titulo="";

        public Foto(string nombre, int fecha, int reacciones, string titulo, string foto):base(nombre, fecha, reacciones)
        {
            this.titulo = titulo;
            this.foto = foto;
        }

        override public void imprime()
        {
            Console.WriteLine("Foto de {0} del año {1} \n {2} \n {3} \n {4} reacciones", nombre,fecha,titulo,foto,reacciones);
        }

    }

    class Link : Publicacion
    {
        string link;
        string titulo;

        public Link(string nombre, int fecha, int reacciones,string titulo, string link) : base(nombre, fecha, reacciones)
        {
            this.titulo = titulo;
            this.link = link;
        }

        override public void imprime()
        {
            Console.WriteLine("Link de {0} del año {1} \n {2} \n {3} \n {4} reacciones", nombre, fecha,titulo,link,reacciones);
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Publicacion> muro = new List<Publicacion>();
            muro.Add(new Estado("Rein Goldstein", 2017, 45, "Hoy acaba Game of Thrones"));
            muro.Add(new Estado("Jack Harnes", 2005, 13, "ME siento muy mal"));
            muro.Add(new Link("Meryl Strip", 2004, 238, "La mejor cancion de donna","www.youtube.com/heavens-divide-donna-burke"));
            muro.Add(new Foto("Liquid Snake", 2017, 140, "Con la familia en las vegas","las_vegas_nevada23"));
            muro.Add(new Link("Solidus Snake", 2003, 237, "Programa metal gear JAck"));
            muro.Add(new Foto("Roy Campbell", 2002, 240, "Comenzando con toda la actitud", "actitud.png"));

            foreach (var item in muro)
            {
                item.imprime();
                Console.WriteLine();
            }
            
        }
    }
}