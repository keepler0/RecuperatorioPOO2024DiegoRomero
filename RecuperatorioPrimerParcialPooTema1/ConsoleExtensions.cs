using System.Globalization;

namespace RecuperatorioPrimerParcialPooTema1
{
    public static class ConsoleExtensions
    {
        public static string ReadString(string message)
        {
            string? stringVar = string.Empty;
            while (true)
            {

                Console.Write(message);
                stringVar = Console.ReadLine();
                if (stringVar == null)
                {
                    Console.WriteLine("Debe ingresar algo!!!");
                }
                else
                {
                    break;
                }
            }
            return stringVar;
        }

        public static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número entero válido.");
                }
            }
        }
        public static int ReadShort(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (short.TryParse(input, out short result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número entero válido.");
                }
            }
        }

        public static int ReadInt(string message, int min, int max)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result) && (result >= min && result <= max))
                {
                    return result;

                }
                else
                {
                    Console.WriteLine($"Por favor, ingrese un número entero válido o dentro del rango ({min}-{max}).");
                }
            }
        }
        public static double ReadDouble(string message, CultureInfo culture)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (double.TryParse(input, NumberStyles.Float, culture, out double result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número double válido.");
                }
            }
        }

        public static double ReadDouble(string message, CultureInfo culture, int min, int max)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (double.TryParse(input, NumberStyles.Float, culture, out double result) && (result >= min && result <= max))
                {
                    return result;

                }
                else
                {
                    Console.WriteLine($"Por favor, ingrese un número double válido o dentro del rango ({min}-{max}).");
                }
            }
        }

        public static decimal ReadDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número decimal válido.");
                }
            }
        }

        public static decimal ReadDecimal(string message, int min, int max)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal result) && (result >= min && result <= max))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine($"Por favor, ingrese un número decimal válido o dentro del rango ({min}-{max}).");
                }
            }
        }


        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        /// <summary>
        /// Método para mostrar un mensaje y validar que el 
        /// caracter ingresado sea uno de la lista suministrada
        /// </summary>
        /// <param name="message">Mensaje que sale en pantalla</param>
        /// <param name="options">Listado de caracteres aceptados</param>
        /// <returns>El caracter ingresado luego de la validación</returns>
        public static char GetValidOptions(string message, List<char> options)
        {
            char answer;
            do
            {
                Console.Write(message);
                answer = Console.ReadKey().KeyChar;//Lee el caracter tipiado en la consola y lo convierte a char
                if (!options.Any(x => x.Equals(answer)))
                {
                    Console.WriteLine("Ingreso no válido... Otra vez!!!");
                }
                else
                {
                    /*
                     * Si la opción tipiada es alguna de la lista, salgo del ciclo
                     */
                    break;

                }

            } while (!options.Any(x => x.Equals(answer)));// mientras no sea un caracter válido me quedo esperando
            return answer; //retorno el caracter ingresado y validado.
        }
        public static void EsperarPresionDeTecla(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }

    }

}
