using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPrcatice.Logic.Common
{
    public class Initier
    {
        public static void Init()
        {
            SessionFactory.Init(@"Server=GOLPE\SQLEXPRESS;Database=DDDInPrcatice;Integrated Security=true;User=test;Password=Uuxwp7Mcxo7Khy! ");
        }
    }
}
