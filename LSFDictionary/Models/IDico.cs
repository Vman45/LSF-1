using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSFDictionary.Models
{
    public interface IDico : IDisposable
    {
        //Words
        List<Dictionary> GetAllWords();
        void AddSignedWord(string key, string value);
        void ModifySignedWord(int id, string key, string value);
        bool ExistedWord(string key);

        //Letters
        List<Letter> GetAllLetters();

        // Récupère 1 mots randome
        List<Dictionary> GetWord(int niveau, string cate);
        // Récupère 3 mots randome
        List<Dictionary> GetWordRandom(string cate);

        List<Dictionary> GetWordsCategory(string cate);

    }
}
