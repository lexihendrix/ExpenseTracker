using Testing;
using ExpenseTracker.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;

namespace Testing
{
    [TestClass]
    public class BankAccountTests
    {
        //om man kör deposit så ska vi få OK plus att balance ska öka med beloppet
        private BankAccount sut; //System under test

        public BankAccountTests() 
        { 
            sut = new BankAccount();
        }

        //withdrawal mer än 3000 ska ge felkod
        [TestMethod]
        public void WhenWithdrawalMoreThan3000ShouldGiveErrorCode()
        {
            //Arrange
            int amount = 3001;
            
            //Act
            var result = sut.Withdrawal(amount);
            
            //Assert
            Assert.AreEqual(BankAccountStatus.AmountTooBig, result);
        }

        [TestMethod]
        public void WhenDepositBalanceShouldBeIncreased()
        {
            //Arrange
            sut.Balance = 500;

            //Act 
            var result = sut.Deposit(100);

            //Assert
            Assert.AreEqual(BankAccountStatus.Ok, result);
            Assert.AreEqual(600, sut.Balance);
        }

    }
}
