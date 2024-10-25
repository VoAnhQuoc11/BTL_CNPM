
using System;
using System.Collections.Generic;

namespace KoiManagement
{
    public class WaterParameter
    {
        public DateTime MeasurementDate { get; set; }
        public double Temperature { get; set; }
        public double Salinity { get; set; }
        public double PH { get; set; }
        public double O2 { get; set; }
        public double NO2 { get; set; }
        public double NO3 { get; set; }
        public double PO4 { get; set; }
        public string PondId { get; set; }

        // Constructor
        public WaterParameter(DateTime measurementDate, double temperature, double salinity, double ph, double o2, double no2, double no3, double po4, string pondId)
        {
            MeasurementDate = measurementDate;
            Temperature = temperature;
            Salinity = salinity;
            PH = ph;
            O2 = o2;
            NO2 = no2;
            NO3 = no3;
            PO4 = po4;
            PondId = pondId;
        }

        // Method to check if water quality is good
        public bool IsWaterQualityGood()
        {
            return Temperature >= 20 && Temperature <= 28 &&
                   Salinity >= 0.1 && Salinity <= 0.5 &&
                   PH >= 6.5 && PH <= 8.5 &&
                   O2 >= 5 &&
                   NO2 < 0.3 &&
                   NO3 < 50 &&
                   PO4 < 2;
        }
    }

    public class Pond
    {
        public string Name { get; set; }
        public string PondId { get; set; }
        public List<WaterParameter> WaterParameters { get; set; }

        // Constructor
        public Pond(string name, string pondId)
        {
            Name = name;
            PondId = pondId;
            WaterParameters = new List<WaterParameter>();
        }

        // Method to add water parameters
        public void AddWaterParameter(WaterParameter parameter)
        {
            WaterParameters.Add(parameter);
        }

        // Method to display water parameters
        public void DisplayWaterParameters()
        {
            Console.WriteLine($"Water Parameters for Pond: {Name}");
            foreach (var parameter in WaterParameters)
            {
                Console.WriteLine($"Date: {parameter.MeasurementDate}, Temperature: {parameter.Temperature}C, Salinity: {parameter.Salinity}ppt, pH: {parameter.PH}, O2: {parameter.O2}mg/L, NO2: {parameter.NO2}mg/L, NO3: {parameter.NO3}mg/L, PO4: {parameter.PO4}mg/L");
                Console.WriteLine($"Water Quality Good: {parameter.IsWaterQualityGood()}");
            }
        }
    }

    class Waterparameters
    {
        static void Main(string[] args)
        {
            // Create a new pond
            Pond pond = new Pond("Koi Pond 1", "P001");

            // Add water parameters
            pond.AddWaterParameter(new WaterParameter(DateTime.Now, 25, 0.3, 7.5, 6, 0.1, 20, 1, "P001"));
            pond.AddWaterParameter(new WaterParameter(DateTime.Now.AddDays(-1), 27, 0.4, 7.2, 5.5, 0.2, 30, 1.5, "P001"));

            // Display water parameters
            pond.DisplayWaterParameters();
        }
    }
}