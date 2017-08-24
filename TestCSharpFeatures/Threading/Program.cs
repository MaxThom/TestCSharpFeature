using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");


            /*var t = StartTaskLater();
            t.Start();
            t.Wait();

            t = StartTaskNow();
            t.Wait();

            var t2 = ReturnTask();
            Console.WriteLine($"Return : {t2.Result}");

            */
            var t2 = ReturnTaskWith();
            
            Console.WriteLine($"ContinueWith Result : {t2.Result}");/*



            var t3 = ReturnTaskTimeOut();
            t3.Wait(new TimeSpan(0, 0, 0, 0, 20));
            Console.WriteLine($"Is Faulted : {t3.IsFaulted}");
            //Console.WriteLine($"Result : {t3.Result}");
            Console.WriteLine($"Exception : {t3.Exception}");
            Console.WriteLine($"Is Canceled : {t3.IsCanceled}");
            Console.WriteLine($"Status : {t3.Status}");*/



            CancellationTokenSource token = new CancellationTokenSource();
            var t4 = ReturnTaskTimeOutWithToken(token.Token);
            token.Cancel();
            t4.Wait();
            Console.WriteLine($"T4 Is Faulted : {t4.IsFaulted}");
            //Console.WriteLine($"Result : {t4.Result}");
            Console.WriteLine($"Exception : {t4.Exception}");
            Console.WriteLine($"Is Canceled : {t4.IsCanceled}");
            Console.WriteLine($"Status : {t4.Status}");

            /*var t5 = ReturnTaskTimeOut();
            var completed = Task.WaitAll(new Task[] {t5}, new TimeSpan(0, 0, 0, 0, 2000));
            Console.WriteLine(completed);
            Console.WriteLine($"Is Faulted : {t5.IsFaulted}");
            //Console.WriteLine($"Result : {t5.Result}");
            Console.WriteLine($"Exception : {t5.Exception}");
            Console.WriteLine($"Is Canceled : {t5.IsCanceled}");
            Console.WriteLine($"Status : {t5.Status}");*/


            while (true)
                Console.WriteLine("2");

            Console.WriteLine("End");
        }

        private static Task StartTaskLater()
        {
            Task t = new Task(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Later Number : {i}");
                }
            });
            

            return t;
        }

        private static Task StartTaskNow()
        {
            Task t = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Now Number : {i}");
                }
            });


            return t;
        }

        private static Task<int> ReturnTask()
        {
            var t = Task<int>.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                return 5;
            });

            return t;
        }

        private static Task<int> ReturnTaskWith()
        {
            var t = Task<int>.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                return 5;
            }).ContinueWith((task) =>
            {
                Console.WriteLine($"ContinueWith Result : {task.Result}");
                return task.Result+1;
            });

            return t;
        }

        private static Task<int> ReturnTaskTimeOut()
        {
            var t = Task<int>.Factory.StartNew(() =>
            {
                Thread.Sleep(10000);
                return 15;
            });

            return t;
        }

        private static Task<int> ReturnTaskTimeOutWithToken(CancellationToken token)
        {
            var t = Task<int>.Factory.StartNew((state) =>
            {
                CancellationToken tk = (CancellationToken)state;

                
                while (!tk.IsCancellationRequested)
                {
                    Console.WriteLine("1");
                }

                if (tk.IsCancellationRequested)
                    tk.ThrowIfCancellationRequested();

                return 15;

            }, token);

            return t;
        }

    }
}
