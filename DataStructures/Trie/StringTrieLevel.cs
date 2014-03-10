using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MattNedrich.DataStructures.Trie
{
    internal class StringTrieLevel
    {
        public StringTrieEntry[] Entries { get; private set; }

        public StringTrieLevel()
        {
            Entries = new StringTrieEntry[32];
            for (int i = 0; i < Entries.Length; i++)
                Entries[i] = new StringTrieEntry();
        }
    }
}
