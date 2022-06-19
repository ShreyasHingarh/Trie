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
        private TrieNode SearchNode(string word)
        {
            TrieNode node = sentinalBeing;
            for (int i = 0; i < word.Length; i++)
            {
                if(!node.Children.ContainsKey(word[i]))
                {
                    return null;
                }
                node = node.Children[word[i]];
            }
            return node;
        }
        public bool Contains(string word)
        {
            return SearchNode(word) != null;
        }
        public List<string> GetAllMatchingPrefix(string prefix)
        {
            TrieNode node = sentinalBeing;
            for (int i = 0; i < prefix.Length; i++)
            {
                if (!node.Children.ContainsKey(prefix[i]))
                {
                    return new List<string>();
                }
                node = node.Children[prefix[i]];
            }
            List<string> strings = new List<string>();
            string lettersInPrefix = "";

            for(int i = 0;i < prefix.Length - 1;i++)
            {
                lettersInPrefix += prefix[i];
            }
             return GetWords(node, strings, lettersInPrefix);
            

        }
        public List<string> GetWords(TrieNode startingPoint, List<string> stringsGotten, string lettersGotten)
        {
            lettersGotten += startingPoint.Letter;

            if (startingPoint.IsWord)
            {
                stringsGotten.Add(lettersGotten);
            }
            foreach(var value in startingPoint.Children.Values)
            {
                GetWords(value, stringsGotten, lettersGotten);
            }
            return stringsGotten;
        }
        public bool Remove(string word)
        {
            if (!Contains(word))
            {
                return false;
            }
            Stack<TrieNode> nodes = new Stack<TrieNode>();
            TrieNode node = sentinalBeing;
            for (int i = 0; i < word.Length; i++)
            {
                node = node.Children[word[i]];
                nodes.Push(node);
            }
            int Count = word.Length - 1;
            while (nodes.Peek() != null)
            {
                TrieNode nodeAtQuestion = nodes.Peek();
                if (nodeAtQuestion.Children.Count == 0)
                {
                    nodes.Pop();
                    nodes.Peek().Children.Remove(word[Count]);
                }
                else if (nodeAtQuestion.Children.Count > 0)
                {
                    if (nodes.Peek().IsWord && Count == word.Length - 1)
                    { 
                        nodes.Peek().IsWord = false;
                    }
                    break;
                }
                Count--;
            }
            return true;
        }

       
    }
}
