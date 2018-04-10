using System;

namespace SimulatorManager
{
    internal class ComparablePoint : IComparable<ComparablePoint>
    {
        internal int Points { get; set; }
        internal int Difference { get; set; }
        internal int Scored { get; set; }


        public int CompareTo(ComparablePoint obj)
        {

            var result = Points.CompareTo(obj.Points);

            if (result==0)
            {
                result = Difference.CompareTo(obj.Difference);
                if (result == 0)
                {
                    result = Scored.CompareTo(obj.Scored);
                }
            }

            return result;
        }
    }
}
