using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace buk_lighthous_erp
{
    class Heartbeat
    {
        public class Heartbeat_calss
        {
            private readonly Timer _timer;
            public Heartbeat_calss()
            {
                _timer = new Timer(120000) { AutoReset = true };
                _timer.Elapsed += TimerElapsed;
                //_timer.Elapsed += TimerElapsed;
            }
            public static bool tt = false;
            private void TimerElapsed(object sender, ElapsedEventArgs e)
            {
                //  string timer_houer = File.ReadAllText("timer.txt");
                //string timer = DateTime.Now.ToString("yyyy:MM:dd--'" + timer_houer.Trim() + "'");
                // string date_now = DateTime.Now.ToString("yyyy:MM:dd--HH");
                //===================================
                //string timer_houer = File.ReadAllText("timer.txt");
                //string timer = DateTime.Now.ToString("yyyy:MM:dd--'" + timer_houer.Trim() + "'");
                //string date_now = DateTime.Now.ToString("yyyy:MM:dd--HH");
                // string[] lines = new string[] { DateTime.Now.ToString() };
                // File.AppendAllLines(@"D:\Project-Csharp\buk_lighthous_erp\buk_lighthous_erp\bin\Debug\Log_servies_timer.txt", lines);
                string message = "";
                buk.backup(ref message);

                if (message.Contains("ok buk"))
                {
                    Stop();
                    db.log_error("**********************Restart service Lighthouse erp  auto Backup*****************************");
                    Start();
                }
                if (message.Contains("Restart-1"))
                {
                    Stop();
                    db.log_error("**********************Restart service Lighthouse erp  auto Backup  Restart 01 at 08:00 *****************************");
                    Start();
                }

                //----------------------------------------------------------------------------------------

                //if (date_now == timer.Trim() && tt == false)
                //{
                //    string dbs = File.ReadAllText("dbline.txt");
                //    string[] strarr = dbs.Split(',');
                //    foreach (string items in strarr)
                //    {
                //        //  string path_location = File.ReadAllText("location.txt");
                //        //  string path = path_location.Trim() + "\\" + items.Trim() + " " + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss").Trim();
                //        try
                //        {
                //            //db.Run("backup database " + items.ToString().Trim() + " to Disk ='" + path + "'");
                //            //db.Run("backup database " + items.ToString().Trim() + " to Disk ='" + File.ReadAllText("location.txt").Trim() + "\\" + items.Trim() + " " + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss").Trim() + "'");
                //            db.Run("backup database " + items.ToString().Trim() + " to Disk ='" + File.ReadAllText("location.txt").ToString().Trim() + "\\" + items.Trim() + " " + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss").Trim() + "'");

                //        }
                //        catch (Exception ex)
                //        {
                //            Console.WriteLine(ex.Message);
                //        }
                //        finally { tt = true; Properties.Settings.Default.date_last = DateTime.Now.ToString("yyyyMMdd"); Properties.Settings.Default.Save(); }
                //    }
                //}

                //string stroge_Date = (Properties.Settings.Default.date_last + timer_houer.Trim());
                //string now_Date = (DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HH").Trim());

                //if ((Convert.ToDouble(stroge_Date) - Convert.ToDouble(now_Date)) != 0)
                //{
                //    tt = false;
                //}
                //--------------------------------------------------------------------------------------------
            }
            public void Start()
            {
                _timer.Start();
                db.log_error("................Start service Lighthouse erp  auto Backup...........");
            }
            public void Stop()
            {
                _timer.Stop();
                db.log_error(".............Shut down service Lighthouse erp  auto Backup...........");

            }

        }


    }
}
