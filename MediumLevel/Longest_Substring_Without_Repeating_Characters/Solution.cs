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
            int totalMaxLength = 1;  // Overall maximum substring length
            int currentMaxLength = 1;  // Current maximum substring length
            int prevIndex;
            int lastSameCharacterIndexFlag = 0;  // Flag for the last index where the same character appeared
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
                    prevIndex = charIndexMap[s[i]];  // Index of the previous occurrence of the same character

                    charIndexMap[s[i]] = i;  // Update the index of the current character

                    if (prevIndex >= lastSameCharacterIndexFlag)
                    {
                        // If the previously occurred same character is after the current flag
                        lastSameCharacterIndexFlag = prevIndex;  // Update the flag
                        currentMaxLength = i - prevIndex;  // Update the current maximum length
                        totalMaxLength = totalMaxLength < currentLength ? currentLength : totalMaxLength;
                        currentLength = i - lastSameCharacterIndexFlag; // Reset the current substring length
                    }
                    else
                    {
                        currentLength++;
                    }
                }
            }

            // Update the final result
            totalMaxLength = totalMaxLength < currentLength ? currentLength : totalMaxLength;
            return totalMaxLength;
        }
    }
}
