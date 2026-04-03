using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ET_DimDates
    {
        public long ID { get; set; }
        public DateTime Date { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int DayOfMonth { get; set; }
        public int DayOfWeek { get; set; }
        public string DayName { get; set; }
        public bool IsHoliday { get; set; }
        public ET_DimDates() { }
        public ET_DimDates(long iD, DateTime date, int year, int quarter, int month, string monthName, int dayOfMonth, int dayOfWeek, string dayName, bool isHoliday)
        {
            ID = iD;
            Date = date;
            Year = year;
            Quarter = quarter;
            Month = month;
            MonthName = monthName;
            DayOfMonth = dayOfMonth;
            DayOfWeek = dayOfWeek;
            DayName = dayName;
            IsHoliday = isHoliday;
        }
    }
}
