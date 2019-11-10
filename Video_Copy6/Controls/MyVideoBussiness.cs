using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Video_Copy6.Classes;
using Video_Copy6.Tools;

namespace Video_Copy6.Controls
{
    class MyVideoBussiness
    {
        /// <summary>
        /// 获取硬盘所有信息
        /// </summary>
        /// <returns></returns>
        public static List<T_DISK_INFO> GetList_Disk_Info()
        {
            using (var ctx = new myVideoEntities())
            {
                try
                {
                    //Querying with LINQ to Entities
                    var L2EQuery = ctx.T_DISK_INFO.OrderBy(s => s.IS_ONLINE);
                    var disks = L2EQuery.ToList<T_DISK_INFO>();
                    return disks;
                }
                catch (Exception ex)
                {
                    Helper_log.Write_Error(ex.InnerException.Message + ";" + ex.Message);
                    return new List<T_DISK_INFO>();
                }
                 
            }
        }

        public static T_Video GetList_Video_Info(string name)
        {
            using (var ctx = new myVideoEntities())
            {
                try
                {
                    //Querying with LINQ to Entities
                    var L2EQuery = ctx.T_Video.FirstOrDefault(s => s.FILE_NAME ==(name));
                    
                    return L2EQuery;
                }
                catch (Exception ex)
                {
                    Helper_log.Write_Error(ex.InnerException.Message + ";" + ex.Message);
                    return null;
                }

            }
        }

        public static List<T_CONFIG> GetList_Config(string key)
        {
            using (var ctx = new myVideoEntities())
            {
                try
                {
                    //Querying with LINQ to Entities
                    var L2EQuery = ctx.T_CONFIG.Where(s => s.KEY == (key));
                    var vs = L2EQuery.ToList<T_CONFIG>();
                    return vs;

                }
                catch (Exception ex)
                {
                    Helper_log.Write_Error(ex.InnerException.Message + ";" + ex.Message);
                    return null;
                }
            }
        }

        public static List<T_Video> GetList_Video_Info_Like(string name,int top_num = 20)
        {
            //using (var ctx = new myVideoEntities())
            //{
            //    try
            //    {                    
            //        //Querying with LINQ to Entities
            //        var L2EQuery = ctx.T_Video.Where(s => s.FILE_NAME.Contains(name)).Take(top_num);
            //        var vs = L2EQuery.ToList<T_Video>();
            //        return vs;
            //    }
            //    catch (Exception ex)
            //    {
            //        Helper_log.Write_Error(ex.InnerException.Message + ";" + ex.Message);
            //        return new List<T_Video>();
            //    }

            //}
            using (var ctx = new myVideoEntities())
            {
                try
                {
                    var L2EQuery = ctx.T_Video.SqlQuery("select * from T_Video where FILE_NAME like '%" + name + "%' limit 0," + top_num);
                    var vs = L2EQuery.ToList<T_Video>();
                    return vs;
                }
                catch (Exception ex)
                {
                    Helper_log.Write_Error(ex.InnerException.Message + ";" + ex.Message);
                    return new List<T_Video>();
                }

            }
        }

        //using (var ctx = new myVideoEntities())
        //{
        //    //Querying with LINQ to Entities
        //    var L2EQuery = ctx.T_DISK_INFO.Where(s => s.LOGICAL_NAME == "C:\\");
        //    var disks = L2EQuery.FirstOrDefault<T_DISK_INFO>();

        //    //LINQ Query syntax:
        //    var L2EQuery2 = from di in ctx.T_DISK_INFO
        //                    where di.LOGICAL_NAME == "C:\\"
        //                    select di;

        //    var disks2 = L2EQuery2.FirstOrDefault<T_DISK_INFO>();


        //    ////Querying with Object Services and Entity SQL
        //    //string sqlString = "select * from T_DISK_INFO as di where di.LOGICAL_NAME == 'C:\\'";
        //    //var objctx = (ctx1 as IObjectContextAdapter).ObjectContext;
        //    //ObjectQuery<T_DISK_INFO> disk3 = objctx.CreateQuery<T_DISK_INFO>(sqlString);
        //    //T_DISK_INFO newDisk = disk3.First<T_DISK_INFO>();

        //    ////Native SQL:
        //    //var disk4 = ctx.T_DISK_INFO.SqlQuery("select * from T_DISK_INFO as di where di.LOGICAL_NAME == 'C:\\'")
        //    //    .FirstOrDefault<T_DISK_INFO>();

        public static int Delete_Disk_Info(List<T_DISK_INFO> ds)
        {
            int i_dele = 0;
            using (var ctx = new myVideoEntities())
            {
                try
                {
                    for (int i = 0; i < ds.Count; i++)
                        i_dele += ctx.Database.ExecuteSqlCommand("delete from t_disk_info where ID = " + ds[i].ID);
                }
                catch (Exception ex)
                {
                    Helper_log.Write_Error(ex.InnerException.Message + ";" + ex.Message);
                }


                return i_dele;
            }
                
        }

