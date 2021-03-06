using System;
using System.Collections.Generic;
using System.Threading;

namespace lab_8
{
    class Program
    {
        public static bool isPrimeNumber(long number)
        {
            if (number < 2)
                return false;
            if (number == 2)
                return true;
            for (long i = 2; i < number; ++i)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {

            HashSet<long> hashset = new HashSet<long>();
            
            bool looped = true;
            
            Object locker = new Object();

            Thread thread1 = new Thread(() =>
            {
                for (long i = 0; looped; i++)
                {
                    if (isPrimeNumber(i))
                    {

                        lock (locker) {
                            hashset.Add(i);
                        }
                    }
                }
            }); 
            
            thread1.Start();

            Thread thread2 = new Thread(() =>
            {
                for (long i = 1; looped; i++)
                {
                    if (isPrimeNumber(i))
                    {

                        lock (locker)
                        {
                            hashset.Add(i);
                        }
                    }
                }
            }); 
            
            thread2.Start();

            Thread thread3 = new Thread(() =>
            {
                for (long i = 2; looped; i++)
                {
                    if (isPrimeNumber(i))
                    {

                        lock (locker)
                        {
                            hashset.Add(i);
                        }
                    }
                }
            }); 
            
            thread3.Start();

            Thread thread4 = new Thread(() =>
            {
                for (long i = 3; looped; i++)
                {
                    if (isPrimeNumber(i))
                    {
                        lock (locker)
                        {
                            hashset.Add(i);
                        }
                    }
                }
            }); 
            
            thread4.Start();

            Thread.Sleep(10000);
            looped = false;

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

            Console.WriteLine(hashset.Count);
            
        }
    }
}
