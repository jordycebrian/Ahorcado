using System;

namespace Ahorcado
{
    class Program
    {
        static void Main()
        {
            //variable para interaccion
            string opcion = "";
            while (opcion != "salir")
            {
                //dibujando el menu y presentacion
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("                          +--------+        ");
                Console.WriteLine("                          |        |");
                Console.WriteLine(" Juego del Ahorcado       O        |");
                Console.WriteLine("                        / | \\      |");
                Console.WriteLine("                         / \\       |");
                Console.WriteLine("                                   |");
                Console.WriteLine("=============================================");
                Console.WriteLine("      ***Opciondes del juego***");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("   -Escribe \"salir\" para dejar el juego");
                Console.WriteLine("   -Escribe \"iniciar\" para empezar el juego");
                Console.WriteLine("               ");
                Console.WriteLine("--------------------------------------------");

                //entrada de opciones
                Console.Write("Que deseas realizar > ");
                opcion = Console.ReadLine();
                if (opcion == "iniciar")
                {
                    Logica.ComenzarAhorcado();
                }
            }
        }
    }
}
