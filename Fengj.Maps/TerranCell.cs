using Maths.Hex;

namespace Fengj.Maps
{
    public class TerranCell
    {

        public readonly AxialCoordinate axialCoordinate;
        public readonly OffsetCoordinate offsetCoordinate;

        public readonly Terran terran;

        public ViewType viewType
        {
            get
            {
                return _viewType;
            }
            set
            {
                _viewType = value;
                Map.onViewTypeChanged?.Invoke(this);
            }
        }

        private ViewType _viewType;

        public TerranCell(AxialCoordinate axialCoordinate, Terran terran)
        {
            this.axialCoordinate = axialCoordinate;
            this.terran = terran;
            this.viewType = ViewType.Fog;

            offsetCoordinate = axialCoordinate.ToOffset();
        }
    }
}