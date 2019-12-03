using System;

namespace Musico
{
  
    class Musico
    {
        protected string nombre;

        public Musico(string n)
        {
            nombre = n;
        }

        public virtual void Afina()
        {
            Console.WriteLine("{0} Afinando el instrumento", nombre);
        }

        public string Saluda()
        {
            return string.Format("Me presento soy {0}", nombre);
        }
        public void Tocar()
        {
            Console.WriteLine("{0} Comienza a tocar", nombre);
        }
    }
    class Baterista : Musico
    {
        private string baquetas;

        public Baterista(string no, string b) : base(no)
        {
            baquetas = b;
        }
        public override void Afina()
        {
            Console.WriteLine("{0} Preparando sus {1}", nombre, baquetas);
        }
        
    }
    class Bajista : Musico
    {
        private string bajo;

        public Bajista(string no, string b) : base(no)
        {
            bajo = b;
        }
        public override void Afina()
        {
            Console.WriteLine("{0} Afinando su {1}", nombre, bajo);
        }
    }
    class Guitarrista : Musico
    {
        private string guitarra;

        public Guitarrista(string no, string g) : base(no)
        {
            guitarra = g;
        }
        public override void Afina()
        {
            Console.WriteLine("{0} Afinando su {1}", nombre, guitarra);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Musico tom = new Musico("Jhon");
            Bajista flea = new Bajista("Flea", "Moicarca");
            Guitarrista john = new Guitarrista("John", "Sizer");
            Baterista mike = new Baterista("Mike", "Ramirez");

            List<Musico> grupo = new List<Musico>();
            grupo.Add(tom);
            grupo.Add(flea);
            grupo.Add(john);
            grupo.Add(mike);

            foreach (Musico m in grupo)
            {
                Console.WriteLine(m.Saluda());
                m.Afina();
            }
            Console.WriteLine("");
            foreach (Musico m in grupo)
            {
                
                m.Tocar();
            }
        }
        
    }
  }
