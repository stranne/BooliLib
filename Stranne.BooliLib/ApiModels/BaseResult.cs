using System;

namespace Stranne.BooliLib.ApiModels
{
    public abstract class BaseResult
    {
        public int BooliId { get; set; }

        public double ListPrice { get; set; }

        public DateTimeOffset Published { get; set; }

        public LocationResult Location { get; set; }

        public string ObjectType { get; set; }

        public Source Source { get; set; }

        public float Rooms { get; set; }

        public float LivingArea { get; set; }

        public float Rent { get; set; }

        public float Floor { get; set; }

        public int? PlotArea { get; set; } // TODO test (check also on sold) (double check type)

        public int? ConstructionYear { get; set; }

        public bool? IsNewConstruction { get; set; } // TODO test (check also on sold)

        public string Url { get; set; }
    }
}