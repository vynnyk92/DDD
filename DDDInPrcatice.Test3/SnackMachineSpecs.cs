using Xunit;
using FluentAssertions;
using DDDInPrcatice.Logic;
using System;

namespace DDDInPrcatice.Test3
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void Return_Money_In_Trans_empty()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Money.OneDollar);

            snackMachine.ReturnMoney();


            snackMachine.MoneyInTransaction.Amount.Should().Be(0m);

        }

        [Fact]
        public void Inserted_Money_goes_to_money_in_trans()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Money.OneDollar);
            snackMachine.InsertMoney(Money.OneCent);


            snackMachine.MoneyInTransaction.Amount.Should().Be(1.01m);
        }

        [Fact]
        public void Cannot_insert_more_than_one_coin_or_note_in_time()
        {
            var snackMachine = new SnackMachine();
            var twoCent = Money.OneCent + Money.OneCent;

            Action action = () => snackMachine.InsertMoney(twoCent);

            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Money_in_trans_goes_to_money_inside_afther_purchase()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Money.OneCent);
            snackMachine.InsertMoney(Money.OneCent);

            snackMachine.BuySnack();

            snackMachine.MoneyInTransaction.Should().Be(Money.None);
            snackMachine.MoneyInside.Amount.Should().Be(0.02m);

        }
    }
}