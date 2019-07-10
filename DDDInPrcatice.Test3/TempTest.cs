using DDDInPrcatice.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using NHibernate;


namespace DDDInPrcatice.Test3
{

    public class TempTest
    {

        [Fact]
        public void TempTest1()
        {

            SessionFactory.Init(@"Server=GOLPE\SQLEXPRESS;Database=DDDInPrcatice;Integrated Security=true;User=test;Password=Uuxwp7Mcxo7Khy! ");

            using (var sesseion = SessionFactory.OpenSession())
            {
                long id = 1;
                var snackMachine = sesseion.Get<SnackMachine>(id);
            }
        }

    }
}
