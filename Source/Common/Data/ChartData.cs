using System;
using IMAS.Common.DataProvider;

namespace IMAS.Common.Data
{
    public class ChartData : IChartData
    {
        public DateTime Date { get; set; }

        public int Value { get; set; }
    }
}
