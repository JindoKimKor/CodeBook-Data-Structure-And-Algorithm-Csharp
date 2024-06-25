using System;

namespace Longest_Substring_Without_Repeating_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string longestStringWithFiftyThousandLength;
            string emptyString = string.Empty;
            string templateChars = "bcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_=+[{]}\\|;:'\",<.>/?`~ ";
            Random random = new Random();

            char[] charArray = new char[50000];
            for (int i = 0; i < charArray.Length; i++) {
                if (i == 0 || i == 49999)
                {
                    charArray[i] = 'a';
                }
                else
                {
                    charArray[i] = templateChars[random.Next(templateChars.Length)];
                }
            }
            longestStringWithFiftyThousandLength = new string(charArray);
            int emptyReturn = Solution.LengthOfLongestSubstring(emptyString);
            int longestLengthReturn = Solution.LengthOfLongestSubstring(longestStringWithFiftyThousandLength);

            if (emptyReturn == 0 && longestLengthReturn == 49999)
            {
                Console.WriteLine("Congrat!");
                Console.ReadKey();
            }
        }
    }
}
