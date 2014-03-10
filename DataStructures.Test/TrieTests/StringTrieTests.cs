using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MattNedrich.DataStructures.Trie;

namespace DataStructures.Test.TrieTests
{
    [TestFixture]
    public class StringTrieTests
    {
        private StringTrie trie = null;

        [SetUp]
        public void Setup()
        {
            trie = new StringTrie();
        }

        [Test]
        public void Can_Add_String_To_Trie()
        {
            trie.Add("test");
            Assert.True(trie.Contains("test"));
        }

        [Test]
        public void Integration_Tests()
        {
            trie.Add("dog");
            trie.Add("tree");
            trie.Add("frog");
            trie.Add("house");
            trie.Add("computer");

            Assert.True(trie.Contains("dog"));
            Assert.True(trie.Contains("tree"));
            Assert.True(trie.Contains("frog"));
            Assert.True(trie.Contains("house"));
            Assert.True(trie.Contains("computer"));
            Assert.False(trie.Contains("dogs"));
            Assert.False(trie.Contains("monday"));
        }
    }
}
