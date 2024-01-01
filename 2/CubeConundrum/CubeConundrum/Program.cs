internal class Program
{
    private static void Main(string[] args)
    {
        Problem1();
        Problem2();
    }

    public static void Problem1() {
        int total = 0;
        int currentGame = 1;

        const int BLUE_TOTAL = 14;
        const int RED_TOTAL = 12;
        const int GREEN_TOTAL = 13;

        string colourName = "";
        int colourTotal = 0;

        bool validGame = true;

        using (StreamReader reader = new StreamReader("input.txt"))
        {
            string? line = "";

            while ((line = reader.ReadLine()) != null)
            {
                // Only work with the subsets on each line
                string[] subsets = line.Split(':')[1].Split(';');

                foreach (string subset in subsets)
                {
                    string[] colours = subset.Split(",");

                    foreach (string colour in colours)
                    {
                        // Get colour and number, then check for validity
                        colourName = new string(colour.Where(Char.IsLetter).ToArray());
                        colourTotal = Int32.Parse(new string(colour.Where(Char.IsDigit).ToArray()));

                        switch (colourName)
                        {
                            case "red":
                                if (colourTotal > RED_TOTAL)
                                    validGame = false;
                                break;
                            case "blue":
                                if (colourTotal > BLUE_TOTAL)
                                    validGame = false;
                                break;
                            case "green":
                                if (colourTotal > GREEN_TOTAL)
                                    validGame = false;
                                break;
                        }
                        
                        if (validGame == false)
                        {
                            break;
                        }
                    }                    
                }

                if (validGame)
                    total += currentGame;                    

                currentGame++;
                validGame = true;
            }
        }

        Console.WriteLine($"The sum of the game IDs is: {total}");
    }

    public static void Problem2()
    {
        int results = 0;

        string colourName = "";
        int colourTotal = 0;

        int blueMax = 0;
        int greenMax = 0;
        int redMax = 0;

        using (StreamReader reader = new StreamReader("input.txt"))
        {
            string? line = "";

            while ((line = reader.ReadLine()) != null)
            {
                // Only work with the subsets on each line
                string[] subsets = line.Split(':')[1].Split(';');

                // Determine max values for each cube colour
                foreach (string subset in subsets)
                {
                    string[] colours = subset.Split(",");

                    foreach (string colour in colours)
                    {
                        // Get colour and number, then check for validity
                        colourName = new string(colour.Where(Char.IsLetter).ToArray());
                        colourTotal = Int32.Parse(new string(colour.Where(Char.IsDigit).ToArray()));

                        switch (colourName)
                        {
                            case "red":
                                if (colourTotal > redMax)
                                    redMax = colourTotal;
                                break;
                            case "blue":
                                if (colourTotal > blueMax)
                                    blueMax = colourTotal;
                                break;
                            case "green":
                                if (colourTotal > greenMax)
                                    greenMax = colourTotal;
                                break;
                        }
                    }                    
                }

                // Sum the powers and reset maxes for next round
                results += redMax * blueMax * greenMax;

                redMax = 0;
                blueMax = 0;
                greenMax = 0;
            }
        }

        Console.WriteLine($"The sum of the powers of this result set is: {results}");
    }
}