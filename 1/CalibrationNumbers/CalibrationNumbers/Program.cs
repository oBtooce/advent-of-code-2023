using System;
using System.Net;
using System.IO;

public class Test
{
    [STAThread]
    static void Main(string[] args)
    {
        CalibrateNumbers();
        CalibrateNumbersWithWords();
    }

    static void CalibrateNumbers()
    {
        long result = 0;

        // Read file using StreamReader. Reads file line by line
        using (StreamReader file = new StreamReader("input.txt"))
        {
            string ln;

            int firstDigit = 0;
            int lastDigit = 0;

            while ((ln = file.ReadLine()) != null)
            {
                // Need to subtract '0' to get the proper number from the output
                firstDigit = ln.First(input => char.IsDigit(input)) - '0';
                lastDigit = ln.Last(input => char.IsDigit(input)) - '0';

                // Add to result
                result += firstDigit * 10 + lastDigit;
            }
            Console.WriteLine($"Answer to problem 1: {result}");
        }
    }

    static void CalibrateNumbersWithWords()
    {
        long result = 0;

        // Read file using StreamReader. Reads file line by line
        using (StreamReader file = new StreamReader("input.txt"))
        {
            string ln;

            int firstDigit = 0;
            int lastDigit = 0;

            Dictionary<string, int> digits = new Dictionary<string, int>
            {
                { "one",    1 },
                { "two",    2 },
                { "three",  3 },
                { "four",   4 },
                { "five",   5 },
                { "six",    6 },
                { "seven",  7 },
                { "eight",  8 },
                { "nine",   9 },
            };

            Dictionary<string, string> stringTricks = new Dictionary<string, string>
            {
                { "oneight",    "oneeight" },
                { "twone",      "twoone" },
                { "threeight",  "threeeight" },
                { "fiveight",   "fiveeight" },
                { "sevenine",   "sevennine" },
                { "eightwo",    "eighttwo" },
                { "eighthree",  "eightthree" },
                { "nineight",   "nineeight" }
            };

            while ((ln = file.ReadLine()) != null)
            {
                // Initial reformat based on trick dictionary
                foreach (string key in stringTricks.Keys)
                {
                    if (ln.Contains(key))
                    {
                        ln = ln.Replace(key, stringTricks[key]);
                    }
                }

                // Go through line and get first/last
                for (int i = 0; i < ln.Length; i++)
                {
                    switch (ln[i])
                    {
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                            if (firstDigit == 0)
                            {
                                firstDigit = ln[i] - '0';
                            }
                            lastDigit = ln[i] - '0';

                            break;
                        case 'o':
                        case 't':
                        case 'f':
                        case 's':
                        case 'e':
                        case 'n':
                            foreach (string key in digits.Keys)
                            {
                                if (i + key.Length <= ln.Length && ln.IndexOf(key, i, key.Length) == i)
                                {
                                    if (firstDigit == 0)
                                    {
                                        firstDigit = digits[key];
                                    }
                                    lastDigit = digits[key];

                                    // Increment as needed
                                    i += (key.Length - 1);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }

                result += firstDigit * 10 + lastDigit;

                firstDigit = 0;
                lastDigit = 0;
            }

            Console.WriteLine($"Answer to problem 2: {result}");
        }
    }
}