namespace CSharpProgrWFGraphs
{
    public class PointInt
    {
        public int from;
        public int to;
        public int distance;
        public bool underlined;
        public PointInt(int _x, int _y)
        {
            from = _x;
            to = _y;
            distance = 0;
            underlined = false;
        }
        public PointInt(int _from, int _to, int _distance)
        {
            from = _from;
            to = _to;
            distance = _distance;
            underlined = false;
        }
        public PointInt(int _from, int _to, int _distance, bool _underlined)
        {
            from = _from;
            to = _to;
            distance = _distance;
            underlined = _underlined;
        }

        public static PointInt operator +(PointInt a, PointInt b) => new PointInt(a.from + b.from, a.to + b.to);
    }
}
