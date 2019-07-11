using Xunit;
using FluentAssertions;
using DDDInPrcatice.Logic;
using System;

namespace DDDInPrcatice.Test3
{
    public class SnackPileSpecs
    {
        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        public void Can_NotCreate_SnackPile_With_WrongQuantityAndPrice(
        int quantity,
        decimal price
        )
        {
            Action action = () => new SnackPile(
               Snack.Chocolate,
               quantity,
                price);

            action.Should().Throw<ArgumentException>();
        }

    }
}