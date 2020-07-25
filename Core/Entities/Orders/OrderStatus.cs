using System.Runtime.Serialization;

namespace Core.Entities.Orders
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Payment Received")]
        PaymentReceived,
        [EnumMember(Value = "Payment Failed")]
        PaymentFailed,
        [EnumMember(Value = "Shipped")]
        Shipped,
        [EnumMember(Value = "Complete")]
        Complete
    }
}