using System;
using System.Collections.Generic;
using System.Text;

namespace Pay.Base.Common.Enums.Utils
{
    public class KeyCreator
    {
        public static long CreateKey()
        {
            var bytes = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(bytes, 0);
        }
    }
}
