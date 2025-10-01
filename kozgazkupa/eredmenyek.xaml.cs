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
        private List<Csapatok> csapatlista;

        public eredmenyek(List<Csapatok> csapatok)
        {
            InitializeComponent();
            csapatlista = csapatok;

            
            mText1.Text = $"{csapatlista[0].Csapatnev} - {csapatlista[1].Csapatnev}";
            mText2.Text = $"{csapatlista[0].Csapatnev} - {csapatlista[2].Csapatnev}";
            mText3.Text = $"{csapatlista[0].Csapatnev} - {csapatlista[3].Csapatnev}";
            mText4.Text = $"{csapatlista[1].Csapatnev} - {csapatlista[2].Csapatnev}";
            mText5.Text = $"{csapatlista[1].Csapatnev} - {csapatlista[3].Csapatnev}";
            mText6.Text = $"{csapatlista[2].Csapatnev} - {csapatlista[3].Csapatnev}";
        }

        private void Mentés_Click(object sender, RoutedEventArgs e)
        {
            var pontok = csapatlista.ToDictionary(c => c.Csapatnev, c => 0);

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
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    MessageBox.Show($"Nincs eredmény megadva: {cs1} - {cs2}");
                    return;
                }

                var res = tb.Text.Trim().Split('-');
                if (res.Length != 2 || !int.TryParse(res[0], out int g1) || !int.TryParse(res[1], out int g2))
                {
                    MessageBox.Show($"Hibás formátum: {cs1} - {cs2}. Használd az X-Y formátumot!");
                    return;
                }

                
                if (g1 < 0 || g1 > 20 || g2 < 0 || g2 > 20)
                {
                    MessageBox.Show($"Hibás eredmény: {cs1} - {cs2}. A gólok 0 és 20 között lehetnek!");
                    return;
                }

                
                if (g1 > g2) pontok[cs1] += 3;
                else if (g1 < g2) pontok[cs2] += 3;
                else
                {
                    pontok[cs1] += 1;
                    pontok[cs2] += 1;
                }
            }

           
            var tabla = pontok.OrderByDescending(x => x.Value).ToList();
            using (var sw = new StreamWriter("eredmenyek.txt"))
            {
                sw.WriteLine("Csapat\tPont");
                foreach (var item in tabla)
                    sw.WriteLine($"{item.Key}\t{item.Value}");
            }

            MessageBox.Show("Eredmények mentve az eredmenyek.txt-be!");
            this.Close();
        }
    }
}