using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LSFDictionary.Controllers
{
    public class DictionaryController: Controller
    {
        public ActionResult Index(string wts)
        {
            using (Models.IDico dc = new Models.Dico())
            {
                List<Models.Dictionary> listeMot = dc.GetAllWords();

                if (Request.HttpMethod == "POST")
                {
                    string tmpListeMot = String.Empty;
                    string tmpWts = String.Empty;
                    List<Models.Dictionary> res = new List<Models.Dictionary>();

                    for (int i = 0; i < listeMot.Count; i++)
                    {
                        tmpListeMot = listeMot[i].Key.ToLower().Replace(" ", "");
                        tmpWts = wts.ToLower().Replace(" ", "");
                        if (tmpListeMot == tmpWts)
                        {
                            res.Add(listeMot[i]);
                            return View(res);
                        }
                    }
                }
                return View(listeMot);
            }
        }

        public ActionResult Category(string wts)
        {
            using (Models.IDico dc = new Models.Dico())
            {
                List<Models.Dictionary> listeMot = dc.GetAllWords();

                if (Request.HttpMethod == "POST")
                {
                    List<Models.Dictionary> res = new List<Models.Dictionary>();

                    for (int i = 0; i < listeMot.Count; i++)
                    {
                        if (listeMot[i].Key == wts)
                        {
                            res.Add(listeMot[i]);
                            return View(res);
                        }
                    }
                }
                return View(listeMot);
            }
        }
        public ActionResult ListWords()
        {
            using (Models.IDico dc = new Models.Dico())
            {
                List<Models.Dictionary> listeMot = dc.GetAllWords();
                //Trier par odre alphabetique
                listeMot.Sort();
                return View(listeMot);
            }
        }
        private static bool IsNotLetter(Models.Dictionary d)
        {
            return d.Cate != "Lettre";
        }

        public ActionResult ListLetters()
        {
            using (Models.IDico dc = new Models.Dico())
            {
                List<Models.Dictionary> listeMot = dc.GetAllWords();
                //Trier par odre alphabetique
                listeMot.Sort();
                listeMot.RemoveAll(IsNotLetter);
                return View(listeMot);
            }
        }
        public ActionResult FindWords(string wts)
        {
            using (Models.IDico dc = new Models.Dico())
            {
                if (Request.HttpMethod == "POST")
                {
                    List<Models.Dictionary> listeMot = dc.GetAllWords();
                    List<Models.Dictionary> res = new List<Models.Dictionary>();
                    Random rand = new Random();
                    string tmpListeMot = String.Empty;
                    string tmpWts = String.Empty;
                    int i;

                    i = rand.Next(0, listeMot.Count);
                    tmpListeMot = listeMot[i].Key.ToLower().Replace(" ", "");
                    tmpWts = wts.ToLower().Replace(" ", "");
                    if (tmpListeMot == tmpWts)
                    {
                        listeMot[i].Key = "Bonne réponse";
                        res.Add(listeMot[i]);
                    }
                    else
                    {
                        listeMot[i].Key = "Mauvaise réponse";
                        res.Add(listeMot[i]);
                    }
                    return View(res);
                }
                else // if request is GET
                {
                    List<Models.Dictionary> listeMot = dc.GetAllWords();
                    return View(listeMot);
                }
            }
        }
    }
}