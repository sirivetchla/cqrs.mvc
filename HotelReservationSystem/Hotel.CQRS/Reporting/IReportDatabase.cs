using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.CQRS.Reporting
{
   public interface IReportDatabase
    {
        HotelDto GetById(Guid id);
        void Add(HotelDto item);
        void Delete(Guid id);
        List<HotelDto> GetItems();
    }
}
