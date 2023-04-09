namespace CarShop.Tests
{
    public class CarShopTests
    {
        [Fact]
        public void ShouldAddCarToInventoryWhenPurchased()
        {
            // Arrange
            var inventory = new CarInventory();
            var shop = new CarShop(new CreditCardPayment(), inventory);
            var car = new Car("Model 1", "Red", 10000);

            // Act
            shop.PurchaseCar(car);

            // Assert
            Assert.Contains(car, inventory.Cars);
        }

        [Fact]
        public void ShouldNotifyObserversWhenCarIsPurchased()
        {
            // Arrange
            var inventory = new CarInventory();
            var shop = new CarShop(new CreditCardPayment(), inventory);
            var observer = new Mock<ICarObserver>();
            shop.Subscribe(observer.Object);
            var car = new Car("Model 1", "Red", 10000);

            // Act
            shop.PurchaseCar(car);

            // Assert
            observer.Verify(o => o.Update(car), Times.Once);
        }

        [Fact]
        public void ShouldSetCreditCardPaymentMethodByDefault()
        {
            // Arrange
            var inventory = new CarInventory();
            var shop = new CarShop(inventory);

            // Assert
            Assert.IsType<CreditCardPayment>(shop.PaymentMethod);
        }

        [Fact]
        public void ShouldSetPaymentMethod()
        {
            // Arrange
            var inventory = new CarInventory();
            var shop = new CarShop(inventory);
            var paymentMethod = new PayPalPayment();

            // Act
            shop.SetPaymentMethod(paymentMethod);

            // Assert
            Assert.Equal(paymentMethod, shop.PaymentMethod);
        }

        [Fact]
        public void ShouldExecuteUndoCommand()
        {
            // Arrange
            var inventory = new CarInventory();
            var shop = new CarShop(new CreditCardPayment(), inventory);
            var car = new Car("Model 1", "Red", 10000);
            var command = new PurchaseCarCommand(shop, car);

            // Act
            command.Execute();
            command.Undo();

            // Assert
            Assert.DoesNotContain(car, inventory.Cars);
        }
    }
}