using System;

namespace Herencia_Musico
{
    class Musico_Herencia
    {
        protected string nombre;
        public Musico_Herencia (string n)
        {
            nombre =n;
        }

        public void Afina ()
        {
            Console.WriteLine("{0} afinando su instrumento");
        }

        public void Saluda ()
        {
            Console.WriteLine("Hola soy {0}", nombre);
        }
    }

    class Bajista:Musico_Herencia
    {
        private string bajo;
        public Bajista (string no, string b):base (no)
        {
            bajo=b;
        }
        
        public void Afina()
        {
            Console.WriteLine("{0} afinando su {1}",nombre,bajo);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Musico_Herencia tom= new Musico_Herencia("Tom");
            Bajista flea = new Bajista("Flea", "Musican");
            tom.Saluda(); flea.Saluda();
            tom.Afina(); flea.Afina();  

            List <Musico_Herencia> grupo = new List<Musico_Herencia>();
            grupo.add(tom);
            grupo.add(flea);

            foreach(Musico_Herencia m in grupo)
            {
                m.Saluda();
                m.Afina();
            }
        }
    }
}
