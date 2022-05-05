using Maths.Hex;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fengj.Maps
{
    internal class RiverBuilder
    {
        internal static AxialCoordinate[] Build(int mapSize)
        {
            var riverMapSize = mapSize * 2 + 1;

            var currCoord = new AxialCoordinate(0, 0).GetSector(Math.Min(riverMapSize / 5, 3)).OrderBy(_ => GRandom.Get()).First();

            var riverInDirect1 = BuildDirect(currCoord, riverMapSize, new int[] { 0, 1, 2, 5 });
            var riverInDirect2 = BuildDirect(currCoord, riverMapSize, new int[] { 0, 3, 4, 5 });

            return riverInDirect1.Concat(riverInDirect2).ToArray();
        }

        private static HashSet<AxialCoordinate> BuildDirect(AxialCoordinate currCoord, int riverMapSize, int[] direct)
        {
            var riverHashSet = new HashSet<AxialCoordinate>();

            riverHashSet.Add(currCoord);

            while (true)
            {
                var vaildNexts = direct.Select(d => currCoord.GetNeighbor(d)).ToArray();
                currCoord = vaildNexts.Where(x => x.GetNeighbors().All(n => !(riverHashSet.Contains(n) && n != currCoord)))
                    .OrderBy(_ => GRandom.Get()).First();

                if (!currCoord.IsInMap(riverMapSize))
                {
                    break;
                }

                riverHashSet.Add(currCoord);
            }

            return riverHashSet;
        }
    }
}