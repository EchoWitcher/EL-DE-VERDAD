using System;

namespace Lista_Peliculas
{

    class Program
    {
        static void Main(string[] args)
        {
            List<String> lista =new List<String>();
                lista.Add("Megamente");
                lista.Add("Planeta del tesoro");
                lista.Add("Invader Zim (into the florpus)");
                lista.Add("Now you see me");
                lista.Add("El exorcista");

           foreach(String Pelicula in lista)
                Console.WriteLine(Pelicula);
        }
    }
}
