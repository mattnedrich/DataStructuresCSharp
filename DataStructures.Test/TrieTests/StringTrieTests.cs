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
        public void Adding_Test_Does_Not_Add_Prefixes()
        {
            trie.Add("test");
            Assert.False(trie.Contains("t"));
            Assert.False(trie.Contains("te"));
            Assert.False(trie.Contains("tes"));
            Assert.True(trie.Contains("test"));
        }

        [Test]
        public void Can_Remove_Entries_From_Trie()
        {
            Assert.False(trie.Contains("test"));
            trie.Add("test");
            Assert.True(trie.Contains("test"));
            trie.Remove("test");
            Assert.False(trie.Contains("test"));
        }

        [Test]
        public void Ignores_Apostrophes()
        {
            trie.Add("Bob's");
            Assert.True(trie.Contains("Bob's"));
            Assert.True(trie.Contains("Bobs"));
            trie.Remove("bob's");
            Assert.False (trie.Contains("Bob's"));
            Assert.False(trie.Contains("Bobs"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Adding_Null_String_Throws_ArgumentNullException()
        {
            trie.Add(null);
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
