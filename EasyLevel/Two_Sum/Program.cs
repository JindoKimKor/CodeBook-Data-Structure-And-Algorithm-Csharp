using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Security.Policy;

internal class Program
{
    static void Main(string[] args)
    {
        //int[] randomNumberArray = new int[10000];
        //Random random = new Random();
        //for (int i = 0; i < randomNumberArray.Length; i++)
        //{
        //    randomNumberArray[i] = random.Next(-1000000, 10000001);
        //}
        int[] nums = { 3, 2, 4 };
        int target = 6;//an example of target
        var result = TwoSumHashTable(nums, target);

        

        if (result != null)
        {
            Console.WriteLine($"Indices found: [{result[0]}, {result[1]}]");
            Console.WriteLine($"Numbers: {nums[result[0]]} + {nums[result[1]]} = {target}");
        }
        else
        {
            Console.WriteLine("No two numbers add up to the target.");
        }
        Console.ReadKey();
    }

    static int[] TwoSumHashTable(int[] randomArrayNumbers, int target)
    {
        // Create a Dictionary instance
        // Reason: Switching strategy to only iterating over 'keys' of a hash-based collection, 
        // Dictionary, because using a Brute Force approach with two nested for loops 
        // would raise the expected time complexity to O(n^2)
        Dictionary<int, int> HashBasedGenericCollection = new Dictionary<int, int>();

        // Iterate through all elements of the array
        // Expected Time Complexity: O(n)
        // Expected Space Complexity: O(1)
        // Reason: Time taken is proportional to the array size n, and no additional space is required
        for (int i = 0; i < randomArrayNumbers.Length; i++)
        {
            int complement = target - randomArrayNumbers[i];

            // Check if the currently iterated index value is present as a key in the Dictionary
            // Expected effect: Prevents collisions that can occur due to duplicate keys and recognizes the correct two different indices of the same number if that number or its duplicate adds up to match the target value
            // Expected Time Complexity: O(1)
            // Hash Function Efficiency: Hash tables internally use a hash function to transform keys into hash codes.These hash codes determine where the data is stored or retrieved in the table. The hash function quickly computes based on the content of the key.
            //Direct Access: The calculated hash code directly points to the location of the data within the hash table. Therefore, finding data using a key is similar to directly accessing an array index, which in most cases, happens in constant time.

            // Expected Space Complexity: O(n)
            if (HashBasedGenericCollection.ContainsKey(complement))
            {
                return new int[] { HashBasedGenericCollection[complement], i };
            }
            if (!HashBasedGenericCollection.ContainsKey(randomArrayNumbers[i]))
            {
                HashBasedGenericCollection[randomArrayNumbers[i]] = i;
            }
        }
        return null;
    }

}
