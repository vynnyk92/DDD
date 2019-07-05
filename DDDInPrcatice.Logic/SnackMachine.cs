using System;

namespace DDDInPrcatice.Logic
{
    public sealed class SnackMachine:BaseEntity
    {
        public Money MoneyInside { get; private set; } = Money.None;
        public Money MoneyInTransaction { get; private set; } = Money.None;



        public void InsertMoney(Money addMoney)
        {
            if (!
                (addMoney.Equals(Money.OneCent)
                || addMoney.Equals(Money.TenCent)
                || addMoney.Equals(Money.QuaterCent)
                || addMoney.Equals(Money.OneDollar)
                || addMoney.Equals(Money.FiveDollar)
                || addMoney.Equals(Money.TwentyDollar)))
                throw new InvalidOperationException();

                this.MoneyInTransaction += addMoney;
        }

        public void ReturnMoney()
        {
            this.MoneyInTransaction = Money.None;
        }

        public void BuySnack()
        {
            this.MoneyInside += this.MoneyInTransaction;
            MoneyInTransaction = Money.None;
        }

    }
}
