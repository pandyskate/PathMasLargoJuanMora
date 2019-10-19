using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    // C# para encontrar the longest path  
    using System;

    class JDM
    {
        public static int TamanioFilasYcolumnas = 1000;


        public static int EncontrarElmasSobreUnaCelda(int i, int j,
                                            int[,] mat,
                                            int[,] dp)
        {
            if (i < 0 || i >= TamanioFilasYcolumnas || j < 0 || j >= TamanioFilasYcolumnas)
            {
                return 0;
            }


            if (dp[i, j] != -1)
            {
                return dp[i, j];
            }

            int x = int.MinValue, y = int.MinValue, z = int.MinValue, w = int.MinValue;


            if (j < TamanioFilasYcolumnas - 1 && ((mat[i, j] + 1) == mat[i, j + 1]))
            {
                x = dp[i, j] = 1 + EncontrarElmasSobreUnaCelda(i, j + 1, mat, dp);
            }

            if (j > 0 && (mat[i, j] + 1 == mat[i, j - 1]))
            {
                y = dp[i, j] = 1 + EncontrarElmasSobreUnaCelda(i, j - 1, mat, dp);
            }

            if (i > 0 && (mat[i, j] + 1 == mat[i - 1, j]))
            {
                z = dp[i, j] = 1 + EncontrarElmasSobreUnaCelda(i - 1, j, mat, dp);
            }

            if (i < TamanioFilasYcolumnas - 1 && (mat[i, j] + 1 == mat[i + 1, j]))
            {
                w = dp[i, j] = 1 + EncontrarElmasSobreUnaCelda(i + 1, j, mat, dp);
            }

            dp[i, j] = Math.Max(x, Math.Max(y, Math.Max(z, Math.Max(w, 1))));
            return dp[i, j];
        }


        public static int EncyentraElMasSobreTodo(int[,] mat)
        {

            int result = 0;


            int[,] dp = ArraysFijosDimensiones.CrearArray(1000, 1000);



            //fin llenado de matriz dp con -1 de prueba

            /*
             for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    dp[i,j] = -1;
                }
            }
             */
            //fin llenado de matriz dp con -1 de prueba







            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (dp[i, j] != -1)
                    {
                        EncontrarElmasSobreUnaCelda(i, j, mat, dp);
                    }

                    result = Math.Max(0, dp[i, j]);
                }
            }

            return result;
        }

        public static class ArraysFijosDimensiones
        {
            public static int[,] CrearArray(int size1, int size2)
            {
                int[,] newArray = new int[1000, 1000];

                newArray = new int[1000, 1000];

                //llenado de La matriz con numeros entre 0 a 1500
                for (int f = 0; f < 1000; f++)
                {
                    Random rnd = new Random(1500);


                    for (int c = 0; c < 1000; c++)
                    {
                        int numeroSinCotaArbitraria = rnd.Next();

                        newArray[f, c] = numeroSinCotaArbitraria;
                    }
                }
                return newArray;
            }
        }

        public static void Main(string[] args)
        {
            //declaracion matriz
            int[,] mat;

            //inicializacion
            mat = new int[1000, 1000];


            int numeroSinCotaArbitraria;
            Random rnd = new Random();

            //inicio llenado de la mariz con los numeros entre 0 y 1500 (se recorrern filas y columnas)
            for (int f = 0; f < 1000; f++)
            {


                for (int c = 0; c < 1000; c++)
                {
                    numeroSinCotaArbitraria = rnd.Next(0,1500);

                    mat[f, c] = numeroSinCotaArbitraria;

                    numeroSinCotaArbitraria = 0;
                }
            }
            //fin llenado de la mariz con los numeros entre 0 y 1500



            //iniicio mostrar el contenido de la matriz             

            for (int f = 0; f < mat.GetLength(0); f++)
            {
                for (int c = 0; c < mat.GetLength(1); c++)
                {
                    Console.Write(mat[f, c] + " ");
                }
                Console.WriteLine();
            }

            //fin mostrar el contenido de la matriz 



            Console.WriteLine("Longitud del path mas largo es: " + EncyentraElMasSobreTodo(mat));
            Console.ReadLine(); //para mamtener activo el mensaje en consola

        }
    }

}
