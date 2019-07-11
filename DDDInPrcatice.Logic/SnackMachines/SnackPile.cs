using DDDInPrcatice.Logic.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPrcatice.Logic.SnackMachines
{
    public sealed class SnackPile : ValueObject<SnackPile>
    {
        public Snack Snack { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        private SnackPile()
        {

        }

        public SnackPile(Snack snack, int quantity, decimal price)
            : this()
        {
            if (quantity < 0 || price < 0)
                throw new ArgumentException();

            if (price % 0.01m > 0)
                throw new ArgumentException();

            this.Snack = snack;
            this.Quantity = quantity;
            this.Price = price;
        }

        public SnackPile SubstractOne()
        {
            return new SnackPile(this.Snack, this.Quantity-1, this.Price);
        }



        protected override bool EqualsCore(SnackPile other)
        {
            return Snack == other.Snack
                && Quantity == other.Quantity
                && Price == other.Price;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Snack.GetHashCode();
                hashCode = (hashCode * 397) ^ Quantity;
                hashCode = (hashCode * 397) ^ Price.GetHashCode();
                return hashCode;
            }
        }
    }
}
