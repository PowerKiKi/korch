using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace korch
{
    class Translator
    {
        System.Collections.Hashtable trans = new System.Collections.Hashtable();

        public string Full
        {
            get
            {
                string res = "";
                foreach (string cle in this.trans.Keys)
                {
                    res += cle + " -> ";
                    foreach (string val in (List<string>)this.trans[cle])
                        res += val + ", ";
                    res += "\r\n";
                }
                return res;
            }
        }

        public string toKor(string s)
        {
            foreach (string cle in this.trans.Keys)
            {
                foreach (string val in (List<string>)this.trans[cle])
                    if (val == s)
                        return cle;
            }
            return "[inconnu:" + s + "]";
        }

        public string fromKor(string s)
        {
            if (this.trans.ContainsKey(s))
                return (string)this.trans[s];
            else
                return "[inconnu:"+s+"]";
        }

        public string mixedTranslation(string s)
        {
            if (this.trans.ContainsKey(s))
                return ((System.Collections.Generic.List<string>)this.trans[s])[0];

            foreach (string cle in this.trans.Keys)
            {
                foreach (string val in (List<string>)this.trans[cle])
                    if (val == s)
                        return cle;
            }
            return "[inconnu:" + s + "]";
        }


        public Translator()
        {
            this.loadFile("HangulSyllableType.txt");
            System.Collections.Generic.List<string> liste;
                        
            liste = new List<string>();
            trans.Add("ㄱ", liste);
            liste.Add("k");
            liste.Add("g");
            liste = new List<string>();
            trans.Add("ㄴ", liste);
            liste.Add("n");
            liste = new List<string>();
            trans.Add("ㄷ", liste);
            liste.Add("d");
            liste = new List<string>();
            trans.Add("ㄹ", liste);
            liste.Add("l");
            liste.Add("r");
            liste = new List<string>();
            trans.Add("ㅁ", liste);
            liste.Add("m");
            liste = new List<string>();
            trans.Add("ㅂ", liste);
            liste.Add("b");
            liste.Add("v");
            liste = new List<string>();
            trans.Add("ㅅ", liste);
            liste.Add("s");
            liste = new List<string>();
            trans.Add("ㅇ", liste);
            liste.Add("j");
            liste.Add("x");
            liste = new List<string>();
            trans.Add("ㅈ", liste);
            liste.Add("j");
            liste.Add("z");
            liste = new List<string>();
            trans.Add("ㅊ", liste);
            liste.Add("ch");
            liste = new List<string>();
            trans.Add("ㅋ", liste);
            liste.Add("k");
            liste.Add("c");
            liste = new List<string>();
            trans.Add("ㅌ", liste);
            liste.Add("t");
            liste = new List<string>();
            trans.Add("ㅍ", liste);
            liste.Add("p");
            liste.Add("f");
            liste = new List<string>();
            trans.Add("ㅎ", liste);
            liste.Add("h");
            liste.Add("f");
            liste = new List<string>();
            trans.Add("ㅐ", liste);
            liste.Add("ae");
            liste = new List<string>();
            trans.Add("ㅔ", liste);
            liste.Add("e");
            liste = new List<string>();
            trans.Add("ㅏ", liste);
            liste.Add("a");
            liste = new List<string>();
            trans.Add("ㅑ", liste);
            liste.Add("ya");
            liste = new List<string>();
            trans.Add("ㅓ", liste);
            liste.Add("eo");
            liste = new List<string>();
            trans.Add("ㅕ", liste);
            liste.Add("yeo");
            liste = new List<string>();
            trans.Add("ㅗ", liste);
            liste.Add("o");
            liste = new List<string>();
            trans.Add("ㅛ", liste);
            liste.Add("yo");
            liste = new List<string>();
            trans.Add("ㅜ", liste);
            liste.Add("woo");
            liste = new List<string>();
            trans.Add("ㅠ", liste);
            liste.Add("you");
            liste = new List<string>();
            trans.Add("ㅡ", liste);
            liste.Add("eu");
            liste = new List<string>();
            trans.Add("ㅣ", liste);
            liste.Add("i");
/*            liste = new List<string>();
            trans.Add("ㅓ", liste);
            liste.Add("eui");
            liste = new List<string>();
            trans.Add("", liste);
            liste.Add("");
            liste = new List<string>();
            trans.Add("", liste);
            liste.Add("");*/
          }
        private void loadFile(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            string[] fichier = reader.ReadToEnd().Split('\n');
            reader.Close();

            System.Text.UnicodeEncoding encoder = new UnicodeEncoding();
            bool syllableSimple = false;
            foreach (string ligne in fichier)
            {
                if (ligne.StartsWith("AC00"))
                    syllableSimple = true;

                if (syllableSimple)
                {
                    int i1 = Convert.ToInt32(ligne.Substring(0, 2), 16);
                    int i2 = Convert.ToInt32(ligne.Substring(2, 2), 16);
                    byte b1 = Convert.ToByte(i1);
                    byte b2 = Convert.ToByte(i2);
                    byte[] bb = { b2, b1 };
                    ;



                    System.Collections.Generic.List<string> liste;

                    liste = new List<string>();
                    trans.Add(encoder.GetString(bb), liste);
                    liste.Add(ligne.Substring(ligne.LastIndexOf(' ') + 1));
                    //liste.Add("g");
                }

                if (ligne.StartsWith("D788"))
                    syllableSimple = false;
            }
            
            
            
            
        }
    }
}
