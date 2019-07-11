using DDDInPrcatice.Logic;
using DddInPractice.UI.Common;
using NHibernate;
using System.Collections.Generic;
using System.Linq;
using DDDInPrcatice.Logic.Repositories;

namespace DddInPractice.UI
{
    public class SnackMachineViewModel : ViewModel
    {
        private readonly SnackMachine _snackMachine;
        private readonly SnackMachineRepository snackMachineRepository;
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
        public Command<string> BuySnackCommand { get; private set; }


        public Command ReturnMoneyCommand { get; private set; }


        public IReadOnlyList<SnackPileViewModel> Piles
        {
            get
            {
                return _snackMachine.GetAllSnackPiles().Select(x => new SnackPileViewModel(x)).ToList();
            }
        }

        public SnackMachineViewModel(SnackMachine snackMachine)
        {
            this._snackMachine = snackMachine;
            snackMachineRepository = new SnackMachineRepository();


            InsertCentCommand = new Command(() => InsertMoney(Money.OneCent));
            InsertTenCentCommand        = new Command(() => InsertMoney(Money.TenCent));
            InsertQuarterCommand = new Command(() => InsertMoney(Money.QuaterCent));
            InsertDollarCommand = new Command(() => InsertMoney(Money.OneDollar));
            InsertFiveDollarCommand     = new Command(() => InsertMoney(Money.FiveDollar));
            InsertTwentyDollarCommand = new Command(() => InsertMoney(Money.TwentyDollar));
            ReturnMoneyCommand = new Command(() => ReturnMoney());
            BuySnackCommand = new Command<string>(BuySnack);

        }

        private void BuySnack(string position)
        {
            string error = _snackMachine.CanBuySnack(int.Parse(position));
            if (!string.IsNullOrEmpty(error))
            {

                NotifyClient(error);
            }
            else
            {
                _snackMachine.BuySnack(int.Parse(position));
                snackMachineRepository.Save(_snackMachine);

                NotifyClient("You've bought a snack.");
            }
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
