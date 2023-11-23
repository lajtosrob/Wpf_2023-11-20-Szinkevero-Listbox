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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_2023_11_20_Szinkevero_Listbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Szin> szinek = new List<Szin>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            Szin ujszin = new Szin(
                Convert.ToInt16(sliRed.Value),
                Convert.ToInt16(sliGreen.Value),
                Convert.ToInt16(sliBlue.Value)
                );

            szinek.Add(ujszin);
            lbSzinLista.Items.Add($"{ujszin.Red};{ujszin.Green};{ujszin.Blue}");
            sliRed.Value = 0;
            sliGreen.Value = 0;
            sliBlue.Value = 0;
        }

        private void sliRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rctRectangle.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sliRed.Value), Convert.ToByte(sliGreen.Value), Convert.ToByte(sliBlue.Value)));
        }

        private void sliGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rctRectangle.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sliRed.Value), Convert.ToByte(sliGreen.Value), Convert.ToByte(sliBlue.Value)));
        }

        private void sliBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rctRectangle.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(sliRed.Value), Convert.ToByte(sliGreen.Value), Convert.ToByte(sliBlue.Value)));
        }

        private void btnMentes_Click(object sender, RoutedEventArgs e)
        {
            if (szinek.Count == 0)
            {
                MessageBox.Show("Üres a lista nincs mit menteni!");
            }
            else
            {
                StreamWriter sw = new StreamWriter(".\\szinek.csv");

                foreach (var szin in szinek)
                {
                    sw.WriteLine($"{szin.Red};{szin.Green};{szin.Blue}");
                }

                sw.Close();

                MessageBox.Show("A fájlba mentés sikeresen megtörtént!");
            }


        }

        //private void ShowYesNoMessageBox()
        private void btnBetolt_Click(object sender, RoutedEventArgs e)

        {
            MessageBoxResult result = MessageBox.Show("Ürítse előbb a listát?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                lbSzinLista.Items.Clear();
            }

            StreamReader sr = new StreamReader("szinek.csv");

            while(!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(";");

                Szin adatsor = new Szin(
                    Convert.ToInt16(line[0]),
                    Convert.ToInt16(line[1]),
                    Convert.ToInt16(line[2])
                    );

                lbSzinLista.Items.Add($"{adatsor.Red};{adatsor.Green};{adatsor.Blue}");
            }

        }

        private void lbSzinLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbSzinLista.SelectedItem != null)
            {
                //var selectedItem = Convert.ToString((ListBoxItem)lbSzinLista.SelectedValue).Split(";");
                string selectedItem = lbSzinLista.SelectedValue.ToString();

                sliRed.Value = Convert.ToInt16(selectedItem.Split(";")[0]);
                sliRed.Value = Convert.ToDouble(selectedItem.Split(";")[1]);
                sliRed.Value = Convert.ToDouble(selectedItem.Split(';')[2]);

            }
        }
    }
}
