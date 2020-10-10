using System;
using System.Collections.Generic;
using System.Linq;

namespace Строки
{
    class Program
    {
        static string CuttingWord(string word, char[] sign)
        {
            word=word.Trim(sign);
            return word.ToLower();
        }

            static bool IsOriginalWord(string word,List<string> original_words)
        {
            if (!original_words.Contains(word))
                return true;
            else 
                return false;
        }

        static void WritingReplacedWord(string word)
        {
            if (word.Length % 2 == 0)
                Console.WriteLine(word.Remove(0, (word.Length) / 2));
            else
                Console.WriteLine('*'+ word.Remove(0, word.Length / 2+1));
        }

        static void Main()
        {
            string[] exception = { "mrs.", "mr.","Mr.","Mrs." };
            char[] sign_of_end = { '!', '.', '?' };
            char[] sign = {',' , ':',';','-','!', '.', '?','"','(',')','>','<' };

            string text = Console.ReadLine();

            string[] words = text.Split(' ');

            string sentence = "";
            List<string> sentences = new List<string>();
            for (int i = 0; i <= words.Length - 1; i++)    // Заполнение листа предложений
            {
                sentence += " " + words[i];

                if (sign_of_end.Contains(words[i][words[i].Length - 1]) && !exception.Contains(words[i]))
                {
                    sentences.Add(sentence);
                    sentence = "";
                }
            }

            string lenghtword = "";
            List<string> original_words = new List<string>();
            for (int i=0; i<= words.Length-1; i++)
            {
                words[i]=CuttingWord(words[i], sign);
                if (words[i].Length>lenghtword.Length) lenghtword=words[i];
                if (IsOriginalWord(words[i], original_words)) original_words.Add(words[i]) ;
            }

            Console.WriteLine();

            int counterofsigns = 0;
            for (int i = 0; i <= text.Length - 1; i++)    // Счётчик знаков препинания
                if (sign_of_end.Contains(text[i]) || sign.Contains(text[i])) counterofsigns++;

            Console.WriteLine();

            for(int i = 0; i <= sentences.Count -1; i++)
                Console.WriteLine(sentences[i]);

            Console.WriteLine("\nУникальные слова:");

            for (int i = 0; i <= original_words.Count - 1; i++)
                Console.WriteLine(original_words[i]);

            Console.WriteLine();

            Console.WriteLine("Количество знаков препинания: " + counterofsigns+'\n');

            Console.WriteLine("Самое длинное слово: " + lenghtword);

            Console.Write("Задание со словом: "); WritingReplacedWord(lenghtword);

            Console.ReadKey();
        }
    }
}
