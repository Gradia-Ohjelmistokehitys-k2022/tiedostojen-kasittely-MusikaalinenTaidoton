using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace tiedostojen_kasittely
{
    internal class Tiedosto
    {
        static void Main()
        {
            string fullfilepath;
            string content;
            string x;
            void OnOlemassa()
            {
                Console.WriteLine("Anna tiedoston Sijainti\n");
                Console.Write("<");
                x = Console.ReadLine();
                fullfilepath = x + @"\teksti1.txt";
                if (File.Exists(fullfilepath) == false)
                {
                    Console.WriteLine("Tiedostoa ei ole, Luodaanko? (Y/N).");
                    Console.Write("<");
                    string YN = Console.ReadLine();
                    if (YN == "Y")
                    {
                        File.Create(fullfilepath).Close();
                    }
                    if (YN == "N")
                    {
                        Console.WriteLine("Poistutaan...");
                        Environment.Exit(1);
                    }
                }
                else
                {
                    Console.WriteLine("Tiedosto Loytyy");
                }
            }
            void BinOnOlemassa()
            {
                Console.WriteLine("Anna tiedoston Sijainti\n");
                Console.Write("<");
                x = Console.ReadLine();
                fullfilepath = x + @"\oma_binaari.bin";
                if (File.Exists(fullfilepath) == false)
                {
                    Console.WriteLine("Tiedostoa ei ole, Luodaanko? (Y/N).");
                    Console.Write("<");
                    string YN = Console.ReadLine();
                    if (YN == "Y")
                    {
                        File.Create(fullfilepath).Close();
                    }
                    if (YN == "N")
                    {
                        Console.WriteLine("Poistutaan...");
                        Environment.Exit(1);
                    }
                }
                else
                {
                    Console.WriteLine("Tiedosto Loytyy");
                }
            }
            void MuutaTaulukoksi()
            {
                content = File.ReadAllText(fullfilepath);
                content = content.Replace("\n", "       ");
                Console.WriteLine(content);
            }
            void MuutaListaksi()
            {
                content=File.ReadAllText(fullfilepath);
                content = content.Replace("\n", "\n-");
                Console.WriteLine(content);
            }
            void MuutaMerkkijonoksi()
            {
                content = File.ReadAllText(fullfilepath);
                Console.WriteLine(content);
            }
            void Kirjoita()
            {
                Console.WriteLine("kirjoita mita haluat (lisataan tekstiin)\n");
                Console.Write("<");
                string woop = Console.ReadLine();
                Console.WriteLine(@"lisataan '"+woop+@"' tekstiin");
                File.AppendAllText(fullfilepath,"\n" + woop);
            }
            Console.WriteLine("Mitä ohjelmaa haluaisit käyttää?");
            Console.WriteLine("1. Kirjoita tiedostoon\n2. Tulosta tiedoston sisältö eri tyyleillä\n3. Tulosta hakemiston sisältö\n4. Kirjoita liuku- ja kokonaisluvut binaariin\n\n\n0. Poistu\n\n");
            Console.Write("<");
            string menu = Console.ReadLine();
            if (menu == "1")
            {
                Console.Clear();
                OnOlemassa();
                MuutaMerkkijonoksi();
                Kirjoita();
                Console.WriteLine("Suljetaan tiedosto...");
                fullfilepath = "";
                Console.WriteLine("Avataan tiedosto luettavaksi");
                fullfilepath = x + @"\teksti1.txt";
                string turhafunktio = "";
                string teksti = File.ReadAllText(fullfilepath);
                teksti = teksti + turhafunktio.PadRight(1,' ');
                teksti = String.Join<char>(",", teksti);
                Console.WriteLine(teksti);
            }
            if (menu == "2")
            {
                Console.Clear();
                OnOlemassa();
                Console.WriteLine("Millä tyylillä haluat nähdä tiedoston?\n\n1. Taulukko\n2. Lista\n3. Merkkijono");
                Console.Write("<");
                string style = Console.ReadLine();
                if (style == "1")
                {
                    MuutaTaulukoksi();
                }
                if (style == "2")
                {
                    MuutaListaksi();
                }
                if (style == "3")
                {
                    MuutaMerkkijonoksi();
                }
            }
            if (menu == "3")
            {
                string location = "";
                Console.Clear();
                void ProcessFile(string path)
                {
                    DateTime datetime = File.GetLastWriteTime(path);
                    Console.WriteLine(path.Replace(location, "") + "      " + datetime+"      "+new FileInfo(path).Length+" bytes");
                }
                Console.WriteLine(@"Anna hakemiston sijainti (Esim. C:\Kansio)");
                Console.WriteLine("");
                Console.Write("<");
                location = Console.ReadLine();
                bool slashtruefalse = location.EndsWith(@"\");
                if (slashtruefalse == true)
                {
                    goto ohjelma;
                }
                else
                {
                    location = location + @"\";
                }
            ohjelma:;
                string[] getdir = Directory.GetFiles(@location);
                Console.WriteLine("Tassa kansion " + location + " tiedostot!");
                foreach (string fileName in getdir)
                {
                    ProcessFile(fileName);
                }
                Console.WriteLine("\nPaina mitä tahansa näppäintä poistuaksesi");
                Console.ReadKey();
            
            }
            if (menu == "4")
            {
                fullfilepath = "";
                Console.Clear();
                BinOnOlemassa();
                double liukuluku = 3.14159265;
                int kokonaisluku = -1;
                double sum = liukuluku + kokonaisluku;
                File.WriteAllText(fullfilepath, sum.ToString());
            }
            if (menu == "0")
            {
                Environment.Exit(0);
            }
        }
    }
}