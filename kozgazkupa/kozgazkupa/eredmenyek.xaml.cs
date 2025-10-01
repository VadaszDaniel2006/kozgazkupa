using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace kozgazkupa
{
    /// <summary>
    /// Interaction logic for eredmenyek.xaml
    /// </summary>
    public partial class eredmenyek : Window
    {
        List<Csapatok> csapatlista;

        public eredmenyek(List<Csapatok> csapatok)
        {
            InitializeComponent();
            csapatlista = csapatok;

            mText1.Text = $"1: {csapatlista[0].Csapatnev} - {csapatlista[1].Csapatnev}";
            mText2.Text = $"2: {csapatlista[0].Csapatnev} - {csapatlista[2].Csapatnev}";
            mText3.Text = $"3: {csapatlista[0].Csapatnev} - {csapatlista[3].Csapatnev}";
            mText4.Text = $"4: {csapatlista[1].Csapatnev} - {csapatlista[2].Csapatnev}";
            mText5.Text = $"5: {csapatlista[1].Csapatnev} - {csapatlista[3].Csapatnev}";
            mText6.Text = $"6: {csapatlista[2].Csapatnev} - {csapatlista[3].Csapatnev}";
        }

        private void Mentés_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, int> pontok = new Dictionary<string, int>();
            foreach (var c in csapatlista)
                pontok[c.Csapatnev] = 0;

            var meccsek = new List<(TextBox tb, string cs1, string cs2)>
            {
                (m1, csapatlista[0].Csapatnev, csapatlista[1].Csapatnev),
                (m2, csapatlista[0].Csapatnev, csapatlista[2].Csapatnev),
                (m3, csapatlista[0].Csapatnev, csapatlista[3].Csapatnev),
                (m4, csapatlista[1].Csapatnev, csapatlista[2].Csapatnev),
                (m5, csapatlista[1].Csapatnev, csapatlista[3].Csapatnev),
                (m6, csapatlista[2].Csapatnev, csapatlista[3].Csapatnev)
            };

            foreach (var (tb, cs1, cs2) in meccsek)
            {
                string eredmeny = tb.Text.Trim();
                if (!eredmeny.Contains("-"))
                {
                    MessageBox.Show($"Hibás formátum: {cs1} - {cs2}");
                    return;
                }

                var res = eredmeny.Split('-');
                if (!int.TryParse(res[0], out int g1) || !int.TryParse(res[1], out int g2))
                {
                    MessageBox.Show($"Hibás szám: {cs1} - {cs2}");
                    return;
                }

                if (g1 > g2)
                {
                    pontok[cs1] += 3;
                }
                else if (g1 < g2)
                {
                    pontok[cs2] += 3;
                }
                else
                {
                    pontok[cs1] += 1;
                    pontok[cs2] += 1;
                }
            }

            var tabla = pontok.OrderByDescending(x => x.Value).ToList();
            using (StreamWriter sw = new StreamWriter("eredmenyek.txt"))
            {
                sw.WriteLine("Csapat\tPont");
                foreach (var item in tabla)
                    sw.WriteLine($"{item.Key}\t{item.Value}");
            }

            MessageBox.Show("Eredmények mentve a eredmenyek.txt-be!");
            this.Close();
        }
    }
}