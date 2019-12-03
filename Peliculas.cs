class Program 
{
static void Main()
{
    Pelicula p1 = new Pelicula();
    Pelicula2 p2 = new Pelicula2();
    p1.SetTitulo("Spiderman Universe");
    p1.SetAño(2018); 
    p2.SetTitulo("Nacio una estrella");
    p2.SetAño(2018); 
    Console.WriteLine("{0}({1})", p1.GetTitulo(), p1.GetAño());
    Console.WriteLine("{0}({2})", p2.GetTitulo(), p2.GetAño());
}
} 
