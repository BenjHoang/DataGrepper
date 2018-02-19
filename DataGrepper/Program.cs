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

            Console.WriteLine("Loading Data...");
            foreach (string lineInt in File.ReadLines("usb256.001"))
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
                    //Console.WriteLine(k);
                    phones.Add(k.ToString());
                }
            }
            Console.WriteLine("removing duplicated emails");
            List<string> NoDup_emails = emails.Distinct().ToList();

            foreach (string a in NoDup_emails)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Total Unique items: "+NoDup_emails.Count());

            Console.WriteLine("removing duplicated phones");
            List<string> NoDup_phones = phones.Distinct().ToList();
            foreach (string a in NoDup_phones)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Total Unique Items: " + NoDup_phones.Count());


            Console.WriteLine("writing to txt files");
            System.IO.File.WriteAllLines("emails.txt", NoDup_emails);
            System.IO.File.WriteAllLines("phones.txt", NoDup_phones);
        }
    }
}
