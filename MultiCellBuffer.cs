using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AirlineProgram
{
    class MultiCellBuffer
    {
        private static readonly Semaphore write = new Semaphore(3, 3);
        private static readonly Semaphore read = new Semaphore(2, 2);
        private static readonly String[] buffer = new String[3];
        private static readonly object obj = new object();

        private static int head = 0;
        private static int tail = 0;
        public static int elements = 0;

        //Using monitor and semaphores to account for the reader writer problem.
        //This is the writer
        public void setCell(string bufValue)
        {
            write.WaitOne();
            lock(obj)
            {
                while(elements == 3)
                {
                    Monitor.Wait(obj);
                }
                buffer[tail] = bufValue;
                tail = (tail + 1) % 3;

                elements++;
                write.Release();
                Monitor.Pulse(obj);
            }
        }

        //this is the reader
        public string getCell()
        {
            read.WaitOne();
            lock (obj)
            {
                while(elements == 0)
                {
                    Monitor.Wait(obj);
                }
                string returnedVal = buffer[head];
                head = (head + 1) % 3;
                elements--;
                read.Release();
                Monitor.Pulse(obj);
                return returnedVal;
            }

        }
    }
}
