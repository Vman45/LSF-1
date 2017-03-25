using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSFDictionary.Models
{
    public interface IJeux : IDisposable
    {
        List<Score> getScores();
        void AddScore(int id, int niveau, int value, string cate, int tours);

        List<Score> getScore(int id);

        void setTour(int tours, int id);

        void setValue(int value, int id);

    }
}