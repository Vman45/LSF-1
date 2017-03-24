using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSFDictionary.Models
{
    public interface IDico : IDisposable
    {
        List<Dictionary> GetAllWords();
        void AddSignedWord(string key, string value);
        void ModifySignedWord(int id, string key, string value);
        bool ExistedWord(string key);
        List<Dictionary> GetWordsCategory(string cate);
    }
}
