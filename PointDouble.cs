namespace CSharpProgrWFGraphs
{
    public class PointDouble
    {
        public double x;
        public double y;
        public PointDouble(double _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public static PointDouble operator +(PointDouble a, PointDouble b) => new PointDouble(a.x + b.x, a.y + b.y);
    }
}
