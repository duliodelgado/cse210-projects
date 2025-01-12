using System;

class Program
{
    static void Main()
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);  // Convert string input to integer

        // Determine the letter grade
        string letterGrade = "";
        string sign = "";  // "+" or "-" for the grade

        if (grade >= 90)
        {
            letterGrade = "A";
            if (grade % 10 >= 7) sign = "+";
            else if (grade % 10 < 3) sign = "-";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
            if (grade % 10 >= 7) sign = "+";
            else if (grade % 10 < 3) sign = "-";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
            if (grade % 10 >= 7) sign = "+";
            else if (grade % 10 < 3) sign = "-";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
            // D grades don't have + or -, so leave sign as an empty string
        }
        else
        {
            letterGrade = "F";
            // F grades don't have + or -, so leave sign as an empty string
        }

        // Output the letter grade and its sign
        string fullGrade = letterGrade + sign;
        Console.WriteLine("Your letter grade is: " + fullGrade);

        // Check if the student passed
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Don't worry, keep trying next time!");
        }
    }
}