using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theVideoStore
{
    public class client
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        private string _startdate;

        public string From
        {
            get { return _startdate; }
            set { _startdate = value; }
        }

        private string _enddate;

        public string Till
        {
            get { return _enddate; }
            set { _enddate = value; }
        }

        private film _film;

        public film Film
        {
            get { return _film; }
            set { _film = value; }
        }

        public string Info
        {
            get
            {
                return $"{_name} {_surname} rented {_film.Name} from {_startdate} to {_enddate}";
            }
        }

        public client(string Name, string Surname, string From, string Till, film Film)
        {
            _name = Name;
            _surname = Surname;
            _startdate = From;
            _enddate = Till;
            _film = Film;
        }

        public client ()
        {

        }
    }
}
