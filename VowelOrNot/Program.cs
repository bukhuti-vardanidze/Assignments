using System;

public class VowelOrNot
{
    static void Main(string[] args)
    {
        char ch;

        Console.Write("Enter any character: ");
        ch = Convert.ToChar(Console.ReadLine());


        
        if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u' || ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U')
        {

            Console.WriteLine(ch + " is Vowel.");

        }
        else 
        {
            Console.WriteLine(ch + " is not vowel");
        }

        Console.ReadLine();
    }
}
