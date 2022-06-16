using System;
using System.Collections.Generic;
using System.Text;

namespace ImposterTrie
{
    public class TrieNode
    {
        public char Letter { get; private set; }
        public Dictionary<char, TrieNode> Children { get; private set; }
        public bool IsWord { get; set; }
        public TrieNode(char C)
        {
            Children = new Dictionary<char, TrieNode>();
            Letter = C;
            IsWord = false;
        }
    }
    public class Trie
    {
        TrieNode sentinalBeing = new TrieNode('$');
        public void Clear()
        {
            sentinalBeing = new TrieNode('$');
        }
        public void Insert(string word)
        {

        }
        public string FindWord(string word )
        {
            return null;
        }
        public bool Contains(string word)
        {
            return false;
        }
        public List<string> GetAllMatchingPrefix(string prefix)
        {
            return null;
        }
        public bool Remove(string prefix)
        {
            return true;
        }
    }
}
