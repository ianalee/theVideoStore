using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theVideoStore
{
    public class Client
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

        public string showInfo()
        {
            return $"{_name} {_surname} c {_startdate} по {_enddate}";
        }

        public Client(string Name, string Surname, string From, string Till)
        {
            _name = Name;
            _surname = Surname;
            _startdate = From;
            _enddate = Till;
        }

        public Client ()
        {

        }
    }
}
