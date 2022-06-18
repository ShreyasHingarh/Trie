using System;

namespace ImposterTrie
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie tree = new Trie();
            tree.Insert("hay","hey","hellish","hello","doh");
            
            ;
            Console.Write(tree.Remove("hello"));
            ;
        }
    }
}
