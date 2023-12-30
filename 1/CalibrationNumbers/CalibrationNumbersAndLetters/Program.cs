using System;
using System.Net;
using System.IO;
using System.Linq;
using CalibrationNumbersAndLetters;

public class Test
{
    [STAThread]
    static void Main(string[] args)
    {
        long result = 0;
        Dictionary<string,int> letterValues = new Dictionary<string, int>()
        {
            {"zero",  0},
            {"one",   1},
            {"two",   2},
            {"three", 3},
            {"four",  4},
            {"five",  5},
            {"six",   6},
            {"seven", 7},
            {"eight", 8},
            {"nine",  9},
        };

        // Read file using StreamReader. Reads file line by line
        using (StreamReader file = new StreamReader("input.txt"))
        {
            string ln;

            int firstDigit = 0;
            int lastDigit = 0;

            int numCheck, letCheck;

            while ((ln = file.ReadLine()) != null)
            {
                numCheck = ln.IndexOf(ln.First(match => char.IsDigit(match)));
                letCheck = ln.First(ln.First(ln.Contains(enumValues).ToString));
                firstDigit = ln.First(match => char.IsDigit(match));
            }
            Console.WriteLine(result);
        }
    }
}