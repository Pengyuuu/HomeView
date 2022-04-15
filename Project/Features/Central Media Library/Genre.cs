using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Central_Media_Library
{
    public class Genre
    {
        private string _dispName;
        private string _genreName;
        public string DispName { get; set; }
        public string GenreName { get; set; }


        public Genre()
        {
            _dispName = "";
            _genreName = "";
        }
        public Genre(string dName, string selectedGenre)
        {
            _dispName = dName;
            _genreName = selectedGenre;
        }
    }
}
