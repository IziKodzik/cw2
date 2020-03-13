using cw2.data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using cw2.data;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            string file;
            if (args.Length==0 ||  args[0].Equals( ""))
            {
                file = "data/dane.csv";
            }
            else
            {
                file = args[0];
            }
            string gool;
            if (args.Length < 2 || args[1].Equals(""))
            {
                gool = "żesult.xml";
            }
            else
            {
                gool = args[1];
            }
            if (args.Length == 3 && !args[2].Equals( "xml"))
            {
                Console.WriteLine("nieprwaidłowy format pliku");
                return;
            }


            string file2 = "data/łog.txt";
            
            StreamWriter streamWriter = null;
            streamWriter = new StreamWriter(file2);

            FileInfo f = new FileInfo(file);
            List<Student> los = new List<Student>();
            Dictionary<string, int> stud = new Dictionary<string, int>();
            try
            {
                using (StreamReader stream = new StreamReader(f.OpenRead()))
                {


                    string line = "";
                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] studentWiersz = line.Split(",");
                        //Console.WriteLine(line);
                        if (studentWiersz.Length == 9)
                        {
                            bool t = true;

                            foreach (string str in studentWiersz)
                            {
                                if (str.Equals(""))
                                    t = false;
                            }

                            if (t)
                            {
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

                                if (stud.ContainsKey(s.nazwa))
                                {
                                    stud[s.nazwa]++;
                                }
                                else
                                {
                                    stud.Add(s.nazwa, 1);
                                }
                            }
                            else
                            {
                                streamWriter.WriteLine("nieprawidłowa struktura danych:" + line);
                            }
                        }
                        else
                        {
                            streamWriter.WriteLine("nieprawidłowa struktura danych:" + line);
                        }
                    }
                }
            }catch(FileNotFoundException e)
            {
                Console.WriteLine("FileNotFoundException(\"Plik nazwa nie istnieje\")");
                streamWriter.WriteLine("FileNotFoundException(\"Plik nazwa nie istnieje\")");
                return;
            }catch(ArgumentException e1)
            {
                Console.WriteLine("ArgumentException(\"Podana ścieżka jest niepoprawna\")");
                streamWriter.WriteLine("ArgumentException(\"Podana ścieżka jest niepoprawna\")");
                return;
            }catch(Exception e2)
            {
                Console.WriteLine(e2.Message);
                streamWriter.WriteLine(e2.Message);
                return;
            }
            streamWriter.Flush();
            streamWriter.Close();
            ActiveStudies active = new ActiveStudies()
            {
                ACl = new List<AC>()
            };

            foreach (KeyValuePair<string, int> entry in stud)
            {
                AC a = new AC
                {
                    name = entry.Key,
                    number = entry.Value
                };
                active.ACl.Add(a);
            }
            Students st = new Students
            {
                student = los.Distinct(new EqualityComp()).ToList<Student>()
            };

            Uczelnia uczelnia = new Uczelnia
            {
                data = DateTime.Now,
                autor = "Michał Zieliński",
                student = st,
                activeStudies = active
            };


            FileStream writer = new FileStream(@gool, FileMode.Create);
            XmlRootAttribute rotatr = new XmlRootAttribute("studenci");
            XmlSerializer serializer = new XmlSerializer(typeof(Uczelnia));






            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(writer, uczelnia,ns);
     
        }
    }
}
