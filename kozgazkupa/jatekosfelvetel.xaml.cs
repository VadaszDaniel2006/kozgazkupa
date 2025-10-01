using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace kozgazkupa
{
    /// <summary>
    /// Interaction logic for jatekosfelvetel.xaml
    /// </summary>
    public partial class jatekosfelvetel : Window
    {
        Csapatok aktivCsapat;

        public jatekosfelvetel(Csapatok csapat)
        {
            InitializeComponent();
            aktivCsapat = csapat;
            csapatnev.Text = csapat.Csapatnev;
            csapatnev.IsEnabled = false;
        }

        List<int> foglaltMezszamok = new List<int>();
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nev.Text) || string.IsNullOrWhiteSpace(csapatnev.Text) || string.IsNullOrWhiteSpace((eletkor.Text)) || string.IsNullOrWhiteSpace(mezszam.Text))
            {
                MessageBox.Show("Töltsd ki a mezőket!");
                return;
            }

            int szamEL;
            int szamME;


            if (!int.TryParse(eletkor.Text, out szamEL) || szamEL < 10 || szamEL > 100)
            {
                MessageBox.Show("Nem vehetsz részt a tornán!");
                eletkor.Clear();
                return;
            }

            

            if (!int.TryParse(mezszam.Text, out szamME) || szamME < 0 || szamME > 100)
            {
                MessageBox.Show("Nem megfelelő mezszámot választottál!");
                mezszam.Clear();
                return;
            }

            if (foglaltMezszamok.Contains(szamME))
            {
                MessageBox.Show("Ez a mezszám már foglalt egy másik játékos által!");
                mezszam.Clear();
                return;
            }

            
            foglaltMezszamok.Add(szamME);


            if (aktivCsapat.Jatekosok.Count >= aktivCsapat.Fo)
            {
                MessageBox.Show("Ez a csapat betelt!");
                new csapatok().Show();
                this.Close();
                return;
            }

            jatekos uj = new jatekos(
                nev.Text,
                aktivCsapat.Csapatnev,
                int.Parse(eletkor.Text),
                int.Parse(mezszam.Text)
            );

            aktivCsapat.Jatekosok.Add(uj);
            MessageBox.Show("Játékos hozzáadva!");
            nev.Clear();
            eletkor.Clear();
            mezszam.Clear();

            if (aktivCsapat.Jatekosok.Count == aktivCsapat.Fo)
            {
                MessageBox.Show("Ez a csapat kész!");
                new csapatok().Show();
                this.Close();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            nev.Clear();
            eletkor.Clear();
            mezszam.Clear();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
