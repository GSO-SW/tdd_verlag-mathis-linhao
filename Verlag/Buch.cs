using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verlag
{
    public class Buch
    {
        private string autor;
        private string title;
        private int auflage;
        private string isbn13;

        string[] sonderzeichen = new string[] { "#", ";", ":", "/", "(", ")", "?", "!", "§", "&", "=", ":", "`", "´", "<", ">", "|", "µ", "{", "[", "]", "}", "^", "°", "+","*","$" };
        public Buch(string autor, string title) 
        {
            if (autor == null)
            {
                throw new ArgumentNullException("Der Name des Autor darf nicht null sein");
                
            }else if (autor == "" )
            {
                throw new ArgumentException("Der Name des Autor darf nicht leer sein ");
            }
            foreach(string s in sonderzeichen)
            {
                if (autor.Contains(s))
                {
                    throw new ArgumentException("Der Name des Autor darf nicht mit nicht sinnvolleZeichen enthalten");
                }
            }
            this.autor = autor;
            this.title = title;
            this.auflage = 1;
        }
        public Buch(string autor, string title, int auflage) : this(autor, title)
        {
            if (auflage <= 0)
            {
                
                throw new ArgumentOutOfRangeException("Auflag darf nicht weniger als 1 sein");
            }
            this.auflage = auflage;
        }
        public Buch(string autor, string title, int auflage, string isbn13) : this(autor, title, auflage)
        {
            this.isbn13 = isbn13;
        }

        public string Autor
        {
            set { this.autor = value; }
            get { return this.autor; }
        }

        public string Titel
        {
            set { this.title = value; }
            get { return this.title; }
        }

        public int Auflage
        {
            set
            {
                if(value <= 0)
                {
                    this.auflage = 1;
                    throw new ArgumentOutOfRangeException("Auflag darf nicht weniger als 1 sein");
                }
                else 
                { 
                    this.auflage = value;
                }

            }
            get { return this.auflage; }
        }


        public string ISBN13
        {
            get { return isbn13; }

            set
            {
                if(value.Length == 14)
                {
                    isbn13 = value;
                }else if(value.Length == 13)
                {
                    int[] zahlen = PruefzifferArray(value);

                    bool gerade = false;
                    for(int i = 0; i < zahlen.Length; i++)
                    {
                        if (gerade)
                        {
                            zahlen[i] *= 3;
                        }

                        gerade = !gerade;
                    }

                    int summe = zahlen.Sum();
                    int pruefziffer = 10 - Math.Abs(summe % 10);
                    isbn13 = value + pruefziffer;
                }
            }
        }

        public string ISBN10
        {
            get
            {
                int[] zahlen = PruefzifferArray(isbn13);
                int zaehler = 1;
                for (int i = 0; i < zahlen.Length; i++)
                {
                    zahlen[i] *= zaehler;

                    zaehler++;
                }
                int summe = zahlen.Sum();
                
                int pruefziffer10 = summe % 11;
                
                if (pruefziffer10 == 10)
                {
                    return isbn13[4..^1] + 'X';
                }
                return isbn13[4..^1] + pruefziffer10;
            }
        }
        private int[] PruefzifferArray(string isbn13)
        {
            List<int> pruefziffer = new List<int>();

            foreach (var item in isbn13)
            {
                
                if(item != '-')
                {
                    pruefziffer.Add(item);
                }
            }

            return pruefziffer.ToArray();
        }

    }
}
