using AutoMapper;
using Caliburn.Micro;
using RMDesktopUI.Library.Api;
using RMDesktopUI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RMDesktopUI.ViewModels
{
    public class BranchViewModel : Screen
    {
        private IBranchEndpoint _branchEndpoint;
        private IEventAggregator _events;
        private StatusInfoViewModel _status;
        private IWindowManager _window;

        public BranchViewModel( IBranchEndpoint branchEndpoint, IEventAggregator events, IWindowManager window, StatusInfoViewModel status)
        {
            _events = events;
            _branchEndpoint = branchEndpoint;
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
            var BranchLists = await _branchEndpoint.GetAll();
            // var branches = _mapper.Map<List<BranchModel>>(BranchLists);
            BranchList = new BindingList<BranchModel>(BranchLists);
        }
        private BindingList<BranchModel> _BranchList;

        public BindingList<BranchModel> BranchList
        {
            get { return _BranchList; }
            set
            {
                _BranchList = value;
                NotifyOfPropertyChange(() => BranchList);
            }
        }
        private BranchModel _SelectedBranch;

        public BranchModel SelectedBranch
        {
            get { return _SelectedBranch; }
            set
            {
                _SelectedBranch = value;
                NotifyOfPropertyChange(() => SelectedBranch);
                NotifyOfPropertyChange(() => CanRemovebt);
                NotifyOfPropertyChange(() => CanEditbt);
            }
        }
        
        private string _Branchnametx;

        public string Branchnametx
        {
            get { return _Branchnametx; }
            set { _Branchnametx = value;
                NotifyOfPropertyChange(() => CanAdd_bt);
            }
        }

        public bool CanAdd_bt
        {
            get
            {
                bool output = false;
                if (Branchnametx?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
        }
        public bool CanRemovebt
        {
            get
            {
                bool output = false;
                if (SelectedBranch != null && SelectedBranch?.IdBranch > 0)
                {
                    output = true;
                }
                return output;
            }
        }
        public bool CanEditbt
        {
            get
            {
                bool output = false;
                if (SelectedBranch != null && SelectedBranch?.IdBranch > 0)
                {
                    output = true;
                }
                return output;
            }
        }
        public async Task Add_bt()
        {
            BranchModel branchModel = new BranchModel();
            branchModel.BranchName = Branchnametx;
            branchModel.Ho = true;
            await _branchEndpoint.AddBranch(branchModel);
            await LoadProducts();
        }
        public async Task Removebt()
        {
 
            BranchModel brancmodel = new BranchModel();
            brancmodel.IdBranch = SelectedBranch.IdBranch;

            await _branchEndpoint.RemoveBranch(brancmodel);
            await LoadProducts();
        }
        public async Task Editbt()
        {
         
            BranchModel brancmodel = new BranchModel();
            brancmodel.IdBranch = SelectedBranch.IdBranch;
            brancmodel.BranchName = Branchnametx;

            await _branchEndpoint.EditBranch(brancmodel);
            await LoadProducts();
        }
    }
}
