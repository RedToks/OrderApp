using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public static class OrderReader
{
    public static List<Order> LoadOrdersFromFile(string filePath, string logFilePath)
    {
        var orders = new List<Order>();

        try
        {
            using (var reader = new StreamReader(filePath))
            {
                string header = reader.ReadLine();
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Console.WriteLine($"Чтение строки: {line}");

                    var parts = line.Split(',');

                    if (parts.Length == 4 &&
                        double.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double weight) &&
                        DateTime.TryParse(parts[3], out DateTime deliveryTime))
                    {
                        var order = new Order
                        {
                            OrderId = parts[0],
                            Weight = weight,
                            District = parts[2],
                            DeliveryTime = deliveryTime
                        };
                        orders.Add(order);
                    }
                    else
                    {
                        Logger.LogError(logFilePath, $"Ошибка при парсинге строки: {line}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(logFilePath, $"Ошибка при чтении файла: {ex.Message}");
        }

        return orders;
    }
}
