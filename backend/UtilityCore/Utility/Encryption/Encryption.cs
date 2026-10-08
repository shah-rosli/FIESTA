using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityCore.Utility.Encryption
{
    public class Encryption
    {
        public Encryption()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string getEncriptPassword(string password)
        {
            string finalOutput = "";
            int passwordLength = password.Length;
            string returnValue = string.Empty;
            string firstChar = "";
            int startIndex = 0;

            while (startIndex < password.Length)
            {
                firstChar = password.Substring(startIndex, 1);
                returnValue += Convert.ToString((Convert.ToInt32(Convert.ToChar(firstChar)) + 42));
                startIndex++;
            }

            while (returnValue.Length < 30)
                returnValue += Convert.ToString(returnValue.Length);

            int intReturn;
            for (int i = 0; i < 30; i = i + 2)
            {
                intReturn = Convert.ToInt32(returnValue.Substring(i, 2));
                finalOutput += Convert.ToChar(intReturn);
            }

            return finalOutput;
        }
    }
}
