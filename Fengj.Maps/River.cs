using Maths.Hex;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fengj.Maps
{
    public class River
    {
        public readonly AxialCoordinate axialCoordinate;
        public readonly OffsetCoordinate offsetCoordinate;

        public River(AxialCoordinate axialCoordinate)
        {
            this.axialCoordinate = axialCoordinate;
            offsetCoordinate = axialCoordinate.ToOffset();
        }
    }
}
