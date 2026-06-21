interface IPaymentService
{
    public void Payment();
}

class PaypalPayment : IPaymentService
{
    public void Payment()
    {
        System.Console.WriteLine("paypal");
    }
}

class MomoPayment : IPaymentService
{
    public void Payment()
    {
        System.Console.WriteLine("momo");
    }
}

class StudentCyber
{
    public string Name { get; set; }

    public readonly IPaymentService _paymentService;

    //readonly gan gia tri 1 lan trong constructor, k dc gan lai
    public StudentCyber(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public void Pay()
    {
        Console.WriteLine($"{Name} - đã thanh toán");
        _paymentService.Payment();
    }
}
