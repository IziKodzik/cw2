using cw2.data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "data/dane.csv";

            FileInfo f = new FileInfo(file);
            List<Student> los = new List<Student>();
            using (StreamReader stream = new StreamReader(f.OpenRead()))
            {


                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    string[] studentWiersz = line.Split(",");
                    //Console.WriteLine(line);

                    Studia s = new Studia
                    {
                        nazwa = studentWiersz[2],
                        tryb = studentWiersz[3],
                    };

                    var stu = new Student
                    {
                        Imie = studentWiersz[0],
                        Nazwisko = studentWiersz[1],
                        index = int.Parse(studentWiersz[4]),
                        stud = s,
                        DataUrodzenia = studentWiersz[5],
                        Email = studentWiersz[6],
                        Ojciec = studentWiersz[8],
                        Matka = studentWiersz[7]
                    };
                    los.Add(stu);
                }
            }
            Uczelnia uczelnia = new Uczelnia
            {
                data = DateTime.Now,
                autor = "Michał Zieliński",
                student = los.Distinct(new EqualityComp()).ToList<Student>()
            };
            /*
            ModelList result = new ModelList
            {
                List = los.Distinct(new EqualityComp()).ToList<Student>()
            };
            */
            //result.list = 
            //Console.WriteLine("dup: " + (pocz - result.Count));
            //foreach(Student res in result)
            //{
                //Console.WriteLine(res.ToString());
            //}

            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlRootAttribute rotatr = new XmlRootAttribute("studenci");
            XmlSerializer serializer = new XmlSerializer(typeof(Uczelnia));
            /*
            XmlWriter xmlWriter = XmlWriter.Create("data2.xml");

            XmlDocument document = new XmlDocument();
            document.LoadXml("<uczelnia></uczelnia>");
            XmlElement header = document.DocumentElement;
            header.SetAttribute("createdAt",DateTime.Now.ToString());
            header.SetAttribute("author", "Michał Zieliński");

            XmlNode node = document.CreateElement("students");
            */
            /*
            foreach(Student s in result.List)
            {
                XmlElement e = document.CreateElement("student");
                e.SetAttribute("indexNumber", s.Imie);

                //node.AppendChild(doc.DocumentElement);
                node.AppendChild(e);
            }
            */
            //document.Save(writer);







            //...
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(writer, uczelnia,ns);
            //stream.Dispose();//... IDisposable
        }
    }
}
