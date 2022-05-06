using Maths.Hex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fengj.Maps
{
    internal static class Extentions
    {
        internal static bool IsInMap(this AxialCoordinate coordnate, int mapSize)
        {
            return Math.Abs(coordnate.q) < mapSize && Math.Abs(coordnate.r) < mapSize && Math.Abs(coordnate.s) < mapSize;
        }

        internal static AxialCoordinate[] GetRiverBank(this AxialCoordinate coordnate, int mapSize)
        {
            return coordnate.GetNeighbors().Select(n =>
            {
                var bankCoord = coordnate.RiverCoordToTerranCoord();
                if (bankCoord == null)
                {
                    return null;
                }
                return bankCoord.IsInMap(mapSize) ? bankCoord : null;
            }).Where(r=>r!=null).ToArray();
        }

        internal static AxialCoordinate RiverCoordToTerranCoord(this AxialCoordinate coordnate)
        {
            if (coordnate.r % 2 != 0)
            {
                return null;
            }

            if (coordnate.q % 2 != 0)
            {
                return null;
            }

            return new AxialCoordinate(coordnate.q/2, coordnate.r/2);
        }
    }
}
