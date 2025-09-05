namespace PusulaTalentAcademyDocumentCandidate;

using System;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

public class MaxIncreasingSubArrayAsJsonClass
{
    public static string MaxIncreasingSubArrayAsJson(List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0)
            return JsonSerializer.Serialize(new List<int>());

        List<int> best = new List<int>();
        int bestSum = int.MinValue;

        List<int> current = new List<int>();
        current.Add(numbers[0]);

        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                current.Add(numbers[i]);
            }
            else
            {
                int currentSum = current.Sum();
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                    best = new List<int>(current);
                }
                current.Clear();
                current.Add(numbers[i]);
            }
        }

        int lastSum = current.Sum();
        if (lastSum > bestSum)
        {
            best = new List<int>(current);
        }

        return JsonSerializer.Serialize(best);
    }
    
   /* public static void Main()
    {
        var input1 = new List<int> { 1, 2, 3, 1, 2 };
        Console.WriteLine("Sonuç 1: " + MaxIncreasingSubArrayAsJson(input1));
        
        var input2 = new List<int> { 2, 5, 4, 3, 2, 1 };
        Console.WriteLine("Sonuç 2: " + MaxIncreasingSubArrayAsJson(input2));
        
        var input3 = new List<int> { 1, 2, 2, 3 };
        Console.WriteLine("Sonuç 3: " + MaxIncreasingSubArrayAsJson(input3));
        
        var input4 = new List<int> { 1, 3, 5, 4, 7, 8, 2 };
        Console.WriteLine("Sonuç 4: " + MaxIncreasingSubArrayAsJson(input4));
        
        var input5 = new List<int>();
        Console.WriteLine("Sonuç 5: " + MaxIncreasingSubArrayAsJson(input5));
    } */
}
