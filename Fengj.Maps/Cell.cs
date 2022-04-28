using Maths.Hex;

namespace Fengj.Maps
{
    public partial class Cell
    {

        public readonly AxialCoordinate axialCoordinate;
        public readonly OffsetCoordinate offsetCoordinate;

        LandForm landForm;

        public Cell(AxialCoordinate axialCoordinate, LandForm landForm)
        {
            this.axialCoordinate = axialCoordinate;
            this.landForm = landForm;

            offsetCoordinate = axialCoordinate.ToOffset();

        }
    }
}