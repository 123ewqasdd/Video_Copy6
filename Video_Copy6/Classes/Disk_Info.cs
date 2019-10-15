using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Copy6.Classes
{
    class Disk_Info
    {
        public string disk { get; set; }
        public string Caption { get; set; }
        public string Name { get; set; }
        public double DiskTotal { get; set; }
        public double LogicalTotal { get; set; }
        public double UseSpace { get; set; }
        public double FreeSpace { get; set; }
        public double Percent { get; set; }
        public string Description { get; set; }
        public string VolumeName { get; set; }
    }
}
