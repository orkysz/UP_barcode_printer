using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarPrinterCode
{
    class Ean13CodeGenerator
    {      //   EAN CHARACTER SET ENCODING TABLE
           // LEFT-HAND ENCODING  || RIGHT-HAND ENCODING
           // A             B           all characters
        private static string[,] slownik =
          {
            //lewostronne A i B     //prawostronne
            { "0001101", "0100111", "1110010" },    //0
            { "0011001", "0110011", "1100110" },    //1    
            { "0010011", "0011011", "1101100" },    //2
            { "0111101", "0100001", "1000010" },    //3
            { "0100011", "0011101", "1011100" },    //4
            { "0110001", "0111001", "1001110" },    //5
            { "0101111", "0000101", "1010000" },    //6
            { "0111011", "0010001", "1000100" },    //7
            { "0110111", "0001001", "1001000" },    //8
            { "0001011", "0010111", "1110100" }     //9
        };
        //                                  EAN PARITY ENCODING TABLE
        private static string[] parzystosc = {  "000000",
                                                "001011",
                                                "001101",
                                                "001110",
                                                "010011",
                                                "011001",
                                                "011100",
                                                "010101",
                                                "010110",
                                                "011010" };
        
        public static int ControlSum(string kod)
            // liczenie sumy kontrolnej - wagi kolejnych cyfr to 131313..., suma robione modulo przez 10, i wynik odejmowany od 10 - to jest suma kontrolna
        {
            int suma_kontrolna = 0;
            for (int i = 0; i < kod.Length - 1; i += 2)
            {
                suma_kontrolna += Int32.Parse(kod[i] + "");
                suma_kontrolna += 3 * Int32.Parse(kod[i + 1] + "");
            }

            suma_kontrolna %= 10;
            return 10 - (suma_kontrolna % 10);
        }

        public static string Generate(string kod)
        {
            kod += Char.ConvertFromUtf32(ControlSum(kod) + '0'); // dodanie znaku konca linii

            int pierwsza = Int32.Parse(kod[0] + "");    //zamiana pierwszej cyfry na int
            string kodowanie = parzystosc[pierwsza];    //sprawdzamy pierwsza cyfre

            string kod_paskowy = "";

            kod_paskowy += "101";   //lewe paski ochronne
            for (int i = 1; i < 7; i++)
            {
                if (kodowanie[i - 1] == '0')    //lewy nieparzysty (A)
                {
                    kod_paskowy += slownik[Int32.Parse(kod[i] + ""), 0];
                }
                if (kodowanie[i - 1] == '1')    //lewy parzysty (B)
                {
                    kod_paskowy += slownik[Int32.Parse(kod[i] + ""), 1];
                }
            }
            kod_paskowy += "01010"; //srodkowe paski ochronne
            for (int i = 7; i < 13; i++)
            {
                kod_paskowy += slownik[Int32.Parse(kod[i] + ""), 2];    //prawy
            }
            kod_paskowy += "101"; //prawe paski ochronne

            return kod_paskowy;
        }
    }
}
