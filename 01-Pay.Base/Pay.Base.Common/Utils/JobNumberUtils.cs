using System;
using System.Collections.Generic;
using System.Text;

namespace Pay.Base.Common.Enums.Utils
{
    public class JobNumberUtils
    {
        public static int GetJobNumber(int amax, int cmax)
        {            
            if (amax == 0 && cmax == 0)
                return 8001;

            if (amax > cmax)
                return amax + 1;
            else
                return cmax + 1;
        }
    }
}
