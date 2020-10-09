using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ATMECS_Task_One
{
    public delegate void threaddelegate();
    class Program
    {
        static void Main(string[] args)
        {
            List<Thread> myThreads = new List<Thread>();
            myThreads.Add(new Thread(Actions.Action1));
            myThreads.Add(new Thread(Actions.Action2));
            myThreads.Add(new Thread(Actions.Action3));
            myThreads.Add(new Thread(Actions.Action4));
            foreach (var CurrentThread in myThreads)
            {               
                CurrentThread.Start();
            }           
            Console.ReadKey();
         }

        

    }
}
