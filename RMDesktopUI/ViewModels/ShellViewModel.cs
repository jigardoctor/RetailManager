using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using RMDesktopUI.EventModel;
using RMDesktopUI.Library.Model;

namespace RMDesktopUI.ViewModels
{
    
   public class ShellViewModel : Conductor<object> , IHandle<LogOnEvent>
    {
        private ILoggedInUserModel _user;
      private  SimpleContainer _container;
        private IEventAggregator _events;
        private SalesViewModel _saleVM;
        public ShellViewModel(IEventAggregator events,SalesViewModel saleVM,SimpleContainer container ,ILoggedInUserModel user)
        {
            _events = events;
            _saleVM = saleVM;
            //_container = container;
            _user = user;
            _events.Subscribe(this);
            ActivateItem(IoC.Get<LoginViewModel>());
        }
        public void ExitApplication()
        {
            TryClose();
        }
        public void Handle(LogOnEvent message)
        {
            ActivateItem(_saleVM);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
        public bool IsLoggedIn
        {
            get
            {
                bool output = false;

                if (string.IsNullOrWhiteSpace(_user.Token) == false)
                {
                    output = true;
                }

                return output;
            }
        }

        public bool IsLoggedOut
        {
            get
            {
                return !IsLoggedIn;
            }
        }
        //public async Task LogIn()
        //{
        //    await ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
        //}
        public void LogOut()
        {
            _user.ResetUserModel();
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
    }
}
