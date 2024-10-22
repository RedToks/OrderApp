using System;

public class Order
{
    public string OrderId { get; set; }
    public double Weight { get; set; }
    public string District { get; set; }
    public DateTime DeliveryTime { get; set; }

    public override string ToString()
    {
        return $"{OrderId}, {Weight}, {District}, {DeliveryTime:yyyy-MM-dd HH:mm:ss}";
    }
}
