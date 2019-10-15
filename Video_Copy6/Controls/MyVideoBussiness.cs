using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video_Copy6.Classes;

namespace Video_Copy6.Controls
{
    class MyVideoBussiness
    {
        public static int Update_Disk_Info(List<Disk_Info> ds)
        {
            using (var ctx = new myVideoEntities())
            {

               // ctx.Database.ExecuteSqlCommand("update T_DISK_INFO set IS_ONLINE = 'false'");

                foreach (var d in ds)
                {
                    //Querying with LINQ to Entities
                    var L2EQuery = ctx.T_DISK_INFO.Where(s =>
                    s.PHYSICAL_NAME == d.disk &&
                    s.PHYSCIAL_TOTALSIZE == d.DiskTotal &&
                    s.FIELD1 == d.VolumeName &&
                    s.LOGICAL_TOTALSIZE == d.LogicalTotal);

                    var disk = L2EQuery.SingleOrDefault<T_DISK_INFO>();
                    if (disk == null)
                    {
                        T_DISK_INFO di = new T_DISK_INFO();
                        di.PHYSICAL_NAME = d.disk;
                        di.PHYSCIAL_TOTALSIZE = d.DiskTotal;
                        di.LOGICAL_NAME = d.Caption;
                        di.LOGICAL_TOTALSIZE = d.LogicalTotal;
                        di.LOGICAL_USESPACE = d.UseSpace;
                        di.LOGICAL_PERCENT = (long)d.Percent;
                        di.IS_ONLINE = true;
                        di.FIELD1 = d.VolumeName;
                        di.FIELD2 = d.Description;
                        di.FIELD3 = "";
                        di.FIELD4 = "";
                        ctx.T_DISK_INFO.Add(di);
                    }
                    else
                    {
                        disk.PHYSICAL_NAME = d.disk;
                        disk.PHYSCIAL_TOTALSIZE = d.DiskTotal;
                        disk.LOGICAL_NAME = d.Caption;
                        disk.LOGICAL_TOTALSIZE = d.LogicalTotal;
                        disk.LOGICAL_USESPACE = d.UseSpace;
                        disk.LOGICAL_PERCENT = (long)d.Percent;
                        disk.IS_ONLINE = true;
                        disk.FIELD1 = d.VolumeName;
                        disk.FIELD2 = d.Description;
                        disk.FIELD3 = "";
                        disk.FIELD4 = "";
                        
                    }
                }
                return ctx.SaveChanges();
            }

           
        }
    }
}
