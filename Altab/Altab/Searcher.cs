using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Altab
{
    public static class Searcher
    {
        static List<string> lista = new List<string>();
        static private Regex regex = new Regex("");
        public static void OnStart()
        {
            lista.Add("Tu vieja");
            lista.Add("Tu hermana");
            lista.Add("Mi padrino");
        }

        public static List<string> SearchAll(string search)
        {
            regex = new Regex(search, RegexOptions.IgnoreCase, new TimeSpan(0, 0, 5));
            return lista.Where(list => regex.IsMatch(list)).ToList();
        }
    }
}
