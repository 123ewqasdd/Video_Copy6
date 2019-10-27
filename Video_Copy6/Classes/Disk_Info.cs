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

        public static Disk_Info Get_Disk_Info(T_DISK_INFO tdi)
        {
            Disk_Info di = new Disk_Info();
            di.disk = tdi.PHYSICAL_NAME;
            di.DiskTotal = tdi.PHYSCIAL_TOTALSIZE.Value;
            di.Caption = tdi.LOGICAL_NAME;
            if (tdi.LOGICAL_TOTALSIZE.HasValue)
                di.LogicalTotal = tdi.LOGICAL_TOTALSIZE.Value;
            if (tdi.LOGICAL_USESPACE.HasValue)
                di.UseSpace = tdi.LOGICAL_USESPACE.Value;
            if (tdi.LOGICAL_PERCENT.HasValue)
                di.Percent = tdi.LOGICAL_PERCENT.Value;
            if (tdi.LOGICAL_FREESPACE.HasValue)
                di.FreeSpace = tdi.LOGICAL_FREESPACE.Value;
            di.VolumeName = tdi.FIELD1;
            di.Description = tdi.FIELD2;


            return di;
        }

        public static T_DISK_INFO Get_T_DISK_INFO(Disk_Info d)
        {
            T_DISK_INFO di = new T_DISK_INFO();
            di.PHYSICAL_NAME = d.disk;
            di.PHYSCIAL_TOTALSIZE = d.DiskTotal;
            di.LOGICAL_NAME = d.Caption;
            di.LOGICAL_TOTALSIZE = d.LogicalTotal;
            di.LOGICAL_USESPACE = d.UseSpace;
            di.LOGICAL_PERCENT = d.Percent;
            di.LOGICAL_FREESPACE = d.FreeSpace;
            di.IS_ONLINE = 1;
            di.FIELD1 = d.VolumeName;
            di.FIELD2 = d.Description;
            di.FIELD3 = "";
            di.FIELD4 = "";
            return di;
        }

        public static T_DISK_INFO Set_T_DISK_INFO_By_Disk_Info(T_DISK_INFO disk, Disk_Info d)
        {
            disk.PHYSICAL_NAME = d.disk;
            disk.PHYSCIAL_TOTALSIZE = d.DiskTotal;
            disk.LOGICAL_NAME = d.Caption;
            disk.LOGICAL_TOTALSIZE = d.LogicalTotal;
            disk.LOGICAL_USESPACE = d.UseSpace;
            disk.LOGICAL_PERCENT = d.Percent;
            disk.LOGICAL_FREESPACE = d.FreeSpace;
            disk.IS_ONLINE = 1;
            disk.FIELD1 = d.VolumeName;
            disk.FIELD2 = d.Description;
            disk.FIELD3 = "";
            disk.FIELD4 = "";
            return disk;
        }
    }
}
