using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LSFDictionary.Models
{
    public class Jeux : IJeux
    {
        private BddContext bdd;

        public Jeux()
        {
            bdd = new BddContext();
        }

        public List<Score> GetScore()
        {
            return bdd.Scores.ToList();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public void AddScore(int niveau, int value, string cate)
        {
            bdd.Scores.Add(new Score { Niveau = niveau, Value = value, Cate = cate });
            bdd.SaveChanges();
        }
    }
}