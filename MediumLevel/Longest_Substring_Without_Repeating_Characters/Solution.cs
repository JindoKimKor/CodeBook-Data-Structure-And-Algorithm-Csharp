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
            char targetChar;
            int conflictedIndex;

            for (int i = 0; i < s.Length; i++)
            {
                targetChar = s[i];//u
                if (i == 0)
                {
                    charIndexMap[s[i]] = i;//charIndexMap[a] = 0                 
                }
                else
                {
                    if (!charIndexMap.ContainsKey(targetChar))
                    {
                        charIndexMap[s[i]] = i;
                        biggestSubStringLength++;
                        if (biggestSubStringLength != (i + 1))
                        {
                            biggestSubStringLength--;
                        }
                    }
                    else
                    {
                        conflictedIndex = charIndexMap[s[i]];//aab
                        charIndexMap[s[i]] = i;
                        int temNumber = charIndexMap[s[i]] - conflictedIndex;
                        biggestSubStringLength = temNumber > biggestSubStringLength ? temNumber : biggestSubStringLength;
                    }
                }
            }
            return biggestSubStringLength;
        }
    }
}
