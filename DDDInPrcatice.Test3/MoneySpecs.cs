using Xunit;
using FluentAssertions;
using DDDInPrcatice.Logic;
using System;

namespace DDDInPrcatice.Test3
{
    public class MoneySpecs
    {
        [Fact]
        public void Sum_OF_Two_IsCorrect()
        {
            Money money1 = new Money(1, 1, 1, 1, 1, 1);
            Money money2 = new Money(1, 1, 1, 1, 1, 1);
            Money sumExp = new Money(2, 2, 2, 2, 2, 2);

            Money sumRes = money1 + money2;


            sumRes.OneCentCount.Should().Be(2);
            sumRes.TenCentCount.Should().Be(2);
            sumRes.QuaterCentCount.Should().Be(2);
            sumRes.OneDollarCount.Should().Be(2);
            sumRes.FiveDollarCount.Should().Be(2);
            sumRes.TwentyDollarCount.Should().Be(2);

        }

        [Fact]
        public void Two_money_Equals_IfTHeir_Cont_Equals()
        {
            Money money1 = new Money(1, 1, 1, 1, 1, 1);
            Money money2 = new Money(1, 1, 1, 1, 1, 1);

            money1.Should().Be(money2);

            money1.GetHashCode().Should().Be(money2.GetHashCode());

        }

        [Theory]
        [InlineData(-1, 0, 0, 0, 0, 0)]
        [InlineData(1, -1, 0, 0, 0, 0)]
        [InlineData(1, 0, -1, 0, 0, 0)]
        [InlineData(1, 0, 0, -1, 0, 0)]
        [InlineData(1, 0, 0, 0, -1, 0)]
        [InlineData(1, 0, 0, 0, 0, -1)]
        public void Can_not_Ccreate_Money_with_nefat_wal(
        int _OneCentCount,
        int _TenCentCount,
        int _QuaterCentCount,
        int _OneDollarCount,
        int _FiveDollarCount,
        int _TwentyDollarCount
            )
        {
            Action action = () => new Money(
                _OneCentCount,
                _TenCentCount,
               _QuaterCentCount,
               _OneDollarCount,
               _FiveDollarCount,
                _TwentyDollarCount);

            action.Should().Throw<InvalidOperationException>();
        }


        [Theory]
        [InlineData(0, 0, 0, 0, 0, 0, 0)]
        [InlineData(1, 1, 1, 1, 1, 1, 26.36)]
        [InlineData(10, 10, 10, 1, 1, 1, 29.6)]
        public void Amount_Is_CalculatedCorrectly(
        int _OneCentCount,
        int _TenCentCount,
        int _QuaterCentCount,
        int _OneDollarCount,
        int _FiveDollarCount,
        int _TwentyDollarCount,
        decimal expectedAmount)
        {

            Money money = new Money(
                _OneCentCount,
                _TenCentCount,
               _QuaterCentCount,
               _OneDollarCount,
               _FiveDollarCount,
                _TwentyDollarCount);

            money.Amount.Should().Be(expectedAmount);
        }

        [Fact]
        public void Cant_substract_more_then_exist()
        {
            Money money1 = new Money(1, 1, 1, 1, 1, 1);
            Money money2 = new Money(1, 2, 2, 2, 2, 2);
            Action action = () =>
            {
                Money money = money1 - money2;
            };
            action.Should().Throw<InvalidOperationException>();

        }


    }
}