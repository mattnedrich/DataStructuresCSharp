using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MattNedrich.DataStructures.Trie
{
    internal class StringTrieEntry
    {
        public bool Set { get; set; }
        public StringTrieLevel Next { get; set; }
        public StringTrieEntry()
        {
            Set = false;
            Next = null;
        }
    }
}
