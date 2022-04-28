using System;
using System.Collections.Generic;
using System.Text;

namespace Maths.Hex
{
    public static class Extentions
    {
        
        const int offset = 1; //ODD_Q -1, EVEN_Q 1

        public static OffsetCoordinate ToOffset(this AxialCoordinate axialCoordinate)
        {
            int col = axialCoordinate.q;
            int row = axialCoordinate.r + (int)((axialCoordinate.q + offset * (axialCoordinate.q & 1)) / 2);

            return new OffsetCoordinate(col, row);
        }
    }
}
