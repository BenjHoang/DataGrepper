using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DataGrepper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> emails = new List<string>();
            List<string> phones = new List<string>();

            //patterns
            const string Emailpattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            const string PhonePattern = @"\d{3}?\W\d{3}?\W\d{4}?";

            foreach (string lineInt in File.ReadLines("C:/Users/Benj/Desktop/usb256.001"))
            {
                Match m = Regex.Match(lineInt, Emailpattern, RegexOptions.IgnoreCase);
                if (m.ToString() != "")
                {

                    //Console.WriteLine(m);
                    emails.Add(m.ToString());
                    //Console.WriteLine(lineInt.ToString());
                }

                Match k = Regex.Match(lineInt, PhonePattern, RegexOptions.IgnoreCase);
                if (k.ToString() != "")
                {
                    phones.Add(k.ToString());
                }
            }
            Console.WriteLine("removing duplicated");
            List<string> NoDup_emails = emails.Distinct().ToList();
            List<string> NoDup_phones = phones.Distinct().ToList();
            Console.WriteLine("writing to txt files");
            System.IO.File.WriteAllLines("emails.txt", NoDup_emails);
            System.IO.File.WriteAllLines("phones.txt", NoDup_phones);
        }
    }
}
