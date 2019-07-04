using DDDInPrcatice.Logic;
using System;
using Xunit;
using FluentAssertions;

namespace DDDInPrcatice.Test
{
    public class MoneySpec
    {
        [Fact]
        public void SumOfTwoMoneyProducesCorrectResult()
        {
            Money money1 = new Money(1,1,1,1,1,1);
            Money money2 = new Money(1, 1, 1, 1, 1, 1);
            Money sumExp = new Money(2, 2, 2, 2, 2, 2);

            Money sumRes = money1 + money2;


            Assert.True(sumRes.Equals(sumExp));
        }
    }
}
