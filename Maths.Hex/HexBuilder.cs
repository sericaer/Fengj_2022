using System;
using System.Collections.Generic;
using System.Text;

namespace Maths.Hex
{
    public static class HexBuilder
    {
        public static IEnumerable<AxialCoordinate> Build(int size)
        {
            return new AxialCoordinate(0, 0).GetSector(size);
        }
    }
}
