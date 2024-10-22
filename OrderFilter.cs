using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class OrderFilter
    {
        public static List<Order> FilterOrdersByDistrictAndTime(List<Order> orders, string district, DateTime firstDeliveryTime)
        {
            DateTime endTime = firstDeliveryTime.AddMinutes(30);
            return orders.Where(o => o.District == district && o.DeliveryTime >= firstDeliveryTime && o.DeliveryTime <= endTime).ToList();
        }
    }
}
