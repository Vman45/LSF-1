using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LSFDictionary.Models
{
    public class Dico : IDico
    {
        private BddContext bdd;

        public Dico()
        {
            bdd = new BddContext();
        }

        public List<Dictionary> GetAllWords()
        {
            return bdd.Dictionaries.ToList();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public void AddSignedWord(string key, string value)
        {
            bdd.Dictionaries.Add(new Dictionary { Key = key, Value = value });
            bdd.SaveChanges();
        }

        public void ModifySignedWord(int id, string key, string value)
        {
            Dictionary findedWord = bdd.Dictionaries.FirstOrDefault(dico => dico.Id == id);
            if (findedWord != null)
            {
                findedWord.Key = key;
                findedWord.Value = value;
                bdd.SaveChanges();
            }
        }

        public bool ExistedWord(string key)
        {
            return bdd.Dictionaries.Any(dictionary => string.Compare(dictionary.Key, key, StringComparison.CurrentCultureIgnoreCase) == 0);
        }
    }
}