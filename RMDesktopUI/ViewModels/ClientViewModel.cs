using Caliburn.Micro;
using RMDesktopUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RMDesktopUI.ViewModels
{

    public class ClientViewModel :Screen
    {
        private IClientEndpoint _clientEndpoint;
        private IEventAggregator _events;
        private StatusInfoViewModel _status;
        private IWindowManager _window;

        public ClientViewModel(IClientEndpoint clientendpoint, IEventAggregator events, IWindowManager window, StatusInfoViewModel status)
        {
            _events = events;
            _clientEndpoint = clientendpoint;
            _status = status;
            _window = window;

        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            try
            {
                await LoadProducts();
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
                    await _window.ShowDialogAsync(_status, null, settings);
                }
                else
                {
                    _status.UpdateMessage("Fatal Exception", ex.Message);
                    await _window.ShowDialogAsync(_status, null, settings);
                }

                TryCloseAsync();
                //}
                //await LoadProducts();
            }
        }

        private async Task LoadProducts()
        {
            var BranchLists = await _clientEndpoint.GetAll();
          //  BranchList = new BindingList<BranchModel>(BranchLists);
        }
    }
}
