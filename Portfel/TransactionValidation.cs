using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel
{
    public static class TransactionValidation
    {
        public static string ValidateTransaction(string TransactionName, string Amount, DateTime date)
        {
            string errors = "";
            decimal val;

            bool isNum = decimal.TryParse(Amount,out val);

            
            if(TransactionName == "")
            {
                errors += "empty name \n";
            }
           
            if (Amount == "")
            {
                errors += "empty amount \n";
            }

            if(!isNum)
            {
                errors += "invalid amiunt \n";

            }

            if(date == null)
            {
                errors += "invalid date \n";
            }

            return errors;

        }
    }
}
