using DDDInPrcatice.Logic.Common;
using DDDInPrcatice.Logic.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDDInPrcatice.Logic.SnackMachines
{
    public class SnackMachine : AggregateRoot
    {
        public virtual Money MoneyInside { get; protected set; }
        public virtual decimal MoneyInTransaction { get; protected set; }
        protected virtual IList<Slot> Slots { get; set; }

        public SnackMachine()
        {
            MoneyInside = Money.None;
            MoneyInTransaction = 0;
            Slots = new List<Slot>
            {
                new Slot(this, 1),
                new Slot(this, 2),
                new Slot(this, 3)
            };
        }

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

            this.MoneyInside += addMoney;
            this.MoneyInTransaction += addMoney.Amount;
        }

        public virtual void ReturnMoney()
        {
            Money moneyToReturn = MoneyInside.Allocate(MoneyInTransaction);
            MoneyInside -= moneyToReturn;

            this.MoneyInTransaction = 0;
        }

        public virtual string CanBuySnack(int position)
        {
            SnackPile snackPile = GetSnacksPile(position);

            if (snackPile.Quantity == 0)
                return "The snack pile is empty";

            if (MoneyInTransaction < snackPile.Price)
                return "Not enough money";

            if (!MoneyInside.CanAllocate(MoneyInTransaction - snackPile.Price))
                return "Not enough change";

            return string.Empty;
        }

        public virtual void BuySnack(int slotPosition)
        {
            if (CanBuySnack(slotPosition) != string.Empty)
                throw new InvalidOperationException();

            Slot slot = GetSlot(slotPosition);
            slot.SnackPile = slot.SnackPile.SubstractOne();

            Money change = MoneyInside.Allocate(MoneyInTransaction - slot.SnackPile.Price);
            MoneyInside -= change;
            MoneyInTransaction = 0;
        }

        public virtual void LoadSnacks(int position, SnackPile snackPile)
        {
            Slot slot = GetSlot(position);
            slot.SnackPile = snackPile;
        }

        public virtual SnackPile GetSnacksPile(int slotPosition)
        {
            Slot slot = GetSlot(slotPosition);
            return slot.SnackPile;
        }

        public virtual Slot GetSlot(int slotPosition)
        {
            Slot slot = Slots.Single(x => x.Position == slotPosition);
            return slot;
        }

        public virtual void LoadMoney(Money money)
        {
            MoneyInside += money;
        }

        public virtual IReadOnlyList<SnackPile> GetAllSnackPiles()
        {
            return Slots.OrderBy(x => x.Position).Select(x => x.SnackPile).ToList();
        }
    }
}
