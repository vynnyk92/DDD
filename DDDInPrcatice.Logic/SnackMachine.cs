using System;

namespace DDDInPrcatice.Logic
{
    public sealed class SnackMachine:BaseEntity
    {
        public Money MoneyInside {get; private set;}
        public Money MoneyInTransaction { get; private set; }


        public void InsertMoney(Money addMoney)
        {
            this.MoneyInTransaction += addMoney;
        }

        public void ReturnMoney()
        {
            //MoneyInTransaction = 0;
        }

        public void BuySnack()
        {
            this.MoneyInside += this.MoneyInTransaction;

            //MoneyInTransaction = 0;

        }

    }
}