        public static int Update_Task_Info(string id, int copy_count)
        {
            int i_dele = 0;
            using (var ctx = new myVideoEntities())
            {
                try
                {
                    i_dele += ctx.Database.ExecuteSqlCommand("update T_Works set COPY_COUNT = " + copy_count + " where NAME = '" + id + "'");
                }
                catch (Exception ex)
                {
                    Helper_log.Write_Error(ex.InnerException.Message + ";" + ex.Message);
                }


                return i_dele;
            }

        }

        public static int Delete_Video_Info(int disk_id)
        {
            int i_dele = 0;
            using (var ctx = new myVideoEntities())
            {
                try
                {
                    ctx.Database.ExecuteSqlCommand(string.Format("delete from T_VIDEO_TAGS where ID_TAGS in (select ID from T_VIDEO where DEVICE_UID = {0})", disk_id));
                    i_dele = ctx.Database.ExecuteSqlCommand(string.Format("delete from T_VIDEO where DEVICE_UID = {0}", disk_id));
                }
                catch (Exception ex)
                {
                    Helper_log.Write_Error(ex.InnerException.Message + ";" + ex.Message);
                }

                return i_dele;
            }
        }

        public static int Add_Task_Info(Task_Info task,List<T_Video> vs)
        {
            using (var ctx = new myVideoEntities())
            {
                try
                {
                    T_WORKS w = new T_WORKS();
                    DateTime dt_now = DateTime.Now;
                    w.CREATETIME = dt_now;
                    w.NAME = task.id;
                    w.SOURCE_SIZE = task.source_size;
                    w.TARGET_HD_SIZE = task.target_size;
                    w.TARGET_LOCATION = task.target;
                    w.TARGET_FREE_SIZE = task.target_free_size;
                    w.VIDEO_COUNT = vs.Count;
                    w.COPY_COUNT = 0;
                    w.MEMO = task.copy_type;
                    ctx.T_WORKS.Add(w);
                    int row = ctx.SaveChanges();
                    if (row > 0)
                    {
                        foreach (var v in vs)
                        {
                            T_WORKS_SUB ws = new T_WORKS_SUB();
                            ws.CREATE_TIME = dt_now;
                            ws.FILESIZE = v.FILESIZE;
                            ws.FILE_DIR = v.FILE_DIR;
                            ws.FILE_EXTENSION = v.FILE_EXTENSION;
                            ws.FILE_FULLPATH = v.FILE_FULLPATH;
                            ws.FILE_NAME = v.FILE_NAME;
                            ws.FILE_ROOT = v.FILE_ROOT;
                            ws.ID_VIDEO = v.ID;
                            ws.PID = w.ID;
                            ctx.T_WORKS_SUB.Add(ws);
                        }
                    }
                    return ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Helper_log.Write_Error(ex.InnerException.Message + ";" + ex.Message);
                    return 0;
                }
             
            }
           
        }

        /// <summary>
        /// 更新影片信息
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>
        public static int Add_Video_Info(File_Info fi)
        {
            using (var ctx = new myVideoEntities())
            {
                try
                {
                    T_Video v = new T_Video();
                    v.CREATE_TIME = DateTime.Now;
                    v.Device_UID = fi.fileRootID;
                    v.FILESIZE = fi.fileSize;
                    v.FILE_ROOT = fi.fileRoot;
                    v.FILE_DIR = fi.fileDir;
                    v.FILE_EXTENSION = fi.fileExtension;
                    v.FILE_FULLPATH = fi.fileFullPath;
                    v.FILE_INDEX = fi.fileIndex;
                    v.FILE_NAME = fi.fileName;
                    ctx.T_Video.Add(v);
                    return ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Helper_log.Write_Error(ex.InnerException.Message + ";" + ex.Message);
                    return 0;
                }
            
                
            }
        }

        /// <summary>
        /// 更新硬盘信息
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static int Update_Disk_Info(List<Disk_Info> ds)
        {
            
            using (var ctx = new myVideoEntities())
            {
                
                ctx.Database.ExecuteSqlCommand("update T_DISK_INFO set IS_ONLINE = 0");
               
                try
                {
                    foreach (var d in ds)
                    {

                        //Querying with LINQ to Entities
                        var L2EQuery = ctx.T_DISK_INFO.Where(s =>
                        s.PHYSICAL_NAME == d.disk &&
                        s.PHYSCIAL_TOTALSIZE == d.DiskTotal &&
                        s.FIELD1 == d.VolumeName &&
                        s.LOGICAL_TOTALSIZE == d.LogicalTotal);

                        var disk = L2EQuery.FirstOrDefault<T_DISK_INFO>();
                        if (disk == null)
                        {
                            T_DISK_INFO di = Disk_Info.Get_T_DISK_INFO(d);
                            ctx.T_DISK_INFO.Add(di);
                        }
                        else
                        {
                            disk = Disk_Info.Set_T_DISK_INFO_By_Disk_Info(disk, d);
                            
                        }
                        //ctx.SaveChanges();
                    }
                    return ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Helper_log.Write_Error(ex.InnerException.Message + ";" + ex.Message);
                    return 0;
                }

                
               
            }

           
        }


    }
}
