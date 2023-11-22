namespace ThePenguinBank;

internal class Admin
{

    public static double GetInputNumber() 
    {
        double userInput;
        while (true)
        {
            string inputNumber = Console.ReadLine();
            if (double.TryParse(inputNumber, out userInput))
            {
                break;
            }
            else
            {
                Console.WriteLine("You made an incorrect entry, please enter integers only.");
            }
        }
        return userInput;
    }
    }