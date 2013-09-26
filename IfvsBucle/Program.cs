using System;
using System.Diagnostics;
using System.IO;

namespace IfvsBucle
{
    class Program
    {
        /// <summary>
        /// Constantes de la aplicación.
        /// </summary>
        public static class cConstantes
        {
            /// <summary>
            /// typeof(bool).MetadataToken
            /// </summary>
            static public int METADATATOKEN_BOOL = 33554589;

            /// <summary>
            /// typeof(char).MetadataToken
            /// </summary>
            static public int METADATATOKEN_CHAR = 33554593;

            /// <summary>
            /// typeof(byte).MetadataToken
            /// </summary>
            static public int METADATATOKEN_BYTE = 33554591;

            /// <summary>
            /// typeof(Int16).MetadataToken = eTipoDato.int16_
            /// </summary>
            static public int METADATATOKEN_INT16 = 33554685;

            /// <summary>
            /// typeof(Int32).MetadataToken = eTipoDato.int32_
            /// </summary>
            static public int METADATATOKEN_INT32 = 33554686;

            /// <summary>
            /// typeof(Int64).MetadataToken = eTipoDato.int64_
            /// </summary>
            static public int METADATATOKEN_INT64 = 33554687;

            /// <summary>
            /// typeof(float).MetadataToken = eTipoDato.single_
            /// </summary>
            static public int METADATATOKEN_SINGLE = 33554771;

            /// <summary>
            /// typeof(double).MetadataToken = eTipoDato.double_
            /// </summary>
            static public int METADATATOKEN_DOUBLE = 33554645;

            /// <summary>
            /// typeof(string).MetadataToken = eTipoDato.string_
            /// </summary>
            static public int METADATATOKEN_STRING = 33554510;

            /// <summary>
            /// typeof(DateTime).MetadataToken = eTipoDato.date_
            /// </summary>
            static public int METADATATOKEN_DATETIME = 33554520;

            /// <summary>
            /// typeof(decimal).MetadataToken eTipoDato.decimal_
            /// </summary>
            static public int METADATATOKEN_DECIMAL = 33554637;

            /// <summary>
            /// typeof(byte[]).MetadataToken = eTipoDato.binario_
            /// </summary>
            static public int METADATATOKEN_BYTES = 33554432;

            /// <summary>
            /// typeof(Guid).MetadataToken 
            /// </summary>
            static public int METADATATOKEN_GUID = 33554667;
        }

        /// <summary>
        /// Indicadores que puede devolver una conexión SqlServer para informar 
        /// sobre el tipo de sus campos.
        /// </summary>
        public static int[] ArrayMetaDatosTokens = {
            cConstantes.METADATATOKEN_BOOL,  cConstantes.METADATATOKEN_BYTE,  cConstantes.METADATATOKEN_BYTES,
            cConstantes.METADATATOKEN_CHAR,  cConstantes.METADATATOKEN_DATETIME,  cConstantes.METADATATOKEN_DECIMAL,
            cConstantes.METADATATOKEN_DOUBLE,  cConstantes.METADATATOKEN_GUID,  cConstantes.METADATATOKEN_INT16,
            cConstantes.METADATATOKEN_INT32,  cConstantes.METADATATOKEN_INT64, cConstantes.METADATATOKEN_SINGLE,
            cConstantes.METADATATOKEN_STRING
        };

        static void Main(string[] args)
        {
            const string sFichero = @"C:\Test_IF_vs_FOR.txt";
            StreamWriter sw = new StreamWriter(sFichero);

            
            bool bEncontrado = false;

            Stopwatch reloj = new Stopwatch();

            Console.WriteLine("Test. Este programa determina el rendimiento de utilizar un IF-ELSE o un bucle FOR para buscar un número entero");
            Console.WriteLine("Los resultados de los test serán guardados en la ruta C:\\Test_IF_vs_FOR.txt");

            bool bEsNumero;
            string sNumABuscar;
            int nNumABuscar;
            do
            {
                Console.WriteLine("Numero a buscar: ");
                sNumABuscar = Console.ReadLine();   //33554645;

                bEsNumero = Int32.TryParse(sNumABuscar, out nNumABuscar);
                if (!bEsNumero)
                    Console.WriteLine("Error. No ha introducido un numero\n\n");
            }
            while (!bEsNumero);

            sw.WriteLine("Numero a buscar: " + nNumABuscar);

            /*
            * PRIMER TEST: UTILIZANDO IF-ELSE
            */

            reloj.Start();

            for (int i = 0; i < 10000000; i++)
            {
                if (nNumABuscar == cConstantes.METADATATOKEN_BOOL)
                    bEncontrado = true;
                else if (nNumABuscar == cConstantes.METADATATOKEN_BYTE)
                    bEncontrado = true;
                else if (nNumABuscar == cConstantes.METADATATOKEN_BYTES)
                    bEncontrado = true;
                else if (nNumABuscar == cConstantes.METADATATOKEN_CHAR)
                    bEncontrado = true;
                else if (nNumABuscar == cConstantes.METADATATOKEN_DATETIME)
                    bEncontrado = true;
                else if (nNumABuscar == cConstantes.METADATATOKEN_DECIMAL)
                    bEncontrado = true;
                else if (nNumABuscar == cConstantes.METADATATOKEN_DOUBLE)
                    bEncontrado = true;
                else if (nNumABuscar == cConstantes.METADATATOKEN_GUID)
                    bEncontrado = true;
                else if (nNumABuscar == cConstantes.METADATATOKEN_INT16)
                    bEncontrado = true;
                else if (nNumABuscar == cConstantes.METADATATOKEN_INT32)
                    bEncontrado = true;
                else if (nNumABuscar == cConstantes.METADATATOKEN_INT64)
                    bEncontrado = true;
                else if (nNumABuscar == cConstantes.METADATATOKEN_SINGLE)
                    bEncontrado = true;
                else if (nNumABuscar == cConstantes.METADATATOKEN_STRING)
                    bEncontrado = true;
            }

            reloj.Stop();
            sw.WriteLine("Tiempo con IF: " + reloj.Elapsed + "\n\n");


            /*
             * SEGUNDO TEST: UTILIZANDO BUCLE FOR
             */

            reloj.Start();

            for (int i = 0; i < 10000000; i++)
            {
                bEncontrado = false;
                for (int j = 0; !bEncontrado && j < ArrayMetaDatosTokens.Length; j++)
                    if (nNumABuscar == ArrayMetaDatosTokens[j])
                        bEncontrado = true;
            }

            reloj.Stop();

            sw.WriteLine("Tiempo con BUCLES: " + reloj.Elapsed);
            sw.Close();

            Console.WriteLine("Ha finalizado el test. Pulse una tecla para cerrar el programa.");
            Console.Read();
        }
    }
}