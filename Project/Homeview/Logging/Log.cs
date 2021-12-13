using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unite.HomeView.Logging
{
    class Log
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Mycol { get; set; }

        // I don't know what datatype timestamp is supposed to be
        public string Timestamp { get; set; }
    }
}
