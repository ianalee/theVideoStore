using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theVideoStore
{
    public class film
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _genre;

        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }

        private string _director;

        public string Director
        {
            get { return _director; }
            set { _director = value; }
        }

        private int _year;

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public film(string Name, int Year, string Genre, string Director)
        {
            _name = Name;
            _year = Year;
            _genre = Genre;
            _director = Director;
        }

        public film()
        {

        }

    }
}
