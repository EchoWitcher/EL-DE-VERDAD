using System;

namespace Espias
{
    public string nombre;
    public string apellido;
{
    class Persona
    public string nombre;
    public string apellido;
}
    public Persona()
    {
        nombre = "Fulani";
        apellido = "De tal";
    }
    class Anonymous {
        static void anonimiza (Persona p )
        {
            p.nombre = "-------";
            p.apellido = "-------";
        }
    }
    {
        class Program
        {
           public static void Main (string[]args)
            {
                Persona p = new Persona();
                Console.Writeline(p.nombre);

                Anonymous.anonimiza(p);
            }
        }
    }
}
