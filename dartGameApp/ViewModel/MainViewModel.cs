using BusinessFlowModelEngine;
using BusinessFlowModelEngine.ViewModel;
using dartGameApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dartGameApp.ViewModel
{
    class MainViewModel : BindableBase
    {
        private DelegateCommand _startNewTacticsGame;
        public DelegateCommand StartNewTacticsGame 
        {
            get 
            {
                return _startNewTacticsGame ?? (_startNewTacticsGame = new DelegateCommand
                {
                    Execute = () =>
                        {
                            Switcher.Switch(new TacticsGame());
                        }
                });
            }
        }
       
        private DelegateCommand _backToMainMenu;
        public DelegateCommand BackToMainMenu
        {
            get
            {
                return _backToMainMenu ?? (_backToMainMenu = new DelegateCommand
                {
                    Execute = () =>
                    {
                        Switcher.Switch(new MainMenu());
                    }
                });
            }
        }
    }
}
