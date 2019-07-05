using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPrcatice.Logic
{
    public class Money : ValueObject<Money>
    {
        public static Money None         = new Money(0, 0, 0, 0, 0, 0);
        public static Money OneCent      = new Money(1, 0, 0, 0, 0, 0);
        public static Money TenCent      = new Money(0, 1, 0, 0, 0, 0);
        public static Money QuaterCent   = new Money(0, 0, 1, 0, 0, 0);
        public static Money OneDollar    = new Money(0, 0, 0, 1, 0, 0);
        public static Money FiveDollar   = new Money(0, 0, 0, 0, 1, 0);
        public static Money TwentyDollar = new Money(0, 0, 0, 0, 0, 1);



        public int OneCentCount     { get; private set; }
        public int TenCentCount     { get; private set; }
        public int QuaterCentCount  { get; private set; }
        public int OneDollarCount   { get; private set; }
        public int FiveDollarCount  { get; private set; }
        public int TwentyDollarCount { get; private set; }

        public Money(
        int _OneCentCount       ,
        int _TenCentCount       ,
        int _QuaterCentCount    ,
        int _OneDollarCount     ,
        int _FiveDollarCount      ,
        int _TwentyDollarCount) 
        {
            if (_OneCentCount < 0
               || _TenCentCount < 0
               || _QuaterCentCount < 0
               || _OneDollarCount < 0
               || _FiveDollarCount < 0
               || _TwentyDollarCount < 0)
                throw new InvalidOperationException();

            this.OneCentCount       =_OneCentCount      ;     
            this.TenCentCount       =_TenCentCount      ;
            this.QuaterCentCount    =_QuaterCentCount   ;
            this.OneDollarCount     =_OneDollarCount    ;
            this.FiveDollarCount    =_FiveDollarCount   ;
            this.TwentyDollarCount = _TwentyDollarCount;
        }


        public static Money operator +(Money money1, Money money2)
        {
            Money sum = new Money(
                money1.OneCentCount      +money2.OneCentCount      ,
                money1.TenCentCount      +money2.TenCentCount       ,
                money1.QuaterCentCount   +money2.QuaterCentCount    ,
                money1.OneDollarCount    +money2.OneDollarCount     ,
                money1.FiveDollarCount   +money2.FiveDollarCount    ,
                money1.TwentyDollarCount +money2.TwentyDollarCount  
                );

            return sum;
        }

        public static Money operator -(Money money1, Money money2)
        {
            return new Money(
                money1.OneCentCount     - money2.OneCentCount,
                money1.TenCentCount     - money2.TenCentCount,
                money1.QuaterCentCount  - money2.QuaterCentCount,
                money1.OneDollarCount   - money2.OneDollarCount,
                money1.FiveDollarCount  - money2.FiveDollarCount,
                money1.TwentyDollarCount- money2.TwentyDollarCount
                );

        }


        protected override bool EqualsCore(Money other)
        {
            return
                this.OneCentCount     ==other.OneCentCount      &&       
                this.TenCentCount     ==other.TenCentCount      &&
                this.QuaterCentCount  ==other.QuaterCentCount   &&
                this.OneDollarCount   ==other.OneDollarCount    &&
                this.FiveDollarCount  ==other.FiveDollarCount   &&
                this.TwentyDollarCount==other.TwentyDollarCount   ;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = OneCentCount;
                hashCode = (hashCode * 397) ^ TenCentCount;
                hashCode = (hashCode * 397) ^ QuaterCentCount;
                hashCode = (hashCode * 397) ^ OneDollarCount;
                hashCode = (hashCode * 397) ^ FiveDollarCount;
                hashCode = (hashCode * 397) ^ TwentyDollarCount;
                return hashCode;
            }
        }

        public decimal Amount
        {
            get
            {
                return TwentyDollarCount * 20 +
                    FiveDollarCount * 5 +
                    OneDollarCount +
                    (decimal)QuaterCentCount / 4 +
                    (decimal)TenCentCount / 10 +
                    (decimal)OneCentCount / 100;
            }
        }
    }
}
