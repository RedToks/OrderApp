using OrderApp;
using System.Collections.Generic;
using System;
using System.IO;

public static class OrderWriter
{
    public static void WriteFilteredOrdersToFile(string filePath, IEnumerable<Order> filteredOrders, string logFilePath)
    {
        try
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("OrderId,Weight,District,DeliveryTime");
                foreach (var order in filteredOrders)
                {
                    writer.WriteLine(order.ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(logFilePath, $"Ошибка при записи в файл: {ex.Message}");
        }
    }
}
