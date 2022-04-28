using Maths.Hex;

namespace Fengj.Maps
{
    public class Cell
    {
        public readonly AxialCoordinate axialCoordinate;
        public readonly OffsetCoordinate offsetCoordinate;

        public Cell(AxialCoordinate axialCoordinate)
        {
            this.axialCoordinate = axialCoordinate;
            offsetCoordinate = axialCoordinate.ToOffset();
        }
    }
}