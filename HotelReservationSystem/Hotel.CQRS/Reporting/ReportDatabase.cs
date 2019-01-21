using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.CQRS.Reporting
{
    public class ReportDatabase : IReportDatabase
    {
        static List<HotelDto> items = new List<HotelDto>();

        public HotelDto GetById(Guid id)
        {
            return items.Where(a => a.Id == id).FirstOrDefault();
        }

        public void Add(HotelDto item)
        {
            items.Add(item);
        }

        public void Delete(Guid id)
        {
            items.RemoveAll(i => i.Id == id);
        }

        public List<HotelDto> GetItems()
        {
            return items;
        }
    }
}
