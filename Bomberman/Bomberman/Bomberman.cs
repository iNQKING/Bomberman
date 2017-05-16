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
        Point pozycja;

        public Bomberman()
        {
            body = new List<Point>();

            //for (int i = 0; i < 1; i++)
                body.Add(new Point(10, 10));
            pozycja = new Point(10, 10);
        }

        public List<Point> Body
        {
            get { return this.body; }
        }

        public void setPosition(Point point)
        {
            this.pozycja = point;
        }

        public Point GetPosition()
        {
            //pozycja = Body[0];
            return this.pozycja;
        }

    }
}
