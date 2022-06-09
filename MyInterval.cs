using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoTimer
{
    public class MyInterval:In_Interval
    {
        public string NameInter { get; private set; }
        public int MinuteInter { get; private set; }
        public MyInterval(string nam,int minut) 
        {
            NameInter = nam;
            MinuteInter = minut;
        }
    }
    public class MyTomatoTim : In_TomatoTamer 
    {
        public delegate void transferToTheTop(string str);//делегад для передачи на вывод
        public transferToTheTop EndTimer;//конец таймера/интервала
        public transferToTheTop MyTimeNow;//время до конца
        public transferToTheTop getMyNamInterval;//название интервала
        public delegate void myStopWotch(int min);
        public myStopWotch getMyMinute;//передача времени
        int numActivInter;//номер активного интервала таймера
        List<MyInterval> timerIntervalList;//список интервалов
        public MyTomatoTim(List<MyInterval> interList) 
        {
            numActivInter = 0;
            timerIntervalList=interList;
        }
        //получение и оброботка данных об изменении времени
        public void newTimeIntervalActiv(int min) 
        {
            if (min != 0) 
            {
                string str = ((min < 10) ? "0" + min : min.ToString());
                MyTimeNow?.Invoke(str);
            }
            else 
            {
                
                
                
                    numActivInter++;
                    if (numActivInter == timerIntervalList.Count) 
                    {
                        EndTimer?.Invoke("End Time!!!");
                        numActivInter = 0;
                    }
                    else 
                    {
                        getMyNamInterval?.Invoke(timerIntervalList[numActivInter].NameInter);
                        MyTimeNow?.Invoke(timerIntervalList[numActivInter].MinuteInter+" : 00");
                    }
                

            }
        }
        public void StartTimer() 
        {
            getMyNamInterval?.Invoke(timerIntervalList[numActivInter].NameInter);
            MyTimeNow?.Invoke(timerIntervalList[numActivInter].MinuteInter + " : 00");
            getMyMinute?.Invoke(timerIntervalList[numActivInter].MinuteInter);  
        }
    }
    public class myStopWotch 
    {
        public delegate void getNewTime(int min);//передает шзменение времени
        public getNewTime getTime;
        bool flagStart;
        Stopwatch myWotch;
        public myStopWotch() 
        {
            myWotch = new Stopwatch();
            flagStart = false;
        }
        
        public void StartInterval(int min) 
        {
            int myMin = min;
            
            flagStart = true;
            myWotch.Start();
            do 
            {
                if (myWotch.ElapsedMilliseconds >= 60000) 
                {
                    
                    myWotch.Restart();
                    myMin--;
                    if (myMin == 0) 
                    { 
                            getTime?.Invoke(myMin);
                            myWotch.Stop();
                            flagStart = false;
                    }
                    else
                    {
                            getTime?.Invoke(myMin);
                                  
                    }
                }

            } while (flagStart);
        }
    }
    
}
