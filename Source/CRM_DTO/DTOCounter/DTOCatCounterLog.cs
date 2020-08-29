using CRM_DTO.DTOCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_DTO.DTOCounter
{
    public class DTOCatCounterLog
    {
        public DTOCatCounter Counter { get; set; }
        public DTOCatEmployee Employee { get; set; }
        public DateTime CounterDateTime { get; set; }
        public string StatusCode { get; set; }

        public DTOCatCounterLog()
        {
            this.Counter = new DTOCatCounter();
            this.Employee = new DTOCatEmployee();
            this.CounterDateTime = DateTime.Now;
            this.StatusCode = string.Empty;
        }

        public DTOCatCounterLog(DTOCatCounter _Counter, DTOCatEmployee _Employee, DateTime _CounterDateTime, string _StatusCode)
        {
            this.Counter = _Counter;
            this.Employee = _Employee;
            this.CounterDateTime = _CounterDateTime;
            this.StatusCode = _StatusCode;
        }

        public DTOCatCounterLog(DTOCatCounterLog _CatCounterLog)
        {
            this.Counter = _CatCounterLog.Counter;
            this.Employee = _CatCounterLog.Employee;
            this.CounterDateTime = _CatCounterLog.CounterDateTime;
            this.StatusCode = _CatCounterLog.StatusCode;
        }
    }
}
