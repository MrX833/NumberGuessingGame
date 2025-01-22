bool exit = false;
string? readResult = "";
int guessedNumber = 0;
int guessAmount = 0;



while (exit == false)
{
    Console.WriteLine("Welcome to the number guessing game!");
    Console.WriteLine("I'm thinking of a number between 1 and 100");
    Console.WriteLine("Can you guess the currect number?");

    Random random = new Random();
    int number = random.Next(1, 100);

    guessAmount = SelectDificulity(readResult);

        for (int i = 0; i < guessAmount; i++)
        {
            guessedNumber = VerifyNumber(readResult, guessedNumber);

            if (guessedNumber == number)
            {
                Console.WriteLine($"Congratulations! you guessed the currect number in {i + 1} attempts!");
                break;
            }

            if (guessedNumber > number)
            {
                Console.WriteLine($"Incorrect! the number is less than {guessedNumber}");
                continue;
            }

            if (guessedNumber < number)
            {
                Console.WriteLine($"Incorrect! the number is bigger than {guessedNumber}");
                continue;
            }
        }

    if (guessedNumber != number)
    {
        Console.WriteLine("You are out of guesses! better luck next time!");
    }

    if (!PlayAgainOrExit(readResult))
    {
        exit = true;
    }
}


int SelectDificulity(string? input)
{
    Console.WriteLine("Select your difficulty:");
    Console.WriteLine("1. Easy (10 guesses)");
    Console.WriteLine("2. Medium (5 guesses)");
    Console.WriteLine("3. Hard (3 guesses)");
    input = Console.ReadLine();

    switch (input)
    {
        case "1":
            return 10;

        case "2":
            return 5;

        case "3":
            return 3;

        default:
            Console.WriteLine("please enter a valid number!");
            return SelectDificulity(input);
    }
}

int VerifyNumber(string? input, int guessedNumber)
{
    Console.Write("Enter your number: ");
    input = Console.ReadLine()!.Trim();
    if (input is null)
    {
       return VerifyNumber(input, guessedNumber);    
    }
     
    try
    {
        guessedNumber = int.Parse(input);
    }
    catch (FormatException) 
    {
        Console.WriteLine("please enter a valid number!");
        return VerifyNumber(input, guessedNumber);
    }

    if (guessedNumber > 100 || guessedNumber < 1)
    {
        Console.WriteLine("Your number must be between 1 and 100");
        return VerifyNumber(input, guessedNumber);
    }

    return guessedNumber;
}

bool PlayAgainOrExit(string? input)
{
    Console.WriteLine("would you like to play again?\t\tY/N");
    input = Console.ReadLine()!.Trim().ToLower();

    if (input is not null)
    {
        if (input == "y")
            return true;

        if (input == "n")
            return false;
    }

    Console.WriteLine("Please enter Y or N");
    PlayAgainOrExit(input);

    return false;
}