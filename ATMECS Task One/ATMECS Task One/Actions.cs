using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ATMECS_Task_One
{
    
    internal static class Actions
    {
        public static Semaphore _semaphore = new Semaphore(1,1);
        // Action 1
        public static void Action1()
        {
            _semaphore.WaitOne();
            Console.WriteLine($"Action 1 Started in Thread Id: "+Thread.CurrentThread.ManagedThreadId);            
            // For Checking
            Thread.Sleep(3000);
            Console.WriteLine($"Action 1 Completed in Thread Id: " + Thread.CurrentThread.ManagedThreadId);
            _semaphore.Release();
        }
        // Action 2
        public static void Action2()
        {
            _semaphore.WaitOne();
            Console.WriteLine($"Action 2 Started in Thread Id: " + Thread.CurrentThread.ManagedThreadId);
            
            // For Checking
            Thread.Sleep(3000);
            Console.WriteLine($"Action 2 Completed in Thread Id: " + Thread.CurrentThread.ManagedThreadId);
            _semaphore.Release();
        }
        // Action 3
        public static void Action3()
        {
            _semaphore.WaitOne();
            Console.WriteLine($"Action 3 Started in Thread Id: " + Thread.CurrentThread.ManagedThreadId);
            
            // For Checking
            Thread.Sleep(3000);
            Console.WriteLine($"Action 3 Completed in Thread Id: " + Thread.CurrentThread.ManagedThreadId);
            _semaphore.Release();
        }
        // Action 4
        public static void Action4()
        {
            _semaphore.WaitOne();
            Console.WriteLine($"Action 4 Started in Thread Id: " + Thread.CurrentThread.ManagedThreadId);
            
            // For Checking
            Thread.Sleep(3000);
            Console.WriteLine($"Action 4 Completed in Thread Id: " + Thread.CurrentThread.ManagedThreadId);
            _semaphore.Release();
        }
    }
}
