using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PaczkaEgz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string PocztowkaZdj = "https://www.drukomat.pl/media/cache/resolve/webp/uploads/products/thumbnails/5e3bf2f8c4de7465231218.png";
        private string ListZdj = "https://static.thenounproject.com/png/1064628-200.png";
        private string PaczkaZdj = "https://cdn.pixabay.com/photo/2014/12/21/23/35/parcel-575623_960_720.png";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Sprawdz(object sender, RoutedEventArgs e)
        {
            if (PocztowkaRadio.IsChecked == true)
            {
                xd(PocztowkaZdj, "Cena: 1 zł");
            }
            else if (ListRadio.IsChecked == true)
            {
                xd(ListZdj, "Cena: 1,5 zł");
            }
            else if (PaczkaRadio.IsChecked == true)
            {
                xd(PaczkaZdj, "Cena: 10 zł");
            }
            else
            {
                MessageBox.Show("Wybierz Rodzaj Przesyłki");
            }
        }

        private void xd(string obrazUrl, string cena)
        {
            Zdj.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(obrazUrl));
            dupa.Content = cena;
        }

        private void Zatwierdz(object sender, RoutedEventArgs e)
        {
            string kod = KodPocztowy.Text;

            if (string.IsNullOrEmpty(kod))
            {
                MessageBox.Show("Proszę wprowadzić kod pocztowy.");
            }
            else if (kod.Length != 5)
            {
                MessageBox.Show("Nieprawidłowa liczba cyfr w kodzie pocztowym.");
            }
            else if (!IloscCyfr(kod))
            {
                MessageBox.Show("Kod pocztowy powinien się składać z samych cyfr");
            }
            else
            {
                MessageBox.Show("Dane przesyłki zostały wprowadzone.");
            }
        }

        private bool IloscCyfr(string text)
        {
            foreach (char znak in text)
            {
                if (!Char.IsDigit(znak))
                {
                    return false;
                }
            }
            return true;
        }
    }
} 