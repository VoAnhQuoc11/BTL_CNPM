using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_tập_C_
{
    internal class Dashboard
    {
        // Properties
        public int DashboardID { get; set; }
        public string DashboardName { get; set; }
        public string Description { get; set; }

        // Constructor
        public Dashboard(int id, string name, string description)
        {
            DashboardID = id;
            DashboardName = name;
            Description = description;
        }

        // Methods
        public string GenerateKoiOverview()
        {
            // Logic to generate Koi overview report
            return "Koi Overview Report";
        }

        public string GenerateWaterQualityOverview()
        {
            // Logic to generate Water Quality Overview
            return "Water Quality Overview";
        }

        public string GenerateOrderSummary()
        {
            // Logic to generate Order Summary
            return "Order Summary";
        }
    }
}

