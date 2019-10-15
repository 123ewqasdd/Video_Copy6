using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Video_Copy6.Tools
{
    /// <summary>
    /// txt文件读写类
    /// </summary>
    public class Helper_Txt
    {
        //读写锁，当资源处于写入模式时，其他线程写入需要等待本次写入结束之后才能继续写入
        static ReaderWriterLockSlim LogWriteLock = new ReaderWriterLockSlim();


        /// <summary>
        /// 读取指定文件，返回所有字符串内容
        /// </summary>
        /// <param name="fullname"></param>
        /// <returns></returns>
        public static string ReadAllText(string fullname)
        {
            try
            {
                //设置读锁为写入模式独占资源，其他写入请求需要等待本次写入结束之后才能继续写入
                //注意：长时间持有读线程锁或写线程锁会使其他线程发生饥饿 (starve)。 为了得到最好的性能，需要考虑重新构造应用程序以将写访问的持续时间减少到最小。
                //      从性能方面考虑，请求进入写入模式应该紧跟文件操作之前，在此处进入写入模式仅是为了降低代码复杂度
                //      因进入与退出写入模式应在同一个try finally语句块内，所以在请求进入写入模式之前不能触发异常，否则释放次数大于请求次数将会触发异常
                LogWriteLock.EnterReadLock();
                if (File.Exists(fullname))
                    return File.ReadAllText(fullname);
                else
                    throw new Exception("File does not exists," + fullname);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //退出度入模式，释放资源占用
                //注意：一次请求对应一次释放
                //      若释放次数大于请求次数将会触发异常[写入锁定未经保持即被释放]
                //      若请求处理完成后未释放将会触发异常[此模式不下允许以递归方式获取写入锁定]
                LogWriteLock.ExitReadLock();
            }
        }
        /// <summary>
        /// 按照指定编码格式读取指定文件，返回所有字符串内容
        /// </summary>
        /// <param name="fullname"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ReadAllText(string fullname, Encoding encoding)
        {
            try
            {
                //设置读写锁为写入模式独占资源，其他写入请求需要等待本次写入结束之后才能继续写入
                //注意：长时间持有读线程锁或写线程锁会使其他线程发生饥饿 (starve)。 为了得到最好的性能，需要考虑重新构造应用程序以将写访问的持续时间减少到最小。
                //      从性能方面考虑，请求进入写入模式应该紧跟文件操作之前，在此处进入写入模式仅是为了降低代码复杂度
                //      因进入与退出写入模式应在同一个try finally语句块内，所以在请求进入写入模式之前不能触发异常，否则释放次数大于请求次数将会触发异常
                LogWriteLock.EnterReadLock();
                if (File.Exists(fullname))
                    return File.ReadAllText(fullname, encoding);
                else
                    throw new Exception("File does not exists," + fullname);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //退出写入模式，释放资源占用
                //注意：一次请求对应一次释放
                //      若释放次数大于请求次数将会触发异常[写入锁定未经保持即被释放]
                //      若请求处理完成后未释放将会触发异常[此模式不下允许以递归方式获取写入锁定]
                LogWriteLock.ExitReadLock();
            }
        }
        /// <summary>
        /// 按照指定编码格式读取指定文件，返回所有字符串内容，按行分组
        /// </summary>
        /// <param name="fullname"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string[] ReadAllLines(string fullname, Encoding encoding)
        {
            try
            {
                //设置读写锁为写入模式独占资源，其他写入请求需要等待本次写入结束之后才能继续写入
                //注意：长时间持有读线程锁或写线程锁会使其他线程发生饥饿 (starve)。 为了得到最好的性能，需要考虑重新构造应用程序以将写访问的持续时间减少到最小。
                //      从性能方面考虑，请求进入写入模式应该紧跟文件操作之前，在此处进入写入模式仅是为了降低代码复杂度
                //      因进入与退出写入模式应在同一个try finally语句块内，所以在请求进入写入模式之前不能触发异常，否则释放次数大于请求次数将会触发异常
                LogWriteLock.EnterReadLock();
                if (File.Exists(fullname))
                    return File.ReadAllLines(fullname, encoding);
                else
                    throw new Exception("File does not exists," + fullname);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //退出写入模式，释放资源占用
                //注意：一次请求对应一次释放
                //      若释放次数大于请求次数将会触发异常[写入锁定未经保持即被释放]
                //      若请求处理完成后未释放将会触发异常[此模式不下允许以递归方式获取写入锁定]
                LogWriteLock.ExitReadLock();
            }
        }

        /// <summary>
        /// 读取指定文件，返回所有字符串内容，按行分组
        /// </summary>
        /// <param name="fullname"></param>
        /// <returns></returns>
        public static string[] ReadAllLines(string fullname)
        {
            try
            {
                //设置读写锁为写入模式独占资源，其他写入请求需要等待本次写入结束之后才能继续写入
                //注意：长时间持有读线程锁或写线程锁会使其他线程发生饥饿 (starve)。 为了得到最好的性能，需要考虑重新构造应用程序以将写访问的持续时间减少到最小。
                //      从性能方面考虑，请求进入写入模式应该紧跟文件操作之前，在此处进入写入模式仅是为了降低代码复杂度
                //      因进入与退出写入模式应在同一个try finally语句块内，所以在请求进入写入模式之前不能触发异常，否则释放次数大于请求次数将会触发异常
                LogWriteLock.EnterReadLock();
                if (File.Exists(fullname))
                    return File.ReadAllLines(fullname);
                else
                    throw new Exception("File does not exists," + fullname);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //退出写入模式，释放资源占用
                //注意：一次请求对应一次释放
                //      若释放次数大于请求次数将会触发异常[写入锁定未经保持即被释放]
                //      若请求处理完成后未释放将会触发异常[此模式不下允许以递归方式获取写入锁定]
                LogWriteLock.ExitReadLock();
            }
        }



        /// <summary>
        /// 将content写入制定文件中，如果存在则覆盖
        /// </summary>
        /// <param name="fullname">文件路径加文件名</param>
        /// <param name="content">文件内容</param>
        public static void WriteAllText(string fullname, string content)
        {
            AppendAllText(fullname, content, Encoding.Default, FileMode.Create);
        }

        /// <summary>
        /// 将content按制定编码格式写入制定文件中，如果存在则覆盖
        /// </summary>
        /// <param name="fullname">文件路径加文件名</param>
        /// <param name="content">文件内容</param>
        /// <param name="encoding"></param>
        public static void WriteAllText(string fullname, string content, Encoding encoding)
        {
            AppendAllText(fullname, content, encoding, FileMode.Create);
        }

        /// <summary>
        /// 将content写入制定文件中，如果存在则覆盖
        /// </summary>
        /// <param name="fullname">文件路径加文件名</param>
        /// <param name="contents">文件内容</param>
        public static void WriteAllText(string fullname, string[] contents)
        {
            AppendAllLines(fullname, contents, Encoding.Default, FileMode.Create);
           
        }

        /// <summary>
        /// 将contents按制定编码格式写入制定文件中，如果存在则覆盖
        /// </summary>
        /// <param name="fullname">文件路径加文件名</param>
        /// <param name="contents">文件内容</param>
        /// <param name="encoding"></param>
        public static void WriteAllText(string fullname, string[] contents, Encoding encoding)
        {
            AppendAllLines(fullname, contents, encoding, FileMode.Create);
        }
        /// <summary>
        /// 将content追加到文件中，如果不存在则报错
        /// </summary>
        /// <param name="fullname"></param>
        /// <param name="contents"></param>
        public static void AppendAllText(string fullname, string contents)
        {
            AppendAllText(fullname, contents, Encoding.Default, FileMode.Append);
        }
        /// <summary>
        /// 将content追加到文件中，如果不存在则报错
        /// </summary>
        /// <param name="fullname"></param>
        /// <param name="contents"></param>
        public static void AppendAllText(string fullname, string contents, Encoding encoding, FileMode fMode)
        {
           
            AppendAllLines(fullname, new string[] { contents }, encoding, fMode);
        }
        /// <summary>
        /// 将contents追加到文件中，如果不存在则报错
        /// </summary>
        /// <param name="fullname"></param>
        /// <param name="contents"></param>
        public static void AppendAllLines(string fullname, string[] contents)
        {
            AppendAllLines(fullname, contents, Encoding.Default, FileMode.Append);
        }
        /// <summary>
        /// 将contents追加到文件中，如果不存在则报错
        /// </summary>
        /// <param name="fullname"></param>
        /// <param name="contents"></param>
        public static void AppendAllLines(string fullname, string[] contents, Encoding encoding, FileMode fModel)
        {
            Encoding encod = encoding;
            try
            {
                byte[] logContentBytes;

                //由于设置了文件共享模式为允许随后写入，所以即使多个线程同时写入文件，也会等待之前的线程写入结束之后再执行，而不会出现错误
                using (FileStream logFile = new FileStream(fullname, fModel, FileAccess.Write, FileShare.Write | FileShare.Read))
                {
                    logFile.Seek(0, SeekOrigin.End);
                    for (int i = 0; i < contents.Length; i++)
                    {
                        logContentBytes = encod.GetBytes(contents[i]);
                        logFile.Write(logContentBytes, 0, logContentBytes.Length);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }

    }
}
