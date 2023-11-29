using Moq;
using NUnit.Framework;
using System;
using UnitTestSummary;

namespace PaymentTest
{
    [TestFixture]
    public class PaymentProcessorTests
    {
        [Test]
        public void ShouldReturnTrue()
        {
            // Mock: objektumok, funkciók helyettesítésére szolgáló eszköz
            // 3 "A":
            // Arrange - előkészítés -> teszteset inicializálása (pl. SetUp metódus)
            var paymentGatewayMock = new Mock<IPaymentGateway>();
            paymentGatewayMock.Setup(gateway => gateway.Charge(It.IsAny<double>())).Returns(true);
            // tesztelendő kód ezt a bemenetet kapja -> mivel Returns(true) lett beállítva, a Charge() metódus mindig igazzal tér vissza
            var paymentProcessor = new PaymentProcessor(paymentGatewayMock.Object);
            // Mock Object: vele szimuláljuk a valós objektum viselkedését

            // Act - tényleges művelet, amit tesztelni szeretnénk
            bool result = paymentProcessor.ProcessPayment(130);

            // Assert - ellenőrzés -> kimenet a várt eredményt adja-e
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldHandleExceptionAndReturnFalse()
        {
            // Arrange
            var paymentGatewayMock = new Mock<IPaymentGateway>();
            paymentGatewayMock.Setup(gateway => gateway.Charge(It.IsAny<double>())).Throws(new PaymentFailedException("Payment failed"));
            // mivel itt Throws(new PaymentFailedException(...)) lett beállítva, a Charge() mindig hamissal tér vissza
            var paymentProcessor = new PaymentProcessor(paymentGatewayMock.Object);

            // Act
            bool result = paymentProcessor.ProcessPayment(250);

            // Assert
            //Assert.IsTrue(result); // erre elhasalna
            Assert.IsFalse(result);
        }
    }
}
