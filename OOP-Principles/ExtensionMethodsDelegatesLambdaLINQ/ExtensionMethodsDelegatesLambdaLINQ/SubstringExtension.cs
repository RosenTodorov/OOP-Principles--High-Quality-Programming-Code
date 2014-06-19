using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringExtension
{
    public static class SubstringExt
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            StringBuilder result = new StringBuilder(length);
          /*  string rawData = sb.ToString();

            return result.Append(rawData.Substring(index, length)); */
            for (int i = index; i < (index + length); i++)
            {
                result.Append(sb[index]);
            }
            return result;
        }
    }
}
                
     

