using System;

namespace Parametros
{class Valor
    {
        public void Alcuadrado(int a)
        {
            a = a * a;
        }
        public void AlcuadradoR(ref int a)
        {
            a = a * a;
        }
        public void Alcuadrado(in int a)
        {
            a = a * a;
            Console.WriteLine(a);
        }
        public void Suma(int a, int b, out int resultado)
        {
            resultado = a + b;
        }
    }
    class Empleado
    {
        public string Puesto;

        public Empleado()
        {
            Puesto = "Manager";
        }
        
    }
    class Ascensos
    {
        static public void Mejorar_Puesto(Empleado x)
        {
            x.Puesto = "Jefe";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int x = 2;
            int y = 3;
            int z;
            
            
            Valor n = new Valor();
            n.Alcuadrado(x);
            Console.WriteLine(x);

            
            Empleado Enrique = new Empleado();
            Console.WriteLine(Enrique.Puesto);
            Ascensos.Mejorar_Puesto(Enrique);
            Console.WriteLine(Enrique.Puesto);

            
            n.AlcuadradoR(ref y);
            Console.WriteLine(y);

            
            n.Suma(x, y, out z);
            Console.WriteLine(z);

            
            n.Alcuadrado(in z);
            
        }
    }
}
