using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Bomberman
{
    class Detonator
    {
        List<Bomba> bomby;
        ConsoleOperation consoleOperation;

        public void setBomby(List<Bomba> bomby)
        {
            this.bomby = bomby;
        }

        public void setConsoleOperation(ConsoleOperation consoleOperation)
        {
            this.consoleOperation = consoleOperation;
        }

        public void timeTick()
        {
            while (true)
            {
                foreach(Bomba b in bomby)
                {
                    b.timeTickPassed();
                    
                }
              

                for(int i = bomby.Count - 1; i >=0; i--)
                {
                    bomby.ElementAt(i).timeTickPassed();
                    if(bomby.ElementAt(i).getTimeTick() <= 0)
                    {
                        consoleOperation.detonate(bomby.ElementAt(i));
                        
                    }
                }

                Thread.Sleep(1000);
            }
        }
    }
}
