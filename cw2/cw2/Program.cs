using cw2.data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "data/dane.csv";

            FileInfo f = new FileInfo(file);
            using (StreamReader stream = new StreamReader(f.OpenRead()))
            {


                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    string[] studentWiersz = line.Split(",");
                    Console.WriteLine(line);

                    Studia s = new Studia
                    {
                        nazwa = studentWiersz[2],
                        tryb = studentWiersz[3],
                    };

                    var stu = new Student
                    {
                        Imie = studentWiersz[0],
                        Nazwisko = studentWiersz[1],
                        stud = s,
                        Email = studentWiersz[0]
                    };
                }
            }

            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), 
                                            new XmlRootAttribute("uczelnia"));
            
            
            var list = new List<Student>();
            var set = new HashSet<Student>();
            var st = new Student
            {
                Imie = "jan",
                Nazwisko = "Kowalski",
                Email = "kowalski@wp.pl"
            };
            list.Add(st);
            
            //...
            serializer.Serialize(writer, list);
            //stream.Dispose();//... IDisposable
        }
    }
}
