using DddInPractice.Logic;
using DDDInPrcatice.Logic;
using NHibernate;

namespace DddInPractice.UI.Common
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            SnackMachine snackMachine = null;
            using (var session = SessionFactory.OpenSession())
            {
                long id = 1;
                snackMachine = session.Get<SnackMachine>(id);
            }

            var viewModel = new SnackMachineViewModel(snackMachine);
            _dialogService.ShowDialog(viewModel);
        }
    }
}
