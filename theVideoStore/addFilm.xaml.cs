using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        
        public List<film> films = new List<film>();

        public addFilm()
        {
            InitializeComponent();
            deserializeData();
            listBoxFilms.ItemsSource = films;
        }

        public film _newFilm = new film();

        public film newFilm
        {
            get { return _newFilm; }
        }

        private void addNewFilm_Click(object sender, RoutedEventArgs e)
        {
            DateTime year;
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Please, enter the film's title", "Error");
                textBoxName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxYear.Text))
            {
                MessageBox.Show("Please, enter the film's year", "Error");
                textBoxName.Focus();
                return;
            }

            if (DateTime.TryParseExact(textBoxYear.Text, "yyyy", null, System.Globalization.DateTimeStyles.None, out year) == false)
            {
                MessageBox.Show("Please, enter a year");
                textBoxYear.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxGenre.Text))
            {
                MessageBox.Show("Please, enter the film's genre", "Error");
                textBoxName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxDirector.Text))
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

            listBoxFilms.ItemsSource = null;
            listBoxFilms.ItemsSource = films;

            seriliazeData();
            logger.Log($"{_newFilm.Name} ({_newFilm.Year}) has been added to films");
        }

        private void deleteFilm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                    films.RemoveAt(listBoxFilms.SelectedIndex);
                    listBoxFilms.ItemsSource = null;
                    listBoxFilms.ItemsSource = films;

                    textBoxName.Clear();
                    textBoxYear.Clear();
                    textBoxGenre.Clear();
                    textBoxDirector.Clear();

                    seriliazeData();
                    logger.Log($"{_newFilm.Name}({_newFilm.Year}) has been deleted from films");
            }
                
            catch
            {
                MessageBox.Show("Please, select a client you want to delete", "Error");
            }
            
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

        public film _updatedFilm = new film();

        public film updatedFilm
        {
            get { return _updatedFilm; }
        }

        private void updateFilm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                films.RemoveAt(listBoxFilms.SelectedIndex);
            
                _updatedFilm = new film(textBoxName.Text, Convert.ToInt32(textBoxYear.Text), textBoxGenre.Text, textBoxDirector.Text);
                films.Add(_updatedFilm);

                listBoxFilms.ItemsSource = null;
                listBoxFilms.ItemsSource = films;
            }
            catch
            {
                MessageBox.Show("Please, select a film you want to update", "Error");
            }
        }

        private void listBoxFilms_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
