using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theVideoStore
{
    class Film
    {
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _filmmaker;

        public string filmmaker
        {
            get { return _filmmaker; }
            set { _filmmaker = value; }
        }

        public string ShowInfo()
        {
            return $"{_name} - {_filmmaker}";
        }
    }
}
