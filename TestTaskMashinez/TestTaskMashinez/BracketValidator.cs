using System;
using System.Collections.Generic;

public class BracketValidator
{
    public bool IsValidBrackets(string input)
    {
        // Создаем стек для хранения открывающих скобок
        Stack<char> stack = new Stack<char>();

        // Мапа соответствующих скобок
        Dictionary<char, char> bracketsMap = new Dictionary<char, char>()
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' }
    };

        // Перебираем каждый символ входной строки
        foreach (char c in input)
        {
            // Если текущий символ - открывающая скобка, добавляем её в стек
            if (bracketsMap.ContainsKey(c))
            {
                stack.Push(c);
            }
            // Если текущий символ - закрывающая скобка
            else if (bracketsMap.ContainsValue(c))
            {
                // Если стек пуст или верхний элемент стека не является открывающей скобкой
                // для данной закрывающей скобки, возвращаем false
                if (stack.Count == 0 || bracketsMap[stack.Peek()] != c)
                {
                    return false;
                }
                // Если верхний элемент стека соответствует открывающей скобке для данной закрывающей скобки,
                // удаляем его из стека
                stack.Pop();
            }
        }

        // Если стек пуст после обработки всех символов, значит все скобки были правильно закрыты
        return stack.Count == 0;
    }
}

