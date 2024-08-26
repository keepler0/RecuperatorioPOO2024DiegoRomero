
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Ejercicio4.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var repositorio = new RepositorioNumerosDivDosTres();
            //bool salir = false;

            //while (!salir)
            //{
            //    Console.WriteLine("\nMenú de Opciones:");
            //    Console.WriteLine("1. Agregar Número Perfecto");
            //    Console.WriteLine("2. Quitar Número Perfecto");
            //    Console.WriteLine("3. Listar Números Perfectos");
            //    Console.WriteLine("4. Buscar Número Perfecto");
            //    Console.WriteLine("5. Sumar Números Perfectos en el Repositorio");
            //    Console.WriteLine("6. Salir");
            //    Console.Write("Seleccione una opción: ");

            //    switch (Console.ReadLine())
            //    {
            //        case "1":
            //            Console.Write("Ingrese el número perfecto a agregar: ");
            //            if (int.TryParse(Console.ReadLine(), out int valorAgregar))
            //            {
            //                var numero = new NumeroDivDosTres(valorAgregar);
            //                var resultado = repositorio.Agregar(numero);
            //                Console.WriteLine(resultado.Item2);
            //            }
            //            else
            //            {
            //                Console.WriteLine("Valor inválido.");
            //            }
            //            break;

            //        case "2":
            //            Console.Write("Ingrese el número perfecto a quitar: ");
            //            if (int.TryParse(Console.ReadLine(), out int valorQuitar))
            //            {
            //                var numero = new NumeroDivDosTres(valorQuitar);
            //                var resultado = repositorio.QuitarNumero(numero);
            //                Console.WriteLine(resultado.Item2);
            //            }
            //            else
            //            {
            //                Console.WriteLine("Valor inválido.");
            //            }
            //            break;

            //        case "3":
            //            Console.WriteLine("\nNúmeros Perfectos en el Repositorio:");
            //            Console.WriteLine(repositorio.MostrarNumeros());
            //            break;

            //        case "4":
            //            Console.Write("Ingrese el número perfecto a buscar: ");
            //            if (int.TryParse(Console.ReadLine(), out int valorBuscar))
            //            {
            //                NumeroDivDosTres numero = new NumeroDivDosTres(valorBuscar);
            //                var resultado = repositorio.BuscarNumero(numero);
            //                if (resultado.Item1)
            //                {
            //                    Console.WriteLine($"Número encontrado en la posición {resultado.Item2}");
            //                }
            //                else
            //                {
            //                    Console.WriteLine("Número no encontrado.");
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine("Valor inválido.");
            //            }
            //            break;

            //        case "5":
            //            int suma = repositorio;
            //            Console.WriteLine($"La suma de los números perfectos es: {suma}");
            //            break;

            //        case "6":
            //            salir = true;
            //            break;

            //        default:
            //            Console.WriteLine("Opción inválida.");
            //            break;
            //    }
            //    }
        }
    }
    public class NumeroDivDosTres
    {
        private int _valor;

        public NumeroDivDosTres(int valor)
        {
            if (!Validar(valor))
            {
                throw new Exception("El valor debe ser divisible por 2 o 3");
            }
            _valor = valor;
        }

        public int Valor
        {
            get { return _valor; }
            set 
            {
                if (!Validar(value))
                {
                    throw new Exception("El valor debe ser divisible por 2 o 3");
                }
                _valor = value; 
            }
        }
        public bool Validar(int valor) => valor % 2 == 0 || valor % 3 == 0 ? true : false;
        public static bool operator ==(NumeroDivDosTres n,NumeroDivDosTres n1)
        {
            if (n is null || n1 is null) return false;
            return n.Valor == n1.Valor;
        }
        public static bool operator !=(NumeroDivDosTres n, NumeroDivDosTres n1) => !(n == n1);
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (this.Equals(obj))return true;
            if (this.GetType() != obj.GetType()) return false;
            return this == (NumeroDivDosTres)obj;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 23;
                hash += 17 * _valor.GetHashCode();
                return hash;
            }
        }
        public override string ToString() => $"Valor: {_valor}";
    }
    public class RepositorioNumeros
    {
        private int _cantidad;
        private NumeroDivDosTres[]? _numeros;

        public int Cantidad { get => _cantidad; private set => _cantidad = value; }
        public RepositorioNumeros():this(5)
        {
            _numeros = new NumeroDivDosTres[_cantidad];
        }
        public RepositorioNumeros(int cantidad)
        {
            if (cantidad < 0) throw new Exception("El valor de la cantidad debe ser mayor a cero");
            _cantidad = cantidad;
            _numeros = new NumeroDivDosTres[_cantidad];
        }
        private bool ArrayVacio() => RecorrerArray() == 0 ? true : false;
        private bool ArrayLleno() => RecorrerArray() == _cantidad ? true : false;
        private int RecorrerArray()
        {
            if (_numeros is null) return 0;
            int contador = 0;
            foreach(var item in _numeros)
            {
                if (item is not null) contador++;
            }
            return contador;
        }
        public bool Existe(NumeroDivDosTres n)
        {
            if (n is null || _numeros is null) return false;
            foreach (var item in _numeros)
            {
                if (item is not null && item == n) return true;
            }
            return false;
        }
        public Tuple<bool,string> Agregar(NumeroDivDosTres n)
        {
            if (n is null ||_numeros is null) return new Tuple<bool,string>(false,"objeto con valor null");
            if (ArrayLleno()) return new Tuple<bool, string>(false, "Array lleno");
            for (int i = 0; i < _numeros.Length; i++)
            {
                if (_numeros[i] is null)
                {
                    _numeros[i] = n;
                    return new Tuple<bool, string>(true, "Número agregado");
                }
            }
            return new Tuple<bool, string>(false, "No ha sido posible agregar el número");
        }
        public Tuple<bool,string>Borrar(NumeroDivDosTres n)
        {
            if (n is null || _numeros is null) return new Tuple<bool, string>(false, "objeto con valor null");
            if (ArrayVacio()) return new Tuple<bool, string>(false, "Array vacío");
            for (int i = 0; i < _numeros.Length; i++)
            {
                if (_numeros[i] is not null && _numeros[i]==n)
                {
                    _numeros[i] = null;
                    return new Tuple<bool, string>(true, "Número eliminado del array");
                }
            }
            return new Tuple<bool, string>(false, "No ha sido posible eliminar el número");
        }
        public NumeroDivDosTres? GetNumero(int index)
        {
            if (index > _cantidad || index<0) throw new Exception("Valor supera el rango del array");
            if (ArrayVacio()) throw new Exception("Array vacío");
            return _numeros[index] ?? null;
        }
        public string MostrarArray()
        {

            var sb = new StringBuilder();
            if (ArrayVacio())
            {
                sb.AppendLine("Aun no se ha guardado ningun objeto");
                return sb.ToString();
            }
            foreach (var item in _numeros)
            {
                if (item is not null)
                {
                    sb.AppendLine(item.ToString());
                }
                else
                {
                    sb.AppendLine("Elemento nulo");
                }
            }
            return sb.ToString();
        }
        public Tuple<bool,int>SearchNum(NumeroDivDosTres n)
        {
            if (n is null || _numeros is null) return new Tuple<bool, int>(false, -1);
            if (ArrayVacio()) return new Tuple<bool, int>(false, -1);
            for (int i = 0; i < _numeros.Length; i++)
            {
                if (_numeros[i]is not null && _numeros[i]==n)
                {
                    return new Tuple<bool, int>(true, i);
                }
            }
            return new Tuple<bool, int>(false, -1);
        }
        public static implicit operator int(RepositorioNumeros repo) 
        {
            int suma = 0;
            for (int i = 0; i < repo._numeros.Length; i++)
            {
                if (repo._numeros[i] is not null)
                {
                    suma += repo._numeros[i].Valor; 
                }
            }
            return suma;
        }
    }
}
