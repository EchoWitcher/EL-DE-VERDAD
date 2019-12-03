using System;

namespace Lista_de_alumnos
{
    abstract class Alumnos
    {
        protected string nombre,apellido;
        protected int id;
        

        public Alumnos(string nombre,string apellido,int id)
        {
            this.nombre=nombre;
            this.apellido=apellido;
            this.id=id;
        }
        public void Datos()
        {
            Console.WriteLine("Alumno {0} {1} con numero de control:{2}", nombre, apellido, id);
            Console.WriteLine("Debes realizar tu servicio  y Acabando podras realizar tu residencia");
        }
    }
    class Licenciatura:Alumnos
    {
        public Licenciatura(string nombre, string apellido, int id):base(nombre,apellido,id)
        {

        }
    }
    class Posgrado : Alumnos
    {
        public Posgrado(string nombre, string apellido, int id) : base(nombre, apellido, id)
        {

        }
        new public void Datos()
        {
            Console.WriteLine("Alumno {0} {1} con numero de control:{2}", nombre, apellido, id);
            Console.WriteLine("Se requiere que realizes la investigacion de campo");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Licenciatura frank = new Licenciatura("Frank","Moses",1335813);
            Posgrado eleanor = new Posgrado("Eleanor", "Rigby", 17210450);

            frank.Datos();
            Console.WriteLine("");
            eleanor.Datos();


            
           
        }
    }   
}
