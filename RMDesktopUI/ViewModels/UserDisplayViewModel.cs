using Caliburn.Micro;
using RMDesktopUI.Library.Api;
using RMDesktopUI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RMDesktopUI.ViewModels
{
   public class UserDisplayViewModel : Screen
    {
        private StatusInfoViewModel _status; private IWindowManager _window;
        private IUserEndpoint _userEndpoint;
        BindingList<UserModel> _user;
        public BindingList<UserModel> Users
        {   get
            {
                return _user;
            }
            set
            {
                _user = value;
                NotifyOfPropertyChange(() => Users);
            }
        }
        public UserDisplayViewModel(StatusInfoViewModel status,   IWindowManager window,IUserEndpoint userEndpoint)
        {
            _window = window;
            _status = status;
            _userEndpoint = userEndpoint;
        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            try
            {
                await LoadUser();
            }
            catch (Exception ex)
            {
                dynamic settings = new ExpandoObject();
                settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                settings.ResizeMode = ResizeMode.NoResize;
                settings.Title = "System Error";

                if (ex.Message == "Unauthorized")
                {
                    _status.UpdateMessage("Unauthorized Acces", "You shall not passed!");
                    _window.ShowDialog(_status, null, settings);
                }
                else
                {
                    _status.UpdateMessage("Fatal Exception", ex.Message);
                    _window.ShowDialog(_status, null, settings);

                }

                TryClose();
                //}
                //await LoadProducts();
            }
        }
        private async Task LoadUser()
        {
            var userLists = await _userEndpoint.GetAll();
            Users = new BindingList<UserModel>(userLists);
        }
    }
}
