using System;

namespace UnitTestSummary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MathOperations m = new MathOperations();
            Console.WriteLine(m.Add(5,8));
            Console.WriteLine(m.Subtract(12,9));
        }
    }

    public class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }

    public class PaymentProcessor
    {
        private readonly IPaymentGateway paymentGateway;

        public PaymentProcessor(IPaymentGateway paymentGateway)
        {
            this.paymentGateway = paymentGateway;
        }

        public bool ProcessPayment(double amount)
        {
            try
            {
                return paymentGateway.Charge(amount);
            }
            catch (PaymentFailedException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }

    public interface IPaymentGateway
    {
        bool Charge(double amount);
    }

    public class PaymentFailedException : Exception
    {
        public PaymentFailedException(string message) : base(message) { }
    }
}
