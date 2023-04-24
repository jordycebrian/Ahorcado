using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado
{
    public class Logica
    { 
        public static void ComenzarAhorcado()
        {
            try
            {

                Console.Clear();
                //Dibujar el ahorcado en su etapa inicial
                Console.WriteLine("El juego ha comenzado");
                Console.WriteLine("\t  +---+");
                Console.WriteLine("\t  |   |");
                Console.WriteLine("\t      |");
                Console.WriteLine("\t      |");
                Console.WriteLine("\t      |");
                Console.WriteLine("\t      |");
                Console.WriteLine("\t=========\n\n");
                Console.WriteLine("\n");

                //definir variables
                bool adivinoLetra = false;//
                string letrasIngresadasPorUsuario = "";
                int intentosFallidos = 0;

                //lista frases aleatorias y tomando una al azar
                List<string> listaFrases = new() 
                { 
                    
                    "no todo lo que brilla es oro",
                    "el pez por su boca muere",
                    "hijo de tigre pintito",
                    "no todo lo que brilla es oro",
                    "nunca digas nunca",
                };
                Random rnd = new Random();
                int indiceAleatorio = rnd.Next(listaFrases.Count);
                string fraseCorrecta = listaFrases[indiceAleatorio];
                string letrasConGuiones = new string('_', fraseCorrecta.Length);


                //crear una lista con cada parte del dibujo del ahorcado
                List<string> partesMuñeco = new List<string>() {
                                "  +---+\n",   // parte 1: soporte
                                "  |   |\n",  // parte 2: cabeza
                                "  O   |\n",
                                " /|\\  |\n",
                                " / \\  |\n",
                                "      |\n",  // parte 6: piernas
                };

                
                //Mostrar las opciones de menu
                Console.WriteLine("\nEscribe \"try\" para intentar escribir la frase completa");
                Console.WriteLine("Escribe \"salir\" para dejar el juego\n");

                Console.WriteLine("Introduce una letra para empezar");
                //inicia el ciclo del juego
                while (true)
                {


                    //pedir al usuario que ingrese una letra
                    Console.Write("\nIngresa aqui tus opciones > ");
                    letrasIngresadasPorUsuario = Console.ReadLine().ToLower();

                    
                    //comprovar si el usuario quiere salir del juego
                    if (letrasIngresadasPorUsuario == "salir")
                    {

                        //despedida y saliendo del programa, read para que no nos saque inmediatamente
                        Console.WriteLine("Grcaias por jugar :C");
                        Console.WriteLine("Presiona enter para salir");
                        Console.ReadLine();
                        break;

                    }
                    //comprobar si el usuario quiere escribir la frase completa
                    else if (letrasIngresadasPorUsuario == "try")
                    {
                       
                        Console.WriteLine("Introduce la frase completa ");
                        letrasIngresadasPorUsuario = Console.ReadLine().ToLower();
                        if (letrasIngresadasPorUsuario == fraseCorrecta)
                        {
                            
                            Console.WriteLine("Felicidades lo has completado presion enter para salir");
                            Console.WriteLine("Presiona enter para salir");
                            Console.ReadLine();
                            break;

                        }
                        else
                        {

                            Console.WriteLine("\nLo siento, la frase que se ha introducido no es la correcta");
                            continue;

                        }
                    }
                    //comprovar si el usuario ha ingresado más de una letra
                    else if (letrasIngresadasPorUsuario.Length > 1)
                    {
                        
                        if (letrasIngresadasPorUsuario == fraseCorrecta)
                        {

                            Console.WriteLine("Felicidades lo has completado :)");
                            Console.WriteLine("Presiona enter para salir");
                            Console.ReadLine();
                            break;

                        }
                        else
                        {

                            Console.WriteLine("Lo siento, la frase que has introducido es correcta");
                            continue;


                        }
                        
                    }
                    else
                    {
                        //tomando el valor inicial de la entrada y guardarlo en una variable
                        char letraActual = letrasIngresadasPorUsuario[0];
                        adivinoLetra = false;

                        for (int i = 0; i < fraseCorrecta.Length; i++)
                        {

                            if (fraseCorrecta[i] == letraActual)
                            {

                                //remplasando los guiones por la letra entrante y mostrar la cadena letras con guiones para mostrar avanze en la frase
                                letrasConGuiones = letrasConGuiones.Substring(0, i) + letraActual + letrasConGuiones.Substring(i + 1);
                                adivinoLetra = true;

                            }
                            else if (fraseCorrecta[i] == ' ')
                            {

                                letrasConGuiones = letrasConGuiones.Substring(0, i) + " " + letrasConGuiones.Substring(i + 1);


                            }

                        }
                        if (adivinoLetra)
                        {
                            
                            Console.WriteLine("\n¡Adivinaste una letra!");
                            Console.WriteLine(letrasConGuiones);
                            letrasIngresadasPorUsuario += letraActual.ToString();
                            
                        }
                        else
                        {
                            
                            Console.WriteLine("\nERROR!! Letra equivocada");
                            //si la letra ya se ha ingresado antes, no se agrega nada
                            letrasIngresadasPorUsuario += letrasIngresadasPorUsuario.Contains(letraActual.ToString()) ? "" : letraActual.ToString();
                            intentosFallidos++;
                            if (intentosFallidos < 6)
                            {

                                //mostrar muñeco ahorcado segun incremente formara el muñeco
                                for (int i = 0; i < intentosFallidos; i++)
                                {

                                    Console.WriteLine(partesMuñeco[i]);

                                }

                            }
                            if (intentosFallidos >= 6)
                            {

                                Console.WriteLine("\nSe terminaron tus intentos :/ gracias por jugar :)");
                                Console.WriteLine("Presiona enter para salir");
                                Console.ReadLine();
                                break;

                            }
                            
                            
                           
                        }

                        //si ya no hay guiones bajos
                        if (letrasConGuiones.IndexOf('_') == -1)
                        {
                            
                            Console.WriteLine("\n¡Felicidades! Has adivinado la frase.");
                            Console.WriteLine("Presiona enter para salir");
                            Console.ReadLine();
                            break;

                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Se produjo un error: " + ex.Message);
                Console.WriteLine("Presiona enter para salir");
                Console.ReadLine();
            }
            
        }
    }
}
