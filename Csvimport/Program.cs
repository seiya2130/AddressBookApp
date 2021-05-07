using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csvimport
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CSV_PATH = @"C:\Users\satoh\Downloads\personal_infomation.csv";
            var list = ReadCsv(CSV_PATH);
            RegistAddresses(list);

        }

        static List<Address> ReadCsv(string path)
        {
            List<Address> list = new List<Address>();

            var encode = new System.Text.UTF8Encoding(false);

            using(var reader = new System.IO.StreamReader(path, encode))
            {
                var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);

                bool isSkip = true;

                while (csv.Read())
                {
                    if (isSkip)
                    {
                        isSkip = false;
                        continue;
                    }

                    Address address = new Address()
                    {
                        Name = csv.GetField<string>(0),
                        Kana = csv.GetField<string>(1),
                        Telephone = csv.GetField<string>(2),
                        Mail = csv.GetField<string>(3),
                        ZipCode = csv.GetField<string>(4).Replace("-",""),
                        Prefecture = csv.GetField<string>(5),
                        StreetAddress = $"{csv.GetField<string>(6)}{csv.GetField<string>(7)}{csv.GetField<string>(8)}{csv.GetField<string>(9)}"

                    };

                    list.Add(address);
                }
            }
            return list;
        }

        static void RegistAddresses(List<Address> addresses)
        {
            using(var db = new AddressBookInfoEntities())
            {
                db.Addresses.AddRange(addresses);
                db.SaveChanges();
            }
        }
    }
}
