using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MattNedrich.DataStructures.Trie
{
    public class StringTrie
    {
        TrieLevel root;
        int baseCode = (int)'a';

        public StringTrie()
        {
            root = new TrieLevel();
        }

        public void Add(string input)
        {
            TrieLevel current = root;
            char[] chars = input.ToLower().ToArray();
            for(int i=0; i<chars.Length; i++)
            {
                char c = chars[i];
                int index = (int)c - baseCode;
                if (i == chars.Length - 1)
                    current.Entries[index].Set = true;
                else
                {
                    // continue down the tree
                    if (current.Entries[index].Next == null)
                        current.Entries[index].Next = new TrieLevel();
                    current = current.Entries[index].Next;
                }
            }
        }

        public bool Contains(string input)
        {
            bool result = false;
            TrieLevel current = root;
            char[] chars = input.ToLower().ToArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                int index = (int)c - baseCode;
                if (i == chars.Length - 1)
                {
                    result = current.Entries[index].Set;
                    break;
                }
                else
                {
                    // continue down the tree
                    if (current.Entries[index].Next == null)
                        return false;
                    current = current.Entries[index].Next;
                }
            }
            return result;
        }

        private class TrieLevel
        {
            public TrieEntry[] Entries { get; private set; }

            public TrieLevel()
            {
                Entries = new TrieEntry[32];
                for (int i = 0; i < Entries.Length; i++)
                    Entries[i] = new TrieEntry();
            }
        }

        private class TrieEntry
        {
            public bool Set { get; set; }
            public TrieLevel Next { get; set; }
            public TrieEntry()
            {
                Set = false;
                Next = null;
            }
        }
    }



}
