using System;
using System.Collections.Generic;

namespace ImposterTrie
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie tree = new Trie();
            tree.Insert("hay","hey","hellish","hello","doh");
            List<string> list = tree.GetAllMatchingPrefix("");
            foreach(var word in list)
            {
                Console.WriteLine(word);
            }
        }
    }
}
