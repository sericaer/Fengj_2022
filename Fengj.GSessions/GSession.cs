using Fengj.Maps;
using System;
using Maths.Hex;

namespace Fengj.GSessions
{
    public class GSession
    {
        public Map map { get; set; }

        public GSession()
        {
            map = new Map();
            map.cells.AddRange( new Cell[] { 
                new Cell(new AxialCoordinate(0, 0)),
                new Cell(new AxialCoordinate(0, -1)),
                new Cell(new AxialCoordinate(1, -1)),
                new Cell(new AxialCoordinate(1, 0)),
                new Cell(new AxialCoordinate(0, 1)),
                new Cell(new AxialCoordinate(-1, 1)),
                new Cell(new AxialCoordinate(-1, 0)),
            });
        }
    }
}
