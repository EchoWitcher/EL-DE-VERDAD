using System;

namespace Actores
{
    class Program
    {
        
    class Pelicula
    {
        private String Titulo;
        private Int16 Año;
        private String Pais;
        private String Director;

        private List<Actor> actores = new List<Actor>();

        public void AgregarActor(Actor actor)
        {
            actores.Add(actor);
        }

        public void ImprimeActor()
        {
            foreach (Actor Actor in actores)
            {
                Console.WriteLine("{0}({1})", Actor.Nombre, Actor.Año);
            }
        }

        public void SetTitulo(string titulo)
        {
            this.Titulo = titulo;
        }

        public String GetTitulo()
        {
            return this.Titulo;
        }

        public void SetAño(Int16 año)
        {
            this.Año = año;
        }

        public Int16 GetAño()
        {
            return this.Año;
        }

        public void SetDirector(string director)
        {
            this.Director = director;
        }

        public String GetDirector()
        {
            return this.Director;
        }

        public void SetPais(string pais)
        {
            this.Pais = pais;
        }

        public String GetPais()
        {
            return this.Pais;
        }

        public Pelicula()
        {

        }
        public Pelicula(string titulo, Int16 año, string director, string pais)
        {
            this.Titulo = titulo;
            this.Año = año;
            this.Director = director;
            this.Pais = pais;
        }
        

    }
    class Actor
    {
        public string Nombre;
        public Int16 Año;

        public Actor(string nombre, Int16 año)
        {
           this.Nombre = nombre;
           this.Año = año;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Pelicula p1 = new Pelicula();
            Pelicula p2 = new Pelicula();

            p1.SetTitulo("Megamente");
            p1.SetAño(2006);
            p1.SetDirector("Emma Thompson");
            p1.SetPais("Estados Unidos");
            p1.AgregarActor(new Actor("Will smith", 1972));
            p1.AgregarActor(new Actor("Jim Carrey", 1982));
            Console.WriteLine("{0}, {1}, {2}, {3}\n", p1.GetTitulo(), p1.GetAño(), p1.GetDirector(), p1.GetPais());
            p1.ImprimeActor();

            Console.WriteLine("");

            p2.SetTitulo("Transformers");
            p2.SetAño(2009);
            p2.SetDirector("Michael Bay");
            p2.SetPais("Usa");
            p2.AgregarActor(new Actor("Chia Labeouf", 1974));
            p2.AgregarActor(new Actor("Meghan Fox", 1971));
            Console.WriteLine("{0}, {1}, {2}, {3}\n", p2.GetTitulo(), p2.GetAño(), p2.GetDirector(), p2.GetPais());
            p2.ImprimeActor();

        }
    }
}}

