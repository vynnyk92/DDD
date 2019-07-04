using System;
using DDDInPrcatice.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DDDInPrcatice.Test2
{
    [TestClass]
    public class MoneySpec
    {
        [TestMethod]
        public void SumOfTwoMoneyProducesCorrectResult()
        {
            Money money1 = new Money(1, 1, 1, 1, 1, 1);
            Money money2 = new Money(1, 1, 1, 1, 1, 1);
            Money sumExp = new Money(2, 2, 2, 2, 2, 2);

            Money sumRes = money1 + money2;


            Assert.IsTrue(sumRes.Equals(sumExp));
        }

       
    }
}
