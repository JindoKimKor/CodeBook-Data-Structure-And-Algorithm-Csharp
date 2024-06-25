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
            int totalMaxLength = 1;
            int currentMaxLength = 1;
            int prevIndex;
            int lastSameCharacterIndexFlag = 0;
            int currentLength = 1;

            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0 || !charIndexMap.ContainsKey(s[i]))
                {
                    charIndexMap[s[i]] = i;
                    if (i != 0) currentLength++;
                }
                else // Same Character Key
                {
                    prevIndex = charIndexMap[s[i]];

                    charIndexMap[s[i]] = i;

                    if (prevIndex > lastSameCharacterIndexFlag)
                    {
                        lastSameCharacterIndexFlag = prevIndex;
                        currentMaxLength = i - prevIndex;
                        if (i != s.Length - 1)
                        {
                            currentLength = 1;
                        }
                    }
                }
            }
            totalMaxLength = currentLength > totalMaxLength ? currentLength : totalMaxLength;
            return totalMaxLength;
        }
    }
}
