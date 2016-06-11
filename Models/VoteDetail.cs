using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndianCitizenService.Models
{
    public class RenderMapDetail
    {
        public int ColorIndex { get; set; }

        public double LocLalitudeStart { get; set; }

        public double LocLalitudeEnd { get; set; }

        public double LocLongitudeStart { get; set; }

        public double LocLongitudeEnd { get; set; }
    }

    public class VoteDetail
    {
        public long UserId { get; set; }

        public long Id { get; set; }

        public int GradeValue { get; set; }

        public LocationDetail LocationDetail { get; set; }
    }

    public class LocationDetail
    {
        public long Id { get; set; }

        public double LocLalitudeStart { get; set; }

        public double LocLalitudeEnd { get; set; }

        public double LocLongitudeStart { get; set; }

        public double LocLongitudeEnd { get; set; }

    }
}