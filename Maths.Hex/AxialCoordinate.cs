using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maths.Hex
{
    public class AxialCoordinate
    {
        public readonly int q;
        public readonly int r;

        public AxialCoordinate(int q, int r)
        {
            this.q = q;
            this.r = r;
        }

        static public List<AxialCoordinate> directions = new List<AxialCoordinate> { 
            new AxialCoordinate(1, 0), 
            new AxialCoordinate(1, -1), 
            new AxialCoordinate(0, -1), 
            new AxialCoordinate(-1, 0), 
            new AxialCoordinate(-1, 1), 
            new AxialCoordinate(0, 1) };

        static public AxialCoordinate Direction(int direction)
        {
            return AxialCoordinate.directions[direction];
        }

        public AxialCoordinate GetNeighbor(int direction)
        {
            return Add(AxialCoordinate.Direction(direction));
        }

        public AxialCoordinate Add(AxialCoordinate b)
        {
            return new AxialCoordinate(q + b.q, r + b.r);
        }

        public AxialCoordinate Sub(AxialCoordinate b)
        {
            return new AxialCoordinate(q - b.q, r - b.r);
        }


        public IEnumerable<AxialCoordinate> GetRing(int distance)
        {
            var rslt = new List<AxialCoordinate>();

            if (distance == 0)
            {
                rslt.Add(this);

                return rslt;
            }

            var curr = this;
            for (int i = 0; i < distance; i++)
            {
                curr = curr.GetNeighbor(4);
            }

            for (int i = 0; i < 6; i++)
            {
                for (int d = 0; d < distance; d++)
                {
                    rslt.Add(curr);
                    curr = curr.GetNeighbor(i);
                }
            }

            return rslt;
        }

        public IEnumerable<AxialCoordinate> GetSector(int size)
        {
            var range = Enumerable.Range(0, size+1);
            return range.Select(x => GetRing(x)).SelectMany(y => y);
        }
    }
}
