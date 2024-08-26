namespace Ejercicio4.Entidades
{
    public class NumeroDivDosTres
    {
        private int valor;

        public NumeroDivDosTres(int valor)
        {
            this.valor = valor;
        }
        public int GetValor() => valor;
        public bool EsValido()
        {
            return valor%2==0 && valor%3==0;
        }

        public override string ToString()
        {
            return $"{valor}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is NumeroDivDosTres np)) return false;
            return valor == np.valor;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                return hash += 23 * valor.GetHashCode();
            }
        }
        public static bool operator ==(NumeroDivDosTres a, NumeroDivDosTres b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(NumeroDivDosTres a, NumeroDivDosTres b)
        {
            return !(a == b);
        }

    }
}
