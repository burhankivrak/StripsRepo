using StripDL;
using StripsBL.Exceptions;
using StripsBL.Services;
using System.Windows;

namespace StripsClientWPFStripView
{
    public partial class MainWindow : Window
    {
        private readonly StripService _stripService;

        public MainWindow()
        {
            InitializeComponent();
            _stripService = new StripService(new StripsContext());
        }

        private void btnGetStrip_Click(object sender, RoutedEventArgs e)
        {
            int stripId;

            if (!int.TryParse(txtStripId.Text, out stripId))
            {
                MessageBox.Show("Voer een geldig Strip ID in.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                var strip = _stripService.GetStrip(stripId);

                // Vul de UI-velden met de stripgegevens
                txtTitel.Text = strip.Titel;
                txtNr.Text = strip.Nr.ToString();
                txtReeks.Text = strip.Reeks?.Naam ?? "N/A";
                txtUitgeverij.Text = strip.Uitgeverij?.Naam ?? "N/A";

                if (strip.Auteurs != null && strip.Auteurs.Count > 0)
                {
                    txtAuteurs.Text = string.Join(", ", strip.Auteurs.ToList().ConvertAll(a => a.Naam));
                }
                else
                {
                    txtAuteurs.Text = "Geen auteurs beschikbaar";
                }
            }
            catch (DomeinException ex)
            {
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }
    }
}
