using DoubleList;

var doubleList = new DoubleLinkedList<string>();
var userOption = string.Empty;
var userInput = string.Empty;

do
{
    userOption = DisplayMenu();

    switch (userOption)
    {
        case "1":
            Console.Write("Enter the value to add: ");
            userInput = Console.ReadLine() ?? string.Empty;
            doubleList.Add(userInput);
            Console.WriteLine("Value added successfully.");
            break;

        case "2":
            Console.WriteLine("--- Forward List ---");
            Console.WriteLine(doubleList.ShowForward());
            break;

        case "3":
            Console.WriteLine("--- Backward List ---");
            Console.WriteLine(doubleList.ShowBackward());
            break;

        case "4":
            doubleList.OrderDescending();
            Console.WriteLine("The list has been sorted in descending order.");
            break;

        case "5":
            Console.WriteLine(doubleList.ShowModes());
            break;

        case "6":
            Console.WriteLine("--- Frequency Graph ---");
            Console.WriteLine(doubleList.ShowGraph());
            break;

        case "7":
            Console.Write("Enter the value to search for: ");
            userInput = Console.ReadLine() ?? string.Empty;
            if (doubleList.Exists(userInput))
            {
                Console.WriteLine($"The value '{userInput}' exists in the list.");
            }
            else
            {
                Console.WriteLine($"The value '{userInput}' was not found.");
            }
            break;

        case "8":
            Console.Write("Enter the value to delete (first occurrence): ");
            userInput = Console.ReadLine() ?? string.Empty;
            doubleList.DeleteOccurrence(userInput);
            Console.WriteLine("Process finished.");
            break;

        case "9":
            Console.Write("Enter the value to delete (all occurrences): ");
            userInput = Console.ReadLine() ?? string.Empty;
            doubleList.DeleteAllOccurrences(userInput);
            Console.WriteLine("Process finished.");
            break;

        case "0":
            Console.WriteLine("Closing the program...");
            break;

        default:
            Console.WriteLine("That is not a valid option, please try again.");
            break;
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();

} while (userOption != "0");

string DisplayMenu()
{
    Console.WriteLine("================================");
    Console.WriteLine("      DOUBLE LINKED LIST MENU   ");
    Console.WriteLine("================================");
    Console.WriteLine("1. Add (Ordered)");
    Console.WriteLine("2. Show Forward");
    Console.WriteLine("3. Show Backward");
    Console.WriteLine("4. Sort Descending");
    Console.WriteLine("5. Show Mode(s)");
    Console.WriteLine("6. Show Graph");
    Console.WriteLine("7. Check if Exists");
    Console.WriteLine("8. Delete One Occurrence");
    Console.WriteLine("9. Delete All Occurrences");
    Console.WriteLine("0. Exit");
    Console.WriteLine("================================");
    Console.Write("Please select an option: ");

    return Console.ReadLine() ?? string.Empty;
}