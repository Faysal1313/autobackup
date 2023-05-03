using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buk_lighthous_erp
{
    class buk
    {
        
        //1-open database 
        //2-initilez database and read 
        //3-get time to schadule 
        //4-statrt buk 
        //5-exit to wait schadule 
      // private static string timer_houer2 = DateTime.Now.ToString("yyyy-MM-dd:HH");
       private static bool lockk=Properties.Settings.Default.lockk;
                
        private static string dx;
        static public void backup(ref string message)
        {
            //  static string timer_houer2 = DateTime.Now.ToString("yyyy-MM-dd:HH:mm");
            // string timer_houer2 = DateTime.Now.ToString("yyyy-MM-dd:HH");
            string timer_houer2;
            try
            {
               // Properties.Settings.Default.Reset();

                // db.Open();
                string timer_houer = "";
                DateTime d = DateTime.Now;
                //string timer_houer2 = "";
                timer_houer = DateTime.Now.ToString("yyyy-MM-dd:") + File.ReadAllText("timer.txt");

                if (lockk == false)
                {
                    timer_houer2 = DateTime.Now.ToString("yyyy-MM-dd:") + File.ReadAllText("timer.txt");
                    // timer2 =now 24-04-2023:23
                }
                else
                {
                    //read from file 
                    timer_houer2 = Properties.Settings.Default.timer_houer2;
                }

                //string time1 = DateTime.Now.ToString("HH:mm:ss");
                db.log_error("timer_houer1 :**" + timer_houer+"** in file pram "+ "timer_houer2 :**" + timer_houer2+"**");
               // db.log_error("timer_houer2 :" + timer_houer2);

                string items = File.ReadAllText("sql_prams.txt");
                string time = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string path = File.ReadAllText("location.txt") + "\\" + items + " " + time + ".bac";

                if (timer_houer == timer_houer2)
                {
                    db.Open();
                    db.Run("use master backup database " + items.ToString().Trim() + " to Disk ='" + path + "'");
                    message = "ok buk";
                    string t = DateTime.Now.ToString("HH");
                    dx = d.AddDays(1).ToString("yyyy-MM-dd:")+ File.ReadAllText("timer.txt");
                    timer_houer2 = dx;
                    db.log_error(dx + "    @#$@#$@#$@#$@#$@#$@#$@");
                    db.log_error(Properties.Settings.Default.timer_houer2 + "    @#$@#$@#$@#$@#$@#$@#$@");
                    Properties.Settings.Default.timer_houer2 = dx;
                    timer_houer2 = Properties.Settings.Default.timer_houer2;
                    db.log_error(timer_houer2 + "    $$$$$$$$$$$$$$$$$$$$$$$");

                    lockk = true;
                    Properties.Settings.Default.lockk=true;
                    Properties.Settings.Default.Save();
                   // db.log_error(timer_houer2+"    @#$@#$@#$@#$@#$@#$@#$@");


                }
                if (timer_houer2 == DateTime.Now.ToString("yyyy-MM-dd:08"))
                {
                   //restart 
                    message = "Restart-1";
                }
            }
            catch (Exception ex)
            {

                db.log_error(ex.Message);
            }
        }
    }
}
