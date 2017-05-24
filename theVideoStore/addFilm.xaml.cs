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
using System.Xml.Serialization;

namespace theVideoStore
{
    /// <summary>
    /// Логика взаимодействия для addFilm.xaml
    /// </summary>
    public partial class addFilm : Page
    {
        private void textBoxName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                textBoxName.Visibility = System.Windows.Visibility.Collapsed;
                textBoxNameHint.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void textBoxNameHint_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxNameHint.Visibility = System.Windows.Visibility.Collapsed;
            textBoxName.Visibility = System.Windows.Visibility.Visible;
            textBoxName.Focus();
        }

        private void textBoxYear_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxYear.Text))
            {
                textBoxYear.Visibility = System.Windows.Visibility.Collapsed;
                textBoxYearHint.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void textBoxYearHint_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxYearHint.Visibility = System.Windows.Visibility.Collapsed;
            textBoxYear.Visibility = System.Windows.Visibility.Visible;
            textBoxYear.Focus();
        }

        private void textBoxGenre_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxGenre.Text))
            {
                textBoxGenre.Visibility = System.Windows.Visibility.Collapsed;
                textBoxGenreHint.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void textBoxGenreHint_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxGenreHint.Visibility = System.Windows.Visibility.Collapsed;
            textBoxGenre.Visibility = System.Windows.Visibility.Visible;
            textBoxGenre.Focus();
        }

        private void textBoxDirector_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDirector.Text))
            {
                textBoxDirector.Visibility = System.Windows.Visibility.Collapsed;
                textBoxDirectorHint.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void textBoxDirectorHint_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxDirectorHint.Visibility = System.Windows.Visibility.Collapsed;
            textBoxDirector.Visibility = System.Windows.Visibility.Visible;
            textBoxDirector.Focus();
        }

        public List<film> films = new List<film>();

        public addFilm()
        {
            InitializeComponent();
            deserializeData();
            dataGridFilms.ItemsSource = films;
        }

        public film _newFilm = new film();

        public film newFilm
        {
            get { return _newFilm; }
        }

        private void addNewFilm_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please, enter the film's title", "Error");
                textBoxName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please, enter the film's year", "Error");
                textBoxName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please, enter the film's genre", "Error");
                textBoxName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please, enter the film's director", "Error");
                textBoxName.Focus();
                return;
            }

            _newFilm = new film(textBoxName.Text, Convert.ToInt32(textBoxYear.Text), textBoxGenre.Text, textBoxDirector.Text);
            films.Add(_newFilm);

            textBoxName.Clear();
            textBoxYear.Clear();
            textBoxGenre.Clear();
            textBoxDirector.Clear();

            dataGridFilms.ItemsSource = null;
            dataGridFilms.ItemsSource = films;
            seriliazeData();
            Logger.Log($"{_newFilm.Name} ({_newFilm.Year}) has been added to films");
        }

        private void deleteFilm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                films.RemoveAt(dataGridFilms.SelectedIndex);
                dataGridFilms.ItemsSource = null;
                dataGridFilms.ItemsSource = films;
            }
            catch
            {
                MessageBox.Show("Please, select a film you want to delete", "Error");
            }
            seriliazeData();

            Logger.Log($"{_newFilm.Name}({_newFilm.Year}) has been deleted from films");
        }

        private void seriliazeData()
        {
            using (FileStream fs = new FileStream("films.xml", FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<film>));
                ser.Serialize(fs, films);
            }
        }

        private void deserializeData()
        {
            if (File.Exists("films.xml"))
            {
                using (FileStream fs = new FileStream("films.xml", FileMode.Open))
                {
                    XmlSerializer deser = new XmlSerializer(typeof(List<film>));
                    films = (List<film>)deser.Deserialize(fs);
                }
            }
        }

        private void updateFilm_Click(object sender, RoutedEventArgs e)
        {
        }

        private void dataGridFilms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                textBoxName.Text = (e.AddedItems[0] as film).Name;
                textBoxYear.Text = (e.AddedItems[0] as film).Year.ToString();
                textBoxGenre.Text = (e.AddedItems[0] as film).Genre;
                textBoxDirector.Text = (e.AddedItems[0] as film).Director;
            }
        }
        
    }
}
