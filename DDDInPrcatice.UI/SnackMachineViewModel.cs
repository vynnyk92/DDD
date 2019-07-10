using DDDInPrcatice.Logic;
using DddInPractice.UI.Common;
using NHibernate;

namespace DddInPractice.UI
{
    public class SnackMachineViewModel : ViewModel
    {
        private readonly SnackMachine _snackMachine;
        private string message = "";

        public string Message
        {
            get { return message; }
            set { message = value; Notify(); }
        }

        public override string Caption => "Snack Machine";
        public string MoneyInTransaction => _snackMachine.MoneyInTransaction.ToString();
        public Money MoneyInside => _snackMachine.MoneyInside;


        public Command InsertCentCommand         { get; private set; }
        public Command InsertTenCentCommand      { get; private set; }
        public Command InsertQuarterCommand { get; private set; }
        public Command InsertDollarCommand    { get; private set; }
        public Command InsertFiveDollarCommand   { get; private set; }
        public Command InsertTwentyDollarCommand { get; private set; }
        public Command BuySnackCommand { get; private set; }


        public Command ReturnMoneyCommand { get; private set; }


        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            this._snackMachine = snackMachine;

            InsertCentCommand = new Command(() => InsertMoney(Money.OneCent));
            InsertTenCentCommand        = new Command(() => InsertMoney(Money.TenCent));
            InsertQuarterCommand = new Command(() => InsertMoney(Money.QuaterCent));
            InsertDollarCommand = new Command(() => InsertMoney(Money.OneDollar));
            InsertFiveDollarCommand     = new Command(() => InsertMoney(Money.FiveDollar));
            InsertTwentyDollarCommand = new Command(() => InsertMoney(Money.TwentyDollar));
            ReturnMoneyCommand = new Command(() => ReturnMoney());
            BuySnackCommand = new Command(() => BuySnack());

        }

        private void BuySnack()
        {
            _snackMachine.BuySnack();
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(_snackMachine);
                    transaction.Commit();
                }
            }

                NotifyClient("You've bought a snack.");
        }

        private void InsertMoney(Money coinOrNote)
        {
            _snackMachine.InsertMoney(coinOrNote);
            NotifyClient("You've inserted: " + coinOrNote);
        }

         private void ReturnMoney()
        {
            _snackMachine.ReturnMoney();
            NotifyClient("Money was returned");
        }

        private void NotifyClient(string message)
        {

            Notify("MoneyInTransaction");
            Notify("MoneyInside");
            Message = message;
        }
    }
}
