using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

namespace Altab
{
    public class SpellChecker
    {
        private const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static List<string> Edits(string word)
        {
            if (word == null)
                return null;
            if (word == string.Empty) return new List<string>() { string.Empty };

            List<string> edits = new List<string>(54 * word.Length + 25);

            List<Tuple<string, string>> splits = new List<Tuple<string, string>>();
            for (int i = 0; i < word.Length + 1; i++)
            {
                splits.Add(new Tuple<string, string>(
                    word.Substring(0, i),
                    word.Substring(i, word.Length - i)
                    ));
            }

            //deletes
            for (int i = 0; i < splits.Count - 1; i++)
            {
                edits.Add(splits[i].Item1 +
                    splits[i].Item2.Substring(1));
            }

            //transposes 
            for (int i = 0; i < splits.Count - 2; i++)
            {
                edits.Add(splits[i].Item1 +
                    splits[i].Item2[1] +
                    splits[i].Item2[0] +
                    splits[i].Item2.Substring(2));
            }

            //replaces
            for (int i = 0; i < splits.Count - 1; i++)
            {
                for (int j = 0; j < letters.Length; j++)
                {
                    edits.Add(splits[i].Item1 +
                        letters[j] +
                       splits[i].Item2.Substring(1));
                }
            }

            //inserts    
            for (int i = 0; i < splits.Count; i++)
            {
                for (int j = 0; j < letters.Length; j++)
                {
                    edits.Add(splits[i].Item1 +
                        letters[j] +
                       splits[i].Item2);
                }
            }

            return edits;
        }


        public static List<string> Edits(List<string> words)
        {
            int lenght = words[0].Length;
            //n - 1 = n
            int sum = (lenght * 54 + 25) * (lenght +1);
            ++lenght;
            //n = (n - 1) + 26n
            sum += (lenght * 54 + 25) * (lenght - 1 + 26 * lenght);
            ++lenght;
            //26(n+1)
            sum += (lenght * 54 + 25) * 26 * (lenght);

            List<string> edits = new List<string>(sum);

            for (int i = 0; i < words.Count; i++)
            {
                edits.AddRange(Edits(words[i]));
            }
            return edits;
        }
        


        //public IEnumerable<string> Corrections(string word)
        //{
        //    if (corpus.Contains(word)) return new[] { word };

        //    var edits = Edits(word);

        //    var knownEdits = corpus.Known(edits);

        //    if (knownEdits.Any())
        //    {
        //        return knownEdits
        //            .OrderByDescending(corpus.Rank);
        //    }

        //    var secondPass = from e1 in edits
        //                     from e2 in Edits(e1)
        //                     where corpus.Contains(e2)
        //                     select e2;

        //    return secondPass.Any() ? secondPass.OrderByDescending(corpus.Rank) : null;
        //    //return secondPass.Any() ? secondPass : new[] { word };
        //}

        //public string Correct(string word)
        //{
        //    string wordCorrection = null;

        //    var corrections = Corrections(word);

        //    if (corrections != null)
        //    {
        //        wordCorrection = corrections
        //            .First();
        //    }

        //    return wordCorrection;
        //}

        //}

        //    return corrections.First();
        //    var corrections = Corrections(word).OrderByDescending(corpus.Rank);
        //{

        //public string Correct(string word)
    }

    //internal interface ICorpus
    //{
    //    int Rank(string word);
    //    bool Contains(string word);
    //    IEnumerable<string> Known(IEnumerable<string> words);
    //}

    //internal class Corpus : ICorpus
    //{
    //    private readonly Dictionary<string, int> rankings;

    //    public Corpus(string sample) : this(ExtractWords(sample))
    //    {
    //    }

    //    public Corpus(IEnumerable<string> sample)
    //    {
    //        rankings = sample.Select(w => w.ToLower())
    //            .GroupBy(w => w)
    //            .ToDictionary(w => w.Key, w => w.Count());
    //    }

    //    public int Rank(string word)
    //    {
    //        int ret;
    //        return rankings.TryGetValue(word, out ret) ? ret : 1;
    //    }

    //    public bool Contains(string word)
    //    {
    //        return rankings.ContainsKey(word);
    //    }

    //    public IEnumerable<string> Known(IEnumerable<string> words)
    //    {
    //        return words.Where(Contains);
    //    }

    //    private static IEnumerable<string> ExtractWords(string str)
    //    {
    //        return Regex.Matches(str, "[a-z]+", RegexOptions.IgnoreCase)
    //            .Cast<Match>()
    //            .Select(m => m.Value);
    //    }
    //}

    //internal static class StringExtensions
    //{
    //    public static string From(this string str, int n)
    //    {
    //        if (str == null) return null;

    //        var len = str.Length;

    //        if (n >= len) return "";
    //        if (n == 0 || -n >= len) return str;

    //        return str.Substring((len + n) % len, (len - n) % len);
    //    }

    //    public static string To(this string str, int n)
    //    {
    //        if (str == null) return null;

    //        var len = str.Length;

    //        if (n == 0 || -n >= len) return "";
    //        if (n >= len) return str;

    //        return str.Substring(0, (len + n) % len);
    //    }
    //}
}