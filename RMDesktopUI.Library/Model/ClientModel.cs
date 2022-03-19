using System;
using System.Collections.Generic;
using System.Text;

namespace RMDesktopUI.Library.Model
{
  public  class ClientModel
    {
        public int IdClient { get; set; }
        public string ClientName { get; set; }
        public string GstNo { get; set; }
        public string ReferredBy { get; set; }
        public string Addr { get; set; }
    }
}
