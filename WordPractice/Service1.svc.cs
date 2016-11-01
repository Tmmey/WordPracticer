using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WordPractice.Model.Models;

namespace WordPractice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool AddNewWord(string first, string second, string third)
        {
            if (first.Equals("") || second.Equals("") || third.Equals(""))
            {
                return false;
            }

            German german = new German
            {
                FirstFrom = first,
                SecondForm = second,
                ThirdForm = third
            };

            using (DataBaseContext db = new DataBaseContext())
            {
                db.GermanTable.Attach(german);
                db.GermanTable.Add(german);
                db.SaveChanges();
            }
                return true;
        }
    }
}
