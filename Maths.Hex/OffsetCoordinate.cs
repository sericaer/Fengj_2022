using System;
using System.Collections.Generic;
using System.Text;

namespace Maths.Hex
{
    public class OffsetCoordinate
    {
        public readonly int col;
        public readonly int row;

        public OffsetCoordinate(int col, int row)
        {
            this.col = col;
            this.row = row;
        }
    }
}
