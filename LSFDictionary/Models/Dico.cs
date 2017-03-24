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


        public List<Dictionary> GetAllLetters()
        {
            return bdd.Dictionaries.ToList();
        }

        List<Letter> IDico.GetAllLetters()
        {
            throw new NotImplementedException();
        }


        // Récupère 1 mots randome
        public List<Dictionary> GetWord(int niveau, string cate)
        {

            return bdd.Dictionaries.Where(dico => dico.Niveau == niveau && dico.Cate == cate).OrderBy(dico => Guid.NewGuid()).Take(1).ToList();
        }
        // Récupère 3 mots randome
        public List<Dictionary> GetWordRandom(string cate)
        {
            return bdd.Dictionaries.Where(dico => dico.Cate == cate).OrderBy(dico => Guid.NewGuid()).Take(3).ToList();

        public List<Dictionary> GetWordsCategory(string cate)
        {
            return bdd.Dictionaries.Where(dico => dico.Cate == cate).ToList();

        }
    }
}