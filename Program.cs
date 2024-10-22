using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string orderFilePath = Path.Combine(basePath, "Data", "orders.csv");
        string logFilePath = Path.Combine(basePath, "Data", "log.txt");
        string resultFilePath = Path.Combine(basePath, "Data", "filtered_orders.csv");

        string cityDistrict = "Moskva";
        DateTime firstDeliveryDateTime = new DateTime(2024, 10, 21, 10, 0, 0);

        var orders = OrderReader.LoadOrdersFromFile(orderFilePath, logFilePath);

        if (!orders.Any())
        {
            Console.WriteLine("Нет заказов для обработки.");
            return;
        }

        var filteredOrders = orders
            .Where(o => o.District == cityDistrict && o.DeliveryTime >= firstDeliveryDateTime && o.DeliveryTime <= firstDeliveryDateTime.AddMinutes(30))
            .ToList();

        OrderWriter.WriteFilteredOrdersToFile(resultFilePath, filteredOrders, logFilePath);

        Console.WriteLine($"Обработано {filteredOrders.Count} заказов. Результаты записаны в файл: {resultFilePath}");
    }
}
