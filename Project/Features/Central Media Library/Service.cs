using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features.Central_Media_Library
{
    public class Service
    {
        private string _dispName;
        private string _serviceName;
        public string DispName { get; set; }
        public string ServiceName { get; set; }


        public Service()
        {
            _dispName = "";
            _serviceName = "";
        }
        public Service(string dName, string selectedService)
        {
            _dispName = dName;
            _serviceName = selectedService;
        }
    }
}
