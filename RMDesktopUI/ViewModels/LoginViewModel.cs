﻿using Caliburn.Micro;
using RMDesktopUI.EventModel;
using RMDesktopUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.ViewModels
{
   public  class LoginViewModel :Screen
    {
        private string _userName = "digital@gmail.com";
        private IAPIHelper _apiHelper;
        private string _password="Pwd12345.";
        private IEventAggregator _events;

        public LoginViewModel(IAPIHelper apihelper ,IEventAggregator events)
        {
            _events = events;
            _apiHelper = apihelper;
        }
        public string UserName
        {
            get { return _userName; }
            set 
            { 
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }
      

        public string Password
        {
            get { return _password; }
            set
            { 
                _password = value;
                NotifyOfPropertyChange(() => Password );
                NotifyOfPropertyChange(() => CanLogIn);
            }
        }

        public bool IsErrorVisible
        {
            get
            {
                bool output = false;
                if (ErrorMessage?.Length > 0)
                {
                    output = true;
                }
                return output;
            }

        }
        private string  _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        public bool CanLogIn
        {
            get
            {
                bool output = false;
                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }
                return output;

            }
        }
        public async Task LogIn()
        {
            try
            {
                ErrorMessage = "";
                var result = await _apiHelper.Authenticate(UserName, Password);
                //ErrorMessage = "Succesfully LogIn";
                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

               _events.PublishOnUIThread(new LogOnEvent());
            }
            catch ( Exception ex )
            {

                ErrorMessage = ex.Message;
            }
        }

    }
}
