using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using RMDesktopUI.EventModel;
using RMDesktopUI.Library.Api;
using RMDesktopUI.Library.Model;

namespace RMDesktopUI.ViewModels
{
    
   public class ShellViewModel : Conductor<object> , IHandle<LogOnEvent>
    {
        private ILoggedInUserModel _user;
        //private  SimpleContainer _container;
        private IEventAggregator _events;
        private SalesViewModel _saleVM;
        private IAPIHelper _apiHelper;
        public ShellViewModel(IEventAggregator events,SalesViewModel saleVM,ILoggedInUserModel user, IAPIHelper apiHelper)
        {
            _events = events;
            _saleVM = saleVM;
            //_container = container;
            _user = user;
            _apiHelper = apiHelper;
            _events.SubscribeOnPublishedThread(this);
           // ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
        }
        public void ExitApplication()
        {
            TryCloseAsync();
        }
        //public void Handle(LogOnEvent message)
        //{
        //    ActivateItem(_saleVM);
        //    NotifyOfPropertyChange(() => IsLoggedIn);
        //}
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
        public async Task Branch()
        {
            await ActivateItemAsync(IoC.Get<BranchViewModel>(), new CancellationToken());
        }

        public async Task Client()
        {
            await ActivateItemAsync(IoC.Get<ClientViewModel>(), new CancellationToken());
        }
        public async Task LogIn()
        {
            await ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
        }
        public async Task LogOut()
        {
            _user.ResetUserModel();
            _apiHelper.LogOffUser();
          await  ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
            NotifyOfPropertyChange(() => IsLoggedIn);
            NotifyOfPropertyChange(() => IsLoggedOut);
        }
        public async Task UserManagement()
        {
           await ActivateItemAsync(IoC.Get<UserDisplayViewModel>(), new CancellationToken());
        }

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
         await   ActivateItemAsync(_saleVM,cancellationToken);
            NotifyOfPropertyChange(() => IsLoggedIn);
            NotifyOfPropertyChange(() => IsLoggedOut);
        }
    }
}
