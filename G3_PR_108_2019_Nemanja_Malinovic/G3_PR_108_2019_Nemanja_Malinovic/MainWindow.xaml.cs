using G3_PR_108_2019_Nemanja_Malinovic.Models;
using G3_PR_108_2019_Nemanja_Malinovic.ViewModel;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace G3_PR_108_2019_Nemanja_Malinovic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Baze2Context context = new Baze2Context();
        private NumeraViewModel numeraViewModel;
        private CollectionViewSource korisnikViewSource = new CollectionViewSource();

        private CollectionViewSource playListViewSource = new CollectionViewSource();

        private CollectionViewSource muzickiAlbumViewSource = new CollectionViewSource();

        private CollectionViewSource izvodjacViewSource = new CollectionViewSource();
        private CollectionViewSource soloIzvodjacViewSource = new CollectionViewSource();
        private CollectionViewSource grupaViewSource = new CollectionViewSource();
        private CollectionViewSource clanViewSource = new CollectionViewSource();
        private CollectionViewSource izdavackaKucaViewSource = new CollectionViewSource();
        private CollectionViewSource numeraViewSource = new CollectionViewSource();
        private CollectionViewSource zanrViewSource = new CollectionViewSource();
        private CollectionViewSource sadrziPlayNumViewSource = new CollectionViewSource();
        private CollectionViewSource imaZanrViewSource = new CollectionViewSource();



        public MainWindow()
        {
            InitializeComponent();
            korisnikViewSource = (CollectionViewSource)FindResource(nameof(korisnikViewSource));
            playListViewSource = (CollectionViewSource)FindResource(nameof(playListViewSource));
            muzickiAlbumViewSource = (CollectionViewSource)FindResource(nameof(muzickiAlbumViewSource));
            izvodjacViewSource = (CollectionViewSource)FindResource(nameof(izvodjacViewSource));
            soloIzvodjacViewSource = (CollectionViewSource)FindResource(nameof(soloIzvodjacViewSource));
            grupaViewSource = (CollectionViewSource)FindResource(nameof(grupaViewSource));
            clanViewSource = (CollectionViewSource)FindResource(nameof(clanViewSource));
            izdavackaKucaViewSource = (CollectionViewSource)FindResource(nameof(izdavackaKucaViewSource));
            numeraViewSource = (CollectionViewSource)FindResource(nameof(numeraViewSource));
            zanrViewSource = (CollectionViewSource)FindResource(nameof(zanrViewSource));
            sadrziPlayNumViewSource = (CollectionViewSource)FindResource(nameof(sadrziPlayNumViewSource));
            imaZanrViewSource = (CollectionViewSource)FindResource(nameof(imaZanrViewSource));
            numeraViewModel = (NumeraViewModel)Resources["NumeraViewModelResource"];

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.Korisniks.Load();
            context.PlayLista.Load();
            context.MuzickiAlbums.Load();
            context.Izvodjacs.Load();
            context.SoloIzvodjacs.Load();
            context.Grupas.Load();
            context.Clans.Load();
            context.IzdavackaKucas.Load();
            context.Numeras.Load();
            context.Zanrs.Load();
            context.SadrziPlayNums.Load();
            context.ImaZanrs.Load();

            korisnikViewSource.Source = context.Korisniks.Local.ToObservableCollection();
            playListViewSource.Source = context.PlayLista.Local.ToObservableCollection();
            muzickiAlbumViewSource.Source = context.MuzickiAlbums.Local.ToObservableCollection();
            izvodjacViewSource.Source = context.Izvodjacs.Local.ToObservableCollection();
            soloIzvodjacViewSource.Source = context.SoloIzvodjacs.Local.ToObservableCollection();
            grupaViewSource.Source = context.Grupas.Local.ToObservableCollection();
            clanViewSource.Source = context.Clans.Local.ToObservableCollection();
            izdavackaKucaViewSource.Source = context.IzdavackaKucas.Local.ToObservableCollection();
            numeraViewSource.Source = context.Numeras.Local.ToObservableCollection();
            zanrViewSource.Source = context.Zanrs.Local.ToObservableCollection();
            sadrziPlayNumViewSource.Source = context.SadrziPlayNums.Local.ToObservableCollection();
            imaZanrViewSource.Source = context.ImaZanrs.Local.ToObservableCollection();


        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            context.Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n = context.SaveChanges();

            KorisniciDataGrid.Items.Refresh();
            PlayListaDataGrid.Items.Refresh();
            NumereDataGrid.Items.Refresh();
            NumereNaPlayDataGrid.Items.Refresh();
            ZanroviDataGrid.Items.Refresh();
            ZanrNumeraDataGrid.Items.Refresh();
            IzvodjacDataGrid.Items.Refresh();
            SoloIzvodjacDataGrid.Items.Refresh();
            GrupaIzvodjacDataGrid.Items.Refresh();
            MuzickiAlbumDataGrid.Items.Refresh();
            IzdavackaKucaDataGrid.Items.Refresh();
            ClanDataGrid.Items.Refresh();


            MessageBox.Show("Broj izvršenih zapisa: " + n, "Snimanje");
        }
    }
}
