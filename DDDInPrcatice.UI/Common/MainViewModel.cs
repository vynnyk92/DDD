﻿using DddInPractice.Logic;
using DDDInPrcatice.Logic;
using DDDInPrcatice.Logic.Repositories;
using NHibernate;

namespace DddInPractice.UI.Common
{
    public class MainViewModel : ViewModel
    {
        
        public MainViewModel()
        {
            SnackMachine snackMachine = new SnackMachineRepository().GetById(1);

            var viewModel = new SnackMachineViewModel(snackMachine);
            _dialogService.ShowDialog(viewModel);
        }
    }
}
