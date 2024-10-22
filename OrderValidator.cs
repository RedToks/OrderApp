using OrderApp;

public static class OrderValidator
{
    public static bool ValidateOrder(Order order, string logFilePath)
    {
        if (order == null)
        {
            Logger.LogError(logFilePath, "Попытка валидации пустого заказа.");
            return false;
        }

        if (string.IsNullOrEmpty(order.OrderId))
        {
            Logger.LogError(logFilePath, "Не задан номер заказа.");
            return false;
        }

        if (order.Weight <= 0)
        {
            Logger.LogError(logFilePath, $"Некорректный вес заказа: {order.Weight}");
            return false;
        }

        return true;
    }
}
