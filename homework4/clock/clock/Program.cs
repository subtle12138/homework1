using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clock
{
    public class PresentTime : EventArgs
    {
        public System.DateTime Now = DateTime.Now;
    }
    public delegate void AlarmClockTime(object sender, PresentTime e);

    public class Alarm
    {
        public event AlarmClockTime AlarmEvent;
        public int anHour { set; get; }
        public int aMinute { set; get; }

        public void SetTime ()
        {
            Console.WriteLine("请设置闹钟时间");
            SetHour();
            SetMinute();
        }
        private void SetHour()
        {
            Console.WriteLine("输入时数：");
            anHour = int.Parse(Console.ReadLine());
            if (anHour<0||anHour>23)
            {
                Console.WriteLine("时数错误");
                SetHour();
            }
        }
        private void SetMinute()
        {
            Console.WriteLine("输入分数：");
            aMinute = int.Parse(Console.ReadLine());
            if (anHour < 0 || anHour > 59)
            {
                Console.WriteLine("分数错误");
                SetMinute();
            }
        }

        public void LookTime()
        {
            PresentTime time = new PresentTime();
            int bHour = time.Now.Hour;
            int bMinute = time.Now.Minute;
            if(bHour==anHour&&bMinute==aMinute)
            {
                time.Now = DateTime.Now;
                AlarmEvent(this, time);
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
                LookTime();
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var Alarm = new Alarm();
            Alarm.SetTime();
            Alarm.AlarmEvent += myAlarmEvent;
            Alarm.LookTime();
        }
        static void myAlarmEvent(object sender,PresentTime a)
        {
            Console.WriteLine("时间到啦");
        }
    }
}
