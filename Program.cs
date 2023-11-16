namespace ThePenguinBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


        public static int GetInputNumber()
        {
            int userInput;
            while (true)
            {

                string inputNumber = Console.ReadLine();

                if (int.TryParse(inputNumber, out userInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Du gjorde en felaktig inmatning!");
                }

            }
            return userInput;
        }
    }

}