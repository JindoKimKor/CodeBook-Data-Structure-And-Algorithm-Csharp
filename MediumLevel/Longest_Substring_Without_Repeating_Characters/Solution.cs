using System;
using System.Collections.Generic;

namespace Longest_Substring_Without_Repeating_Characters
{
    static public class Solution
    {
        static public int LengthOfLongestSubstring(string s)
        {
            // Return immediately if no processing is needed for strings
            if (s.Length == 0) return 0;
            if (s.Length == 1) return 1;

            Dictionary<char, int> charIndexMap = new Dictionary<char, int>();
            int maxLength = 1;  // Overall maximum substring length
            int currentSubstringLength = 1;  // Current maximum substring length
            int previousCharIndex = 0;
            int lastRepeatedCharIndex = 0;  // Flag for the last index where the same character appeared
            int currentLength = 1;  // Current substring length

            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0 || !charIndexMap.ContainsKey(s[i]))
                {
                    // If the current character appears for the first time
                    charIndexMap[s[i]] = i;
                    if (i != 0) currentLength++;
                }
                else // Same Character Key
                {
                    previousCharIndex = charIndexMap[s[i]];  // Index of the previous occurrence of the same character

                    charIndexMap[s[i]] = i;  // Update the index of the current character

                    if (previousCharIndex >= lastRepeatedCharIndex)
                    {
                        // If the previously occurred same character is after the current flag
                        lastRepeatedCharIndex = previousCharIndex;  // Update the flag
                        currentSubstringLength = i - previousCharIndex;  // Update the current maximum length
                        maxLength = maxLength < currentLength ? currentLength : maxLength;
                        currentLength = i - lastRepeatedCharIndex; // Reset the current substring length
                    }
                    else
                    {
                        currentLength++;
                    }
                }
                //Console.WriteLine("-------------------------------------------------------------");
                //Console.WriteLine($"turn: {i}");
                //foreach (KeyValuePair<char, int> item in charIndexMap)
                //{
                //    Console.WriteLine($"Character: {item.Key}, Index: {item.Value}");
                //}
                //Console.WriteLine($"maxLength: {maxLength}");
                //Console.WriteLine($"currentSubstringLength: {currentSubstringLength}");
                //Console.WriteLine($"previousCharIndex: {previousCharIndex}");
                //Console.WriteLine($"lastRepeatedCharIndex: {lastRepeatedCharIndex}");
                //Console.WriteLine($"currentLength: {currentLength}");
                //Console.WriteLine("-------------------------------------------------------------");
            }

            // Update the final result
            maxLength = maxLength < currentLength ? currentLength : maxLength;

            return maxLength;
        }
        static public int LengthOfLongestSubstringBruthForce(string s)
        {
            // Return immediately if no processing is needed for strings
            if (s.Length == 0) return 0;
            if (s.Length == 1) return 1;

            Dictionary<char, int> charIndexMap = new Dictionary<char, int>();
            int totalMaxLength = 1;  // Overall maximum substring length

            return totalMaxLength;
        }

    }
}
