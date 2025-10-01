using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kozgazkupa
{
    public class jatekos
    {
        string nev;
        string csapatnev;
        int eletkor;
        int mezszam;

        public jatekos(string nev, string csapatnev, int eletkor, int mezszam)
        {
            this.Nev = nev;
            this.Csapatnev = csapatnev;
            this.Eletkor = eletkor;
            this.Mezszam = mezszam;
        }

        public string Nev { get => nev; set => nev = value; }
        public string Csapatnev { get => csapatnev; set => csapatnev = value; }
        
        public int Eletkor { get => eletkor; set => eletkor = value; }
        public int Mezszam { get => mezszam; set => mezszam = value; }
    }
}
