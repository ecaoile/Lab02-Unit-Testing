using System;
using Xunit;
using Lab02_Unit_Testing;
using static Lab02_Unit_Testing.Program;

namespace Lab02_XUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void CanViewBalance()
        {
            decimal tempBalance = 555.55m;
            Assert.Equal(555.55m, ViewBalance(tempBalance));
        }

        [Theory]
        [InlineData(555.55, 44.45, 600)]
        [InlineData(500, 55.55, 555.55)]
        [InlineData(500, 0, 500)]
        [InlineData(500, -1000, 500)]
        public void DepositTest(decimal myBalance, decimal myDeposit, decimal expectedResult)
        {
            Assert.Equal(expectedResult, Deposit(myBalance, myDeposit));
        }
        
        [Theory]
        [InlineData(555.55, 55.55, 500)]
        [InlineData(100, 200, 100)]
        [InlineData(500, 0, 500)]
        [InlineData(200, -1000, 200)]
        public void WithdrawTest(decimal myBalance, decimal myWithdraw, decimal expectedResult)
        {
            Assert.Equal(expectedResult, Withdraw(myBalance, myWithdraw));
        }
    }
}
