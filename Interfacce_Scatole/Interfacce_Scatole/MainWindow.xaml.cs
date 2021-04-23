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

namespace Interfacce_Scatole
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contenitore> contenitori = new List<Contenitore>();
        private string[] figure = new string[2] { "Quadrato", "Cerchio" };
        private string[] soglie = new string[2] { "Area Massima", "Perimerto Minimo" };
        
        public MainWindow()
        {

            InitializeComponent();
            for (int i = 0; i < figure.Length; i++)
            {
                cmbFigure.Items.Add(figure[i]);
            }
            for (int j = 0; j < soglie.Length; j++)
            {
                cmbPolitiche.Items.Add(soglie[j]);
            }
        }

        private void btnIDContenitore_Click(object sender, RoutedEventArgs e)
        {
            if (txtIDContenitore.Text != "")
            {
                Contenitore c = new Contenitore();
                string ID = txtIDContenitore.Text;
                contenitori.Add(c);
                cmbContenitori.Items.Add($"ID: {ID}");
                txtIDContenitore.Clear();
            }
            else
            {
                MessageBox.Show("Attenzione inserire un ID", "ATTENZIONE", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
                
            
        }

        private void btnAggiungiFigura_Click(object sender, RoutedEventArgs e)
        {
            
            if(txtParametro.Text != "" && cmbContenitori.SelectedIndex != -1)
            {
                double parametro = int.Parse(txtParametro.Text);
                switch (cmbFigure.SelectedIndex)
                {
                    case 0:
                        Quadrato q = new Quadrato(parametro);
                        contenitori[cmbContenitori.SelectedIndex].AggiungiFigura(q);
                        lb1.Items.Add($"La figura: {q.GetDescrizione()}\n" +
                            $"è stata inserita nell contenitore: {cmbContenitori.SelectedItem}");
                        txtParametro.Clear();
                        break;
                    case 1:
                        Cerchio c = new Cerchio(parametro);
                        contenitori[cmbContenitori.SelectedIndex].AggiungiFigura(c);
                        lb1.Items.Add($"La figura: {c.GetDescrizione()}\n" +
                            $"è stata inserita nell contenitore: {cmbContenitori.SelectedItem}");
                        txtParametro.Clear();
                        break;
                    default:
                        MessageBox.Show("Attenzione selezionare una figura", "ATTENZIONE", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Attenzione inserire un valore o selezionare un contenitore", "ATTENZIONE", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void btnSoglia_Click(object sender, RoutedEventArgs e)
        {
            Selettore s = new Selettore();
            
            if(txtSoglia.Text != "" && cmbContenitori.SelectedIndex != -1)
            {
                double soglia = double.Parse(txtSoglia.Text);
                switch (cmbPolitiche.SelectedIndex)
                {
                    case 0:
                        AreaMassima a = new AreaMassima(soglia);
                        s.ImpostaPolitica(a);
                        s.ScansionaContenitore(contenitori[cmbContenitori.SelectedIndex]);
                        break;
                    case 1:
                        PerimetroMinimo p = new PerimetroMinimo(soglia);
                        s.ImpostaPolitica(p);
                        s.ScansionaContenitore(contenitori[cmbContenitori.SelectedIndex]);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Attenzione inserite una soglia o selezionate un contenitore", "ATTENZIONE", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void cmbFigure_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cmbFigure.SelectedIndex)
            {
                case 0:
                    lbParametro.Content = "Lato";
                    break;
                case 1:
                    lbParametro.Content = "Raggio";
                    break;
            }
        }

        private void btnStampa_Click(object sender, RoutedEventArgs e)
        {
            if(cmbContenitori.SelectedIndex != -1)
            {
                lb1.Items.Clear();
                for (int i = 0; i < contenitori[cmbContenitori.SelectedIndex].FigureGeometrica.Count; i++)
                {
                    lb1.Items.Add(contenitori[cmbContenitori.SelectedIndex].FigureGeometrica[i].GetDescrizione());
                }
            }
            else
            {
                MessageBox.Show("Attenzione selezionare un contenitore da stampare", "ATTENZIONE", MessageBoxButton.OK, MessageBoxImage.Warning);
            } 
        }

        private void btnPulisci_Click(object sender, RoutedEventArgs e)
        {
            lb1.Items.Clear();
        }

        private void btnEsci_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
