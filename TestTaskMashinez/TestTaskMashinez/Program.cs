using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();

        string output = ReplaceUniqueChars(input);
        Console.WriteLine("Результат: " + output);
        Console.ReadKey(true);
    }

    static string ReplaceUniqueChars(string input)
    {
        // Приводим строку к нижнему регистру для игнорирования регистра символов
        input = input.ToLower();

        // Создаем словарь, где ключом является символ, а значением - количество его повторений
        Dictionary<char, int> charCount = new Dictionary<char, int>();

        // Подсчитываем количество повторений каждого символа
        foreach (char c in input)
        {
            if (charCount.ContainsKey(c))
                charCount[c]++;
            else
                charCount[c] = 1;
        }

        // Заменяем уникальные символы на "(" и повторяющиеся символы на ")"
        string output = "";
        foreach (char c in input)
        {
            if (charCount[c] == 1)
                output += "(";
            else
                output += ")";
        }

        return output;
        //Программа позволяет пользователю вводить строку с клавиатуры,
        //затем вызывает функцию ReplaceUniqueChars(), которая возвращает измененную строку.
        //Результат выводится на экран.
    }
}
