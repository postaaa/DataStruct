using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStruct;

namespace DataStruct.ByteArray
{
    public class ByteArrayTest1
    {
        public static void test()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string ss = "I am a string !,我是一个字符串！";
            byte[] unicodeA = StringToBytes(ss, Encoding.Unicode);
            byte[] unicode16 = StringToBytes(ss, Encoding.Unicode);
            byte[] utf8A = StringToBytes(ss, Encoding.UTF8);
            byte[] gb2312A = StringToBytes(ss, Encoding.GetEncoding("gb2312"));

            Console.WriteLine(unicodeA.Length);
            Console.WriteLine(gb2312A.Length);
            Console.WriteLine(utf8A.Length);
        }

        static byte[] StringToBytes(string s, Encoding encoding)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            return encoding.GetBytes(s);
        }
    }
}