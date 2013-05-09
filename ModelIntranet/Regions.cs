using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Powergrid.Intranet.Model
{
    public enum Regions
    {
        CC = 1,
        NR1 = 2,
        SR1 = 3,
        POSCC = 4,
        SR2 = 5,
        NER = 6,
        WR1 = 7,
        WR2 = 8,
        ER1 = 9,
        ER2 = 10,
        NR2 = 11,
        NRLDC = 12,
        NERLDC = 13,
        WRLDC = 14,
        ERLDC = 15,
        SRLDC = 16,
        INVALID = -1
    }

    public class Locations
    {
        public int LocationId { get; set; }
        public string LocationNameEn { get; set; }
        public string LocationNameHi { get; set; }
    }

    public class Region
    {
        public int RegionId { get; set; }
        public string RegionNameEn { get; set; }
        public string RegionNameHi { get; set; }
        public List<Locations> Locations { get; set; } 
    }
}
