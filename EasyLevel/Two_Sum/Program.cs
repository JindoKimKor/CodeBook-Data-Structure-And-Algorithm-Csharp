using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Policy;

internal class Program
{
    static void Main(string[] args)
    {
        int[] NumberArray = new int[100000];
        //Generating NumberArray
        for (int i = 0; i < NumberArray.Length; i++)
        {
            NumberArray[i] = i + 1;
        }

        //int[] nums = { 3, 2, 4 };
        int target = 199999;//an example of target
        //var result = TwoSumHashTable(nums, target);

        Stopwatch stopwatch = Stopwatch.StartNew();
        int[] bruteForceResult = BruteForceTwoSum(NumberArray, target);
        stopwatch.Stop();
        long bruteForceTime = stopwatch.ElapsedMilliseconds;

        stopwatch.Restart();
        var hashTableResult = TwoSumHashTable(NumberArray, target);
        stopwatch.Stop();
        long hashTableTime = stopwatch.ElapsedMilliseconds;

        if (bruteForceResult != null)
        {
            Console.WriteLine($"Indices found: [{bruteForceResult[0]}, {bruteForceResult[1]}]");
            Console.WriteLine($"Numbers: {NumberArray[bruteForceResult[0]]} + {NumberArray[bruteForceResult[1]]} = {target}");
            Console.WriteLine($"Brute Force Method Time: {bruteForceTime} ms");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Indices found: [{hashTableResult[0]}, {hashTableResult[1]}]");
            Console.WriteLine($"Numbers: {NumberArray[hashTableResult[0]]} + {NumberArray[hashTableResult[1]]} = {target}");
            Console.WriteLine($"Hash Table Method Time: {hashTableTime} ms");
        }
        else
        {
            Console.WriteLine("No two numbers add up to the target.");
        }
        Console.ReadKey();
    }

    static int[] BruteForceTwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }
        return null;
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
