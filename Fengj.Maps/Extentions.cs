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
                if (n.r % 2 != 0)
                {
                    return null;
                }

                if (n.q % 2 != 0)
                {
                    return null;
                }

                var bankCoord = new AxialCoordinate(n.q / 2, n.r / 2);
                return bankCoord.IsInMap(mapSize) ? bankCoord : null;
            }).Where(r=>r!=null).ToArray();
        }
    }
}
