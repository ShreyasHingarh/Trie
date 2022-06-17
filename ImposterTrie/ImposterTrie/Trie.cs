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
        public override string ToString()
        {
            string togive = $"Value: {Letter} \n Children: ";
            foreach(var child in Children)
            {
                togive += $"{child.Key}, ";
            }
            return togive;
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
            TrieNode startingPoint = sentinalBeing;
            for (int i = 0; i < word.Length; i++)
            {
                if (!startingPoint.Children.ContainsKey(word[i]))
                {
                    startingPoint.Children.Add(word[i], new TrieNode(word[i]));
                }
                startingPoint = startingPoint.Children[word[i]];
            }
            startingPoint.IsWord = true;
        }
        public void Insert(params string[] words)
        {
            for(int i = 0;i < words.Length;i++)
            {
                Insert(words[i]);
            }
        }
        public string FindWord(string word )
        {
            return null;
        }
        public bool Contains(string word)
        {
            return FindWord(word) != null;
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
