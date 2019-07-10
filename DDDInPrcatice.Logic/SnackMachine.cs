using System;

namespace DDDInPrcatice.Logic
{
    public class SnackMachine:BaseEntity
    {
        public virtual Money MoneyInside { get; protected set; } = Money.None;
        public virtual Money MoneyInTransaction { get; protected set; } = Money.None;

        public virtual void InsertMoney(Money addMoney)
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

        public virtual void ReturnMoney()
        {
            this.MoneyInTransaction = Money.None;
        }

        public virtual void BuySnack()
        {
            this.MoneyInside += this.MoneyInTransaction;
            MoneyInTransaction = Money.None;
        }

    }
}
