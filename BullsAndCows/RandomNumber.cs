namespace BullsAndCows
{
    public class RandomNumber
    {
        private string _secretNumber;

        public RandomNumber()
        {
            Random random = new Random();
            _secretNumber = random.Next(1000, 9999).ToString();         
        }

        public (int bulls, int cows) Guess(string guess)
        {
            int bulls = 0;
            int cows = 0;

            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == _secretNumber[i])
                {
                    bulls++;
                }
                else if (_secretNumber.Contains(guess[i]))
                {
                    cows++;
                }
            }

            return (bulls, cows);
        }

        public void StartGame()
        {
            bool isValid;
            Console.WriteLine("Угадайте 4-значное число");

            for (int tries = 0; tries < 5; tries++)
            {
                string guess;

                do
                {
                    Console.WriteLine("Есть догадки?");
                    guess = Console.ReadLine();

                    isValid = IsValidGuess(guess);

                    if (!isValid)
                    {
                        Console.WriteLine("Ошибка! Введите 4-х значное число от 1000 до 9999");

                    }
                }
                while (!isValid);

                var result = Guess(guess);

                Console.WriteLine($"Быки:{result.bulls}, Коровы:{result.cows}");

                if (result.bulls == 4)
                {
                    Console.WriteLine("Красава, угадал!");

                    return;
                }

            }
            Console.WriteLine($"Ну ничего, угадаешь в следуйщий раз.Правильный ответ:{_secretNumber}");
        }

        private bool IsValidGuess(string guess)
        {
            return int.TryParse(guess, out int number) && number >= 1000 && number <= 9999;
        }
    }
}

