using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class Bomba
    {
        Point position;
        string body;
        int timeTicks;

        public Bomba(int x, int y)
        {
            position = new Point(x, y);
            body = "B";
            timeTicks = 3;
        }

        public Bomba(int x, int y, int time)
        {
            position = new Point(x, y);
            body = "B";
            timeTicks = time;
        }

        public Point getPosition()
        {
            return position;
        }

        public string getBody()
        {
            return body;
        }

        public void timeTickPassed()
        {
            timeTicks -= 1;
        }

        public int getTimeTick()
        {
            return timeTicks;
        }
    }
}
