using System;

namespace ConsoleApplication
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // nao altere essa linha...
            int?[] numerosDesordenados = { 3, 4, 1, 10, null, 5, 2, null, 3, 5, -10, -9, 5 };

            try
            {
                Console.WriteLine("Numeros desordenados:");
                mostrarNumeros(numerosDesordenados);

                Console.WriteLine();

                var numerosOrdenados = ordenarNumeros(numerosDesordenados);

                Console.WriteLine("Numeros ordenados:");
                mostrarNumeros(numerosOrdenados);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static int?[] ordenarNumeros(int?[] numeros)
        {
            for (var i = 0; i < numeros.Length; i++)
            {
                if (!numeros[i].HasValue)
                    continue;

                for (var j = i + 1; j < numeros.Length; j++)
                {
                    if (!numeros[j].HasValue)
                        continue;

                    if (comparar(numeros[j].Value, numeros[i].Value) == 0)
                    {
                        numeros[i] = null;
                        break;
                    }

                    if (comparar(numeros[j].Value, numeros[i].Value) == -1)
                    {
                        var temp = numeros[j].Value;
                        numeros[j] = numeros[i].Value;
                        numeros[i] = temp;
                    }
                }
            }

            return numeros;
        }

        // Retorna -1 se a < b, +1 se a > b e 0 se a = b
        private static int comparar(int a, int b)
        {
            if (a < b)
                return -1;

            if (a > b)
                return 1;

            return 0;
        }

        private static void mostrarNumeros(int?[] numeros)
        {
            if (numeros == null)
                throw new ArgumentNullException("\"numeros\" nao pode ser nulo.");

            int qtdeIgnorados = 0;

            for (int i = 0; i < numeros.Length; i++)
            {
                if (!numeros[i].HasValue)
                    qtdeIgnorados++;
            }

            int[] numerosSemNulos = new int[numeros.Length - qtdeIgnorados];
            int idxNumerosOrdenados = 0;

            for (int i = 0; i < numeros.Length; i++)
            {
                if (!numeros[i].HasValue)
                    continue;

                numerosSemNulos[idxNumerosOrdenados] = numeros[i].Value;
                idxNumerosOrdenados++;
            }

            mostrarNumeros(numerosSemNulos);
        }

        private static void mostrarNumeros(int[] numeros)
        {
            if (numeros == null)
                throw new ArgumentNullException("\"numeros\" nao pode ser nulo.");

            Console.WriteLine(string.Join(", ", numeros));
        }
    }
}
