using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("The default regular expression checks for at least one digit.");
            do
            {
                Write("Enter a regular expression (or press ENTER to use the default): ");
                string regexp = ReadLine();
                if (string.IsNullOrWhiteSpace(regexp))
                {
                    regexp = @"^\d+$";
                }
                Write("Enter some input: ");
                string input = ReadLine();
                var r = new Regex(regexp);
                WriteLine($"{input} matches {regexp}: {r.IsMatch(input)}");
                WriteLine("Press the ESC to end or any key to try again");
            } while (ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

/*
------ Exercise 8.1 ------
1. What is the maximum number of characters that can be stored in a string
variable? A: Approximately 1 billion characters before you've taken a real tole on your memory
2. When and why should you use a SecureString class? A: You shouldn't, its purpose was to prevent secrets being stored as plain text, however Windows doesn't have a representation of this concept, it just makes the window of getting the plain text shorter, but not entirely secured.
3. When is it appropriate to use a StringBuilder type? A: Instead of manually concatenating a string (which is rough on memory), you use a StringBuilder to more efficiently manipulate the String type.
4. When should you use a LinkedList<T> class? A: When you have a list that has items frequently added and removed from various place around the list, a LinkedList can provide better efficiency because the items do not have to be rearranged in memory
5. When should you use a SortedDictionary<T> class rather than a
SortedList<T> class? A: Though SortedList uses less memory, a SortedDictionary has faster insertion and removal operations for unsorted data. If the list is populated all at once, SortedList would be faster.
6. What is the ISO culture code for Welsh? A: cy-GB
7. What is the difference between localization, globalization, and
internationalization? A: Localization makes sure the product feels that it was produced solely for the target audience. Globalization is ensuring that your product can reach global markets, formalizing requirements, and translating to the target audience language
8. In a regular expression, what does $ mean? A: End of line.
9. In a regular expression, how could you represent digits? A: \d
10. Why should you not use the official standard for email addresses to create a regular expression to validate a user's email address? A: What a rabbit hole this was. Apparently RegEx has a few edge-cases where it can see a perfectly valid email and still claim it be invalid due to some gotcha's in the RegEx syntax, as well as how vastly different an email address can get. System.Net.Mail.MailAddress is the C# way and passing the email as a string should yield a valid check.

*/
