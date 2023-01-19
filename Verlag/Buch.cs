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


        public Buch(string autor, string title) 
        {
            if (autor == null)
            {
                throw new ArgumentNullException("Der Name des Autor darf nicht null sein");
                
            }else if (autor == "" || autor.Contains('#') || autor.Contains(';') || autor.Contains('§') || autor.Contains('%'))
            {
                throw new ArgumentException("Der Name des Autor darf nicht leer sein oder mit nicht sinnvolleZeichen enthalten");
            }
            this.autor = autor;
            this.title = title;
            this.auflage = 1;
        }
        public Buch(string autor, string title, int auflage) : this(autor, title)
        {
            this.autor = autor;
            this.title = title;
            if (auflage <= 0)
            {
                
                throw new ArgumentOutOfRangeException("Auflag darf nicht weniger als 1 sein");
            }
            this.auflage = auflage;
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
    }
}
