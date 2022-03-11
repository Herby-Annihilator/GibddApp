using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.Common
{
    public class AllowedCategory
    {
        public Category Category { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public AllowedCategory(Category category, DateTime startDate, DateTime endDate)
        {
            Category = category;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
