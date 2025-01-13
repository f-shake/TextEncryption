using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextEncryption
{
    public class TextEncryptor
    {
        private readonly static UnicodeRange[] rangeLookup;

        private readonly string password;

        private readonly Dictionary<UnicodeRange, char[]> reversedShuffledCharLists = new Dictionary<UnicodeRange, char[]>();

        private readonly Dictionary<UnicodeRange, char[]> shuffledCharLists = new Dictionary<UnicodeRange, char[]>();

        static TextEncryptor()
        {
            rangeLookup = CreateRangeLookup();
        }
        public TextEncryptor(string password)
        {
            this.password = password;
        }

        public string Decrypt(string input)
        {
            var output = new StringBuilder(input.Length);
            int passwordIndex = 0;

            foreach (char ch in input)
            {
                if (NeedProcess(ch))
                {
                    UnicodeRange range = rangeLookup[ch];
                    GetShuffledCharLists(range, out _, out char[] charList);
                    char newChar = charList[ch - range.Start];

                    output.Append(newChar);
                    passwordIndex++;
                }
                else
                {
                    output.Append(ch); // Keep characters not in any range as is
                }
            }

            return output.ToString();
        }

        public string Encrypt(string input)
        {
            var output = new StringBuilder(input.Length);
            int passwordIndex = 0;

            foreach (char ch in input)
            {
                if (NeedProcess(ch))
                {
                    UnicodeRange range = rangeLookup[ch];
                    GetShuffledCharLists(range, out char[] charList, out _);
                    char newChar = charList[ch - range.Start];

                    output.Append(newChar);
                    passwordIndex++;
                }
                else
                {
                    output.Append(ch);
                }
            }

            return output.ToString();
        }

        private static UnicodeRange[] CreateRangeLookup()
        {
            var lookup = new UnicodeRange[char.MaxValue + 1];
            foreach (var range in UnicodeRange.Ranges)
            {
                for (int i = range.Start; i <= range.End; i++)
                {
                    lookup[i] = range;
                }
            }
            return lookup;
        }

        private void GenerateShuffleList(UnicodeRange range)
        {
            var charList = new char[range.End - range.Start + 1];
            for (int i = 0; i < charList.Length; i++)
            {
                charList[i] = (char)(i + range.Start);
            }

            ShuffleList(charList, password);
            var reversedCharList = new char[range.End - range.Start + 1];
            for (int i = 0; i < reversedCharList.Length; i++)
            {
                reversedCharList[charList[i] - range.Start] = (char)(i + range.Start);
            }
            shuffledCharLists[range] = charList;
            reversedShuffledCharLists[range] = reversedCharList;
        }

        private void GetShuffledCharLists(UnicodeRange range,
                out char[] shuffleList,
            out char[] reversedShuffleList)
        {
            if (!shuffledCharLists.ContainsKey(range))
            {
                GenerateShuffleList(range);
            }
            shuffleList = shuffledCharLists[range];
            reversedShuffleList = reversedShuffledCharLists[range];
        }
        private bool NeedProcess(char ch) => !char.IsControl(ch)
                            && !char.IsWhiteSpace(ch)
                            && !char.IsPunctuation(ch)
                            && rangeLookup[ch] != null;

        private void ShuffleList(char[] list, string password)
        {
            long seed = 0;
            for (int i = 0; i < password.Length; i++)
            {
                seed = (seed * 31 + password[i]) % int.MaxValue;
            }
            MersenneTwister mt = new MersenneTwister((uint)seed);

            for (int i = list.Length - 1; i > 0; i--)
            {
                int j = mt.Next(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }

    }

}
