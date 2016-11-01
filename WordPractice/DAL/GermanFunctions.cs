using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordPractice.Model.Models;
using WordPractice.Util;

namespace WordPractice.DAL
{
    public class GermanFunctions
    {
        public static German GetWordById(int id)
        {
            German german;
            using (DataBaseContext db = new DataBaseContext())
            {
                german = db.GermanTable.FirstOrDefault(p=>p.Id == id);
            }
            return german;
        }

        public static List<int> GetWordIds(string firstForm)
        {
            List<int> searchedIds = new List<int>();

            using (DataBaseContext db = new DataBaseContext())
            {
                List<German> tempGermans = db.GermanTable.Where(p => p.FirstFrom == firstForm).ToList();
                searchedIds.AddRange(tempGermans.Select(actItem => actItem.Id));
            }
            return searchedIds;
        }

        public static string GetOtherForm(int id, int wantedForm)
        {
            German actWord = GetWordById(id);
            //maybe I should handle it in an uper layer
            switch (wantedForm)
            {
                case 2:
                    return actWord.SecondForm;
                    break;
                case 3:
                    return actWord.ThirdForm;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static Answer CheckIfWordIsCorrect(List<int> ids, string userAnswer, int wantedForm)
        {
            Answer actAnswer = new Answer();
            //if (ids.Count==1)
            //{
            //    if (userAnswer==GetOtherForm(ids.FirstOrDefault(), wantedForm))
            //    {
            //        actAnswer.IsCorrect = true;
            //    }
            //    else
            //    {
            //        actAnswer.IsCorrect = false;
            //        actAnswer.RightAnswer = GetOtherForm(ids.FirstOrDefault(), wantedForm);
            //    }
            //}


            string actForm = "";
            actAnswer.IsCorrect = false;
            foreach (var actId in ids)
            {
                actForm = GetOtherForm(actId, wantedForm);
                if (wantedForm == 3)
                {
                    actAnswer.AdditionalInfo.Add(actForm);
                }

                if (userAnswer == actForm)
                {
                    actAnswer.IsCorrect = true;
                    actAnswer.AdditionalInfo.Remove(actForm);
                }
            }
            if (actAnswer.IsCorrect == false)
            {
                actAnswer.RightAnswer = actForm;
                actAnswer.AdditionalInfo.Remove(actForm);
            }
            return actAnswer;
        }
    }
}