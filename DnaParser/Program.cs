// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

while (true)
{
    Console.WriteLine("\nEnter the input string:");
    string input = Console.ReadLine();

    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("\nInvalid input. Please try again.");
        continue;
    }

    input = input.ToUpper().Trim();

    if (input == "TABLE")
    {
        DnaParser.Parser.PrintDictionary();
        continue;
    }
    else if (input == "EXIT")
    {
        break;
    }

    DnaParser.Parser.Parse(input);
}