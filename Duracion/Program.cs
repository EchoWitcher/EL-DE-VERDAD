using System;

namespace Duracion
{
    class Duracion
    {
        public int horas;
        public int minutos;
        public int segundos;

        public Duracion(int h, int m, int s)
        {
            this.horas=h;
            this.minutos=m;
            this.segundos=s;
        }

        public void print ()
        {
            Console.WriteLine(" Horas:"+horas+ " Minutos:"+minutos+" Segundos:"+segundos);       
        }

        public void conversiones()
        {
            minutos=(horas*60)+minutos;
            segundos=(minutos*60)+(horas*60*60)+segundos;

            Console.WriteLine("En minutos es:"+minutos);
            Console.WriteLine("En segundos son:"+segundos);
        }

        public void converciones_segundos()
        {
            int Horas_segundos, Minutos_segundos;

            Horas_segundos=segundos/3600;
            Minutos_segundos=segundos/60;

            Console.WriteLine("LA cantidad de segundos en horas es de:"+Horas_segundos);
            Console.WriteLine("La cantidad de seundos a minutos es:"+Minutos_segundos);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Duracion a= new Duracion(2,15,12);
            Duracion b= new Duracion(00,02,15);
            Duracion c= new Duracion(2,00,10);
            Duracion d= new Duracion(0,0,34576);

            a.print();
            a.conversiones();
            Console.WriteLine("\t");

            b.print();
            b.conversiones();
            Console.WriteLine("\t");

            c.print();
            c.conversiones();
            Console.WriteLine("\t");

            d.converciones_segundos();

            
           
           
        }
    }
}
