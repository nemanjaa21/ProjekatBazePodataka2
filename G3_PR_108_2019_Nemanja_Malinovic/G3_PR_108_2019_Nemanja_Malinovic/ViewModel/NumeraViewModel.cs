using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using G3_PR_108_2019_Nemanja_Malinovic.Models;

namespace G3_PR_108_2019_Nemanja_Malinovic.ViewModel
{
    public class NumeraViewModel : DependencyObject
    {
        public ObservableCollection<Numera> Pesme
        {
            get { return (ObservableCollection<Numera>)GetValue(PesmeProperty); }
            set { SetValue(PesmeProperty, value); }
        }

        public static readonly DependencyProperty PesmeProperty =
            DependencyProperty.Register("Pesme", typeof(ObservableCollection<Numera>), typeof(NumeraViewModel), new PropertyMetadata(null));

        public ObservableCollection<Zanr> Zanrovi
        {
            get { return (ObservableCollection<Zanr>)GetValue(ZanroviProperty); }
            set { SetValue(ZanroviProperty, value); }
        }

        public static readonly DependencyProperty ZanroviProperty =
            DependencyProperty.Register("Zanrovi", typeof(ObservableCollection<Zanr>), typeof(NumeraViewModel), new PropertyMetadata(null));

        public Zanr IzabraniZanr
        {
            get { return (Zanr)GetValue(IzabraniZanrProperty); }
            set { SetValue(IzabraniZanrProperty, value); }
        }

        public static readonly DependencyProperty IzabraniZanrProperty =
            DependencyProperty.Register("IzabraniZanr", typeof(Zanr), typeof(NumeraViewModel), new PropertyMetadata(null, OnIzabraniZanrChanged));

        public NumeraViewModel()
        {
            Pesme = new ObservableCollection<Numera>();
            Zanrovi = new ObservableCollection<Zanr>();

            // Call a method to populate the Zanrovi collection
            UcitajZanrove();
        }

        private static void OnIzabraniZanrChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = (NumeraViewModel)d;
            viewModel.UcitajPesmePoZanru();
        }

        private void UcitajZanrove()
        {
            using (var context = new Baze2Context())
            {
                // Load the Zanrovi collection from the database
                var zanrovi = context.Zanrs.ToList();
                Zanrovi = new ObservableCollection<Zanr>(zanrovi);
            }
        }

        private void UcitajPesmePoZanru()
        {
            using (var context = new Baze2Context())
            {
                if (IzabraniZanr != null)
                {
                    var pesme = context.ImaZanrs
                        .Where(iz => iz.IdZ == IzabraniZanr.IdZ)
                        .Select(iz => iz.IdNum)
                        .ToList();
                    var numere = context.Numeras.ToList();
                    var numere2 = new List<Numera>();
                    foreach (var i in numere)
                    {
                        if(pesme.Contains(i.IdNum))
                        {
                            numere2.Add(i);
                        }
                    }
                    Pesme = new ObservableCollection<Numera>(numere2);
                }
                else
                {
                    Pesme.Clear();
                }
            }
        }
    }
}
