using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using RMDesktopUI.EventModel;

namespace RMDesktopUI.ViewModels
{
    
   public class ShellViewModel : Conductor<object> , IHandle<LogOnEvent>
    {
        SimpleContainer _container;
        IEventAggregator _events;
        SalesViewModel _saleVM;
        public ShellViewModel(IEventAggregator events,SalesViewModel saleVM,SimpleContainer container)
        {
            _events = events;
            _saleVM = saleVM;
            _container = container;
            _events.Subscribe(this);
            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_saleVM);
        }
    }
}
