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
    /// Interaction logic for csapatok.xaml
    /// </summary>
    public partial class csapatok : Window
    {
        public static List<Csapatok> csapatlista = new List<Csapatok>();

        public csapatok()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(csapatnev.Text) || string.IsNullOrWhiteSpace(id.Text) || string.IsNullOrWhiteSpace((fo.Text)) || string.IsNullOrWhiteSpace(szekhely.Text) || string.IsNullOrWhiteSpace(tulaj.Text))
            {
                MessageBox.Show("Töltsd ki a mezőket");
                return;
            }
            int szamID;
            


            if (!int.TryParse(id.Text, out szamID) || szamID< 1 )
            {
                MessageBox.Show("Kérlek, számot adj meg!");
                id.Clear();
                return;
            }

           


            if (csapatlista.Count >= 4)
            {
                MessageBox.Show("Már 4 csapat van, nem lehet több!");
                return;
            }

            if (!int.TryParse(fo.Text, out int letszam) || letszam < 1 || letszam > 12)
            {
                MessageBox.Show("A fő mezőbe számot írj!");
                fo.Clear();
                return;
            }

            Csapatok uj = new Csapatok(
                csapatnev.Text,
                csapatlista.Count + 1,
                letszam,
                szekhely.Text,
                tulaj.Text
            );

            csapatlista.Add(uj);
            MessageBox.Show("Csapat hozzáadva!");

            jatekosfelvetel jablak = new jatekosfelvetel(uj);
            jablak.Show();
            this.Close();
        }

        private void megse_Click(object sender, RoutedEventArgs e)
        {
            csapatnev.Clear();
            id.Clear();
            fo.Clear();
            szekhely.Clear();
            tulaj.Clear();
        }

        private void kilepes_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnEredmenyek_Click(object sender, RoutedEventArgs e)
        {
            if (csapatlista.Count == 4 && csapatlista.All(c => c.Jatekosok.Count == c.Fo))
            {
                eredmenyek ablak = new eredmenyek(csapatlista);
                ablak.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Minden csapathoz fel kell venni a játékosokat!");
            }
        }
    }

}
