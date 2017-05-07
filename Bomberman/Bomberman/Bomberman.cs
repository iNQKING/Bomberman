using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Bomberman
{
    class Bomberman
    {
        private List<Point> body;
        Point head;

        public Bomberman()
        {
            body = new List<Point>();

            for (int i = 0; i < 5; i++)
                body.Add(new Point(10, 30 + i));
        }

        public List<Point> Body
        {
            get { return this.body; }
        }

        public Point GetHead()
        {
            head = Body[0];
            return head;
        }

    }
}
