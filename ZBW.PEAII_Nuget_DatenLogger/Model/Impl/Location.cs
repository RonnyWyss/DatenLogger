using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBW.PEAII_Nuget_DatenLogger.Model.Impl
{
    class Location
    {


        public int LocationId { get; set; }
        public int AdressFk { get; set; }
        public int Room { get; set; }
        public string Designation { get; set; }
        public string Building { get; set; }
     }
}
