using System;
using System.Collections.Generic;
using System.Text;

namespace DDDInPrcatice.Logic
{
    public class Slot : BaseEntity
    {
        public virtual SnackPile SnackPile { get; set; }
        public virtual SnackMachine SnackMachine { get;  set; }
        public virtual int Position { get;  set; }

        protected Slot()
        {

        }

        public Slot(SnackMachine snackMachine, int position) 
            :this()
        {
            this.SnackMachine = snackMachine;
            this.Position = position;
            this.SnackPile = new SnackPile(null, 0, 0);
        }
    }
}
