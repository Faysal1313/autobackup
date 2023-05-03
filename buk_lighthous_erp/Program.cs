using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using static buk_lighthous_erp.Heartbeat;

namespace buk_lighthous_erp
{
    class Program
    {
        static void Main(string[] args)
        {
           //string timer_houer = File.ReadAllText("timer.txt");
            //string timer = DateTime.Now.ToString("yyyy:MM:dd--'" + timer_houer.Trim() + "'");
            //string date_now = DateTime.Now.ToString("yyyy:MM:dd--HH");

            var exitCode = HostFactory.Run(x =>
            {
                x.Service<Heartbeat_calss>(s =>
                {
                    s.ConstructUsing(Heartbeat => new Heartbeat_calss());
                    s.WhenStarted(Heartbeat => Heartbeat.Start());
                    ////----------------------------------------------------------------------------------------
                    ///


                    //string timer_houer = File.ReadAllText("timer.txt");
                    //string timer = DateTime.Now.ToString("yyyy:MM:dd--'" + timer_houer.Trim() + "'");
                    //string date_now = DateTime.Now.ToString("yyyy:MM:dd--HH");
                    //Console.WriteLine(date_now+">>>>>><<<<<<<<<<"+ timer+ "          "+timer_houer);

                    //if (date_now == timer.Trim())
                    //{
                    //    db.Open();
                    //    string dbs = File.ReadAllText("dbline.txt");
                    //    string[] strarr = dbs.Split(',');
                    //    foreach (string items in strarr)
                    //    {
                    //        string path_location = File.ReadAllText("location.txt");
                    //        string path = path_location.Trim() +"\\"+ items.Trim() + " " + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss").Trim();
                    //        db.Run("backup database " + items.ToString().Trim() + " to Disk ='" + path + "'");
                    //    }
                    //    timer = DateTime.Now.AddHours(1).ToString("yyyy:MM:dd--HH");
                    //}
                    ////----------------------------------------------------------------------------------------
                    s.WhenStopped(Heartbeat => Heartbeat.Stop());

                });
                x.RunAsLocalSystem();
                x.SetServiceName("LightHouse_Services");
                x.SetDisplayName("LightHouse ERP System Service");
                x.SetDescription("Start LightHouse ERP System Autobackup - www.add4sas.com");

            });
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetType());
            Environment.ExitCode = exitCodeValue;

        }
    }
}
