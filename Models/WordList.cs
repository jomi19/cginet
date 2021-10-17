using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Test.Models
{
    public class WordList
    {
        public Dictionary <string, int> wordCount = new();
        public WordList(string text) {
            text = Regex.Replace(text.Replace("\n", " "), @"[^a-zA-z ]", "").ToLower();
            string[] words = text.Split(' ');

            foreach(string word in words)
            {
                if(!(wordCount.ContainsKey(word)))
                {
                    wordCount.Add(word, 1);
                } else {
                    wordCount[word]++;
                }
            }
        }

        public Dictionary<String, int> GetTopList()
        {
            int loopCounter = 0;
            Dictionary<String, int> topList = new();
            var sortedDict = from entry in wordCount orderby entry.Value descending select entry;

            foreach(KeyValuePair<string, int> kvp in sortedDict)
            {
                loopCounter++;
                topList.Add(kvp.Key, kvp.Value);
                if(loopCounter == 10) break;
            }

            return topList;
        }  
    }
}