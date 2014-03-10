using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MattNedrich.DataStructures.Trie
{
    public class StringTrie
    {
        private StringTrieLevel root;
        private const int baseCode = (int)'a';

        public StringTrie()
        {
            root = new StringTrieLevel();
        }

        public void Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("Input to StringTrie.Add cannot be null or empty");
            char[] chars = input.ToLower().ToArray();
            StringTrieEntry entry = ForceSearch(root, chars, 0);
            entry.Set = true;
        }

        public void Remove(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("Input to StringTrie.Remove cannot be null or empty");
            char[] chars = input.ToLower().ToArray();
            StringTrieEntry entry = Search(root, chars, 0);
            if(entry != null)
                entry.Set = false;
        }

        public bool Contains(string input)
        {
            if(string.IsNullOrEmpty(input))
                throw new ArgumentNullException("Input to StringTrie.Contains cannot be null or empty");
            char[] chars = input.ToLower().ToArray();
            StringTrieEntry entry = Search(root, chars, 0);
            if (entry == null)
                return false;
            else
                return entry.Set;
        }

        /// <summary>
        /// Searches the Trie, but does not continue the search if a null entry is encountered
        /// </summary>
        /// <returns>The desired StringTrieEntry if it exists, null otherwise</returns>
        private StringTrieEntry Search(StringTrieLevel level, char[] chars, int charIndex)
        {
            int arrIndex = CharToInt(chars[charIndex]);
            if (charIndex == chars.Length - 1)
                return level.Entries[arrIndex];
            else if (arrIndex < 0)
                return ForceSearch(level, chars, ++charIndex);
            else
            {
                StringTrieLevel nextLevel = level.Entries[arrIndex].Next;
                if (nextLevel == null)
                    return null;
                return Search(nextLevel, chars, ++charIndex);
            }
        }

        /// <summary>
        /// Searches the Trie. If a null entry is encountered, new entries are created and the search continues.
        /// ForceSearch ensures that a path down to the last char in the char[] exists.
        /// </summary>
        /// <returns>The desired StringTrieEntry. This will not be null</returns>
        private StringTrieEntry ForceSearch(StringTrieLevel level, char[] chars, int charIndex)
        {
            int arrIndex = CharToInt(chars[charIndex]);
            if (charIndex == chars.Length - 1)
                return level.Entries[arrIndex];
            else if (arrIndex < 0)
                return ForceSearch(level, chars, ++charIndex);
            else
            {
                StringTrieLevel nextLevel = level.Entries[arrIndex].Next;
                if (nextLevel == null)
                {
                    nextLevel = new StringTrieLevel();
                    level.Entries[arrIndex].Next = nextLevel;
                }
                return ForceSearch(nextLevel, chars, ++charIndex);
            }
        }

        private int CharToInt(char c)
        {
            return (int)c - baseCode;
        }
    }



}
