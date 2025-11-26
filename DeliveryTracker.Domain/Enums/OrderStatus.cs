namespace DeliveryTracker.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 1,            // Order created, waiting for restaurant confirmation
        Accepted = 2,           // Restaurant accepted the order
        InPreparation = 3,      // Restaurant is preparing the order
        ReadyForPickup = 4,     // Order is ready for courier pickup
        OutForDelivery = 5,     // Courier is delivering the order
        Delivered = 6,          // Order delivered to the customer
        Canceled = 7            // Order canceled by customer or restaurant
    }
}
