using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPrcatice.Logic
{
    public class Snack : AggregateRoot
    {
        public virtual string Name { get; protected set; }

        protected Snack()
        {

        }

        public Snack(string name)
            : this()
        {
            this.Name = name;
        }


    }
}
