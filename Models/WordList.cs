using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Test.Models
{
    public class WordList
    {
        public Dictionary <string, int> ListWords = new();
        public WordList(string text) {
            text = Regex.Replace(text, @"[.!,'?()]", "").Replace("\n", " ").ToLower();
            string[] words = text.Split(' ');

            foreach(string word in words)
            {
                if(!(ListWords.ContainsKey(word)))
                {
                    ListWords.Add(word, 1);
                } else {
                    ListWords[word]++;
                }
            }

        }

        public Dictionary<String, int> GetTopList()
        {
            List<String> topList = new();
            Dictionary<String, int> outPut = new();

            foreach(KeyValuePair<string, int> word in ListWords)
            {
                if(topList.Count < 10) 
                {
                    topList.Add(word.Key);
                } 
                else 
                {
                    if(ListWords[topList[9]] < word.Value) 
                    {
                        topList[9] = word.Key;
                    }
                } 
                topList.Sort(delegate(string x, string y)
                {
                    if(x == null && y == null) return 0;
                    else if(x == null) return -1;
                    else if (y == null) return 1;
                    else return ListWords[x].CompareTo(ListWords[y]);
                });
                topList.Reverse();
            }

            foreach(string word in topList)
            {
                outPut.Add(word, ListWords[word]);
            }
            return outPut;
        }
        
    }
}