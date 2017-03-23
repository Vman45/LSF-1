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
                listeMot.RemoveAll(IsLetter);
                return View(listeMot);
            }
        }
        private static bool IsNotLetter(Models.Dictionary d)
        {
            return d.Cate != "Lettre";
        }
        private static bool IsLetter(Models.Dictionary d)
        {
            return d.Cate == "Lettre";
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

        public ActionResult FindLetters(string wts)
        {
            using (Models.IDico dc = new Models.Dico())
            {
                if (Request.HttpMethod == "POST")
                {
                    List<Models.Dictionary> listeMot = dc.GetAllWords();                    
                    listeMot.RemoveAll(IsNotLetter);
                    listeMot.Sort();
                    List<Models.Dictionary> res = new List<Models.Dictionary>();
                    Char[] wtsTab = wts.ToCharArray();
                    string[] stringArray = new string[wtsTab.Length];
                    for (int i =0; i < wtsTab.Length; i++)
                    {
                        stringArray[i] = Char.ToUpper(wtsTab[i]).ToString();
                        for (int j = 0; j < listeMot.Count; j++)
                        {   
                            if(listeMot[j].Key == Char.ToUpper(wtsTab[i]).ToString())
                            {
                                res.Add(listeMot[j]);
                            }
                        }
                    }
                    
                    return View(res);
                }
                else // if request is GET
                {
                    List<Models.Dictionary> listeMot = dc.GetAllWords();
                    listeMot.RemoveAll(IsNotLetter);
                    listeMot.Sort();
                    return View(listeMot);
                }
            }
        }
        public ActionResult Jeux()
         {
            int Niveau = 1;
            string cate = "Lettre";
    //    public ActionResult Jeux(int Niveau, string cate)
    //    {
            using (Models.IDico dc = new Models.Dico())
            {
                using (Models.IJeux sc = new Models.Jeux())
                {
                    List<Models.Dictionary> reponse = dc.GetWord(Niveau, cate);
                    List<Models.Dictionary> res = dc.GetWordRandom(cate);
                    sc.AddScore(Niveau, 0, cate, 1);
                   // if (Request.HttpMethod == "POST")
                    //{
                        reponse[0].Valide = 1;
                        res[0].Valide = 0;
                        res[1].Valide = 0;
                        res[2].Valide = 0;
                    Random rand = new Random();
                    int i;
                    i = rand.Next(0,4);
                    res.Insert(i, reponse[0]);

                        return View(res);
                 //   }
                  //  return View("erreur");
                }
            }
        }


        public ActionResult ajaxJeux(int scores, int id)
        {

            using (Models.IDico dc = new Models.Dico())
            {
                using (Models.IJeux sc = new Models.Jeux())
                {
                    List<Models.Score> monScore = sc.getScore(id);
                    List<Models.Dictionary> reponse = dc.GetWord(monScore[0].Niveau, monScore[0].Cate);
                    List<Models.Dictionary> res = dc.GetWordRandom(monScore[0].Cate);

                    if (Request.HttpMethod == "POST")
                    {
                        int tour = monScore[0].Tours;
                        int val = monScore[0].Value;
                        if (tour > 9)
                        {
                            return View(monScore);
                        }
                        else
                        {

                            sc.setTour(++tour, id);
                            val = val + scores;
                            sc.setValue(val, id);
                            reponse[0].Valide = 1;
                            res[0].Valide = 0;
                            res[1].Valide = 0;
                            res[2].Valide = 0;
                            Random rand = new Random();
                            int i;
                            i = rand.Next(0, 4);
                            res.Insert(i, reponse[0]);

                            return View(res);
                        }
                    }
                          return View("erreur");
                    }
                }
            }
        }
    }