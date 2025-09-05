namespace PusulaTalentAcademyDocumentCandidate;

using System;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

public class LongestVowelSubsequenceAsJsonClass
{
    public class WordSequenceResult
    {
        public string Word { get; set; }
        public string Sequence { get; set; }
        public int Length { get; set; }
    }
    
    public static string LongestVowelSubsequenceAsJson(List<string> words)
    {
        if (words == null || words.Count == 0)
            return JsonSerializer.Serialize(new List<WordSequenceResult>());

        HashSet<char> vowels = new HashSet<char> 
        { 
            'a', 'e', 'i', 'o', 'u',
            'A', 'E', 'I', 'O', 'U' 
        };

        List<WordSequenceResult> result = new List<WordSequenceResult>();

        foreach (string word in words)
        {
            List<char> currentSubseq = new List<char>();
            List<char> best = new List<char>();

            foreach (char c in word)
            {
                if (vowels.Contains(c))
                {
                    currentSubseq.Add(c);
                    if (currentSubseq.Count > best.Count)
                        best = new List<char>(currentSubseq);
                }
                else
                {
                    currentSubseq.Clear();
                }
            }

            result.Add(new WordSequenceResult
            {
                Word = word,
                Sequence = new string(best.ToArray()),
                Length = best.Count
            });
        }

        return JsonSerializer.Serialize(result);
    }
    
    /* public static void Main()
    {
        var input1 = new List<string> { "aeiou", "bcd", "aaa" };
        Console.WriteLine("Çıkış 1: " + LongestVowelSubsequenceAsJson(input1));
        
        var input2 = new List<string> { "miscellaneous", "queue", "sky", "cooperative" };
        Console.WriteLine("Çıkış 2: " + LongestVowelSubsequenceAsJson(input2));
        
        var input3 = new List<string> { "sequential", "beautifully", "rhythms", "encyclopaedia" };
        Console.WriteLine("Çıkış 3: " + LongestVowelSubsequenceAsJson(input3));
        
        var input4 = new List<string> { "algorithm", "education", "idea", "strength" };
        Console.WriteLine("Çıkış 4: " + LongestVowelSubsequenceAsJson(input4));
        
        var input5 = new List<string>();
        Console.WriteLine("Çıkış 5: " + LongestVowelSubsequenceAsJson(input5));
    } */
}
