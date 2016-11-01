using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordPractice.DAL;
using WordPractice.Model.Models;

namespace WordPractice.Util
{
    public class GermanTestSheet
    {
        public int Points { get; set; }
        public int WordCount { get; set; }
        public List<German> WordList { get; set; }
        public List<string> UserSecondForms { get; set; }
        public List<string> UserThirdForms { get; set; }
        public void GenerateNewTestSheet()
        {
            List<German> words;
            using (DataBaseContext db = new DataBaseContext())
            {
                words = db.GermanTable.ToList();
            }

            for (int i = 0; i < WordCount; i++)
            {
                Random rnd = new Random();
                //TODO: implement the first n word function by replacing the words.Count to a custom value
                int actWordNumber = rnd.Next(0, words.Count);
                WordList.Add(words[actWordNumber]);
                words.Remove(words[actWordNumber]);
            }
        }

        public int EvaluateTestSHeet()
        {
            //TODO: implement to show the right and wrong answers and additional informations
            for (int i = 0; i < WordCount; i++)
            {
                Answer actAnswer = GermanFunctions.CheckIfWordIsCorrect(GermanFunctions.GetWordIds(WordList[i].SecondForm), UserSecondForms[i], 2);
                if (actAnswer.IsCorrect)
                {
                    Points++;
                }

                actAnswer = GermanFunctions.CheckIfWordIsCorrect(GermanFunctions.GetWordIds(WordList[i].ThirdForm), UserThirdForms[i], 3);
                if (actAnswer.IsCorrect)
                {
                    Points++;
                }
            }
            return Points;
        }
    }
}