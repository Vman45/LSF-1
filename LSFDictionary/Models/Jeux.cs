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

        public List<Score> getScores()
        {
            return bdd.Scores.ToList();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        public void AddScore(int niveau, int value, string cate, int tours)
        {
            bdd.Scores.Add(new Score { Niveau = niveau, Value = value, Cate = cate,  });
            bdd.SaveChanges();
        }

        public List<Score> getScore(int id)
        {
            return bdd.Scores.Where(jeux => jeux.Id == id).ToList();
        }
        public void setTour(int tours, int id)
        {
            Score finde = bdd.Scores.FirstOrDefault(jeux => jeux.Id == id);
            if (finde != null)
            {
                finde.Tours = tours;
                bdd.SaveChanges();
            }
        }

        public void setValue(int value, int id)
        {
            Score finde = bdd.Scores.FirstOrDefault(jeux => jeux.Id == id);
            if (finde != null)
            {
                finde.Value = value;
                bdd.SaveChanges();
            }
        }
    }
}