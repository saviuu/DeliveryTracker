namespace DeliveryTracker.Domain.Enums
{
    public enum DeliveryStatus
    {
        Pending = 1,               // No courier assigned yet
        Assigned = 2,              // A courier has accepted the delivery
        OnTheWayToPickup = 3,      // Courier is heading to the restaurant
        OnTheWayToCustomer = 4,    // Courier is heading to the customer
        Completed = 5,             // Delivery completed successfully
        Failed = 6                 // Delivery failed (unable to deliver)
    }
}
