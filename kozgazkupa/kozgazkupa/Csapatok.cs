using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kozgazkupa
{
    public class Csapatok
    {
        string csapatnev;
        int id;
        int fo;
        string szekhely;
        string tulaj;

        public List<jatekos> Jatekosok { get; set; } = new List<jatekos>();
        public Csapatok(string csapatnev, int id, int fo, string szekhely, string tulaj)
        {
            this.Csapatnev = csapatnev;
            this.Id = id;
            this.Fo = fo;
            this.Szekhely = szekhely;
            this.Tulaj = tulaj;
        }

        public string Csapatnev { get => csapatnev; set => csapatnev = value; }
        public int Id { get => id; set => id = value; }
        public int Fo { get => fo; set => fo = value; }
        public string Szekhely { get => szekhely; set => szekhely = value; }
        public string Tulaj { get => tulaj; set => tulaj = value; }
    }
}
