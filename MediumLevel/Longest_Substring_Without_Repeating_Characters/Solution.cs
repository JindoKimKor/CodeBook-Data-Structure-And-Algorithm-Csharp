using System.Collections.Generic;

namespace Longest_Substring_Without_Repeating_Characters
{
    static public class Solution
    {
        static public int LengthOfLongestSubstring(string s)
        {
            // return no necessary process needed for strings
            if (s.Length == 0) return 0;
            if (s.Length == 1) return 1;

            Dictionary<char, int> charIndexMap = new Dictionary<char, int>();
            int biggestSubStringLength = 1;
            int conflictedIndex;
            int maxNonConflictingSubstringLength = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (charIndexMap.Count == 0 || !charIndexMap.ContainsKey(s[i]))
                {
                    charIndexMap[s[i]] = i;
                    maxNonConflictingSubstringLength++;
                }
                else
                {
                    conflictedIndex = charIndexMap[s[i]];
                    charIndexMap[s[i]] = i;
                    biggestSubStringLength = biggestSubStringLength < i - conflictedIndex ? charIndexMap[s[i]] - conflictedIndex : biggestSubStringLength;
                    if (i != s.Length - 1)
                    {
                        maxNonConflictingSubstringLength = 1;
                    }
                }
            }
            biggestSubStringLength = maxNonConflictingSubstringLength > biggestSubStringLength ? maxNonConflictingSubstringLength : biggestSubStringLength;
            return biggestSubStringLength;
        }
    }
}
