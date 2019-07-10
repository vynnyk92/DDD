using Xunit;
using FluentAssertions;
using DDDInPrcatice.Logic;
using System;
using System.Linq;

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


            snackMachine.MoneyInTransaction.Should().Be(0m);

        }

        [Fact]
        public void Inserted_Money_goes_to_money_in_trans()
        {
            var snackMachine = new SnackMachine();
            snackMachine.InsertMoney(Money.OneDollar);
            snackMachine.InsertMoney(Money.OneCent);


            snackMachine.MoneyInTransaction.Should().Be(1.01m);
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

            snackMachine.BuySnack(1);

            snackMachine.MoneyInTransaction.Should().Be(0);
            snackMachine.MoneyInside.Amount.Should().Be(0.02m);

        }

        [Fact]
        public void BuySnack_trades_inserted_money_for_a_snack()
        {
            var snackMachine = new SnackMachine();
            snackMachine.LoadSnacks(1, new SnackPile(new Snack("Chips"), 10, 1m));
            snackMachine.InsertMoney(Money.OneDollar);
            snackMachine.InsertMoney(Money.OneDollar);

            snackMachine.BuySnack(1);

            snackMachine.MoneyInTransaction.Should().Be(0);
            snackMachine.MoneyInside.Amount.Should().Be(2.00m);
            snackMachine.GetSnacksPile(1).Quantity.Should().Be(9);
        }

        [Fact]
        public void CanNot_BuySnack_when_There_is_no_snacks()
        {
            var snackMachine = new SnackMachine();
            snackMachine.LoadSnacks(1, new SnackPile(new Snack("Chips"), 0, 1m));
            snackMachine.InsertMoney(Money.OneDollar);
            snackMachine.InsertMoney(Money.OneDollar);

            Action action = () => snackMachine.BuySnack(1);
            action.Should().Throw<ArgumentException>();


        }

        [Fact]
        public void CanNot_BuySnack_If_NotEnought_Money()
        {
            var snackMachine = new SnackMachine();
            snackMachine.LoadSnacks(1, new SnackPile(new Snack("Chips"), 1, 2m));
            snackMachine.InsertMoney(Money.OneDollar);

            Action action = () => snackMachine.BuySnack(1);
            action.Should().Throw<InvalidOperationException>();


        }

        [Fact]
        public void MAchine_should_return_money_with_highest_nomination_First()
        {
            var snackMachine = new SnackMachine();

            snackMachine.LoadMoney(Money.OneDollar);
            snackMachine.InsertMoney(Money.QuaterCent);
            snackMachine.InsertMoney(Money.QuaterCent);
            snackMachine.InsertMoney(Money.QuaterCent);
            snackMachine.InsertMoney(Money.QuaterCent);

            snackMachine.ReturnMoney();

            snackMachine.MoneyInside.QuaterCentCount.Should().Be(4);
            snackMachine.MoneyInside.OneDollarCount.Should().Be(0);

        }
    }
}