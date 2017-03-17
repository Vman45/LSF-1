using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSFDictionary.Models
{
    public interface IJeux : IDisposable
    {
        List<Score> GetScore();
        void AddScore(int niveau, int Value, string cate);

    }
}