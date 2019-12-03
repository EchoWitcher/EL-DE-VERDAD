using System;

namespace Dominoes
{

    class Dominoe
    {
        private readonly int ladoA=0;
        private readonly int ladoB=0;

        public Dominoe(int ladoarriba, int ladoabajo)

        {
            ladoA=ladoarriba;
            ladoB= ladoabajo;

        }

        public static int operator + (Dominoe a, Dominoe b)
        {
            return(a.ladoA + a.ladoB + b.ladoA +b.ladoB);
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
           Dominoe a= new Dominoe(6,2);
           Dominoe b= new Dominoe(5,1);
           Console.WriteLine(a+b);
            
        }
    }
}