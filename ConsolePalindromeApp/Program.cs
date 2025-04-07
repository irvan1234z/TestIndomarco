using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Masukkan String: ");
        string input = Console.ReadLine();

        bool output = IsPalindrome(input);
        Console.WriteLine($"{output}");
    }

    static bool IsPalindrome(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return false;

        str = str.Replace(" ", "").ToLower(); //untuk menghilangkan spasi dan menjadi lowecase

        int left = 0;
        int right = str.Length - 1;

        while (left < right)
        {
            //pengeecekan apakah huruf pertama dan terakhir pada string adalah sama (palindrome)
            if (str[left] != str[right])
                return false;

            left++;
            right--;
        }

        return true;
    }
}