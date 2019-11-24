using System;
using System.Collections.Generic;

namespace ControlePendencias.CrossCutting
{
    public interface IEMailSender
    {
        IList<String> SendToAddress { get; set; }
        IList<String> CCToAddress { get; set; }
        string Subject { get; set; }
        string MessageText { get; set; }
        bool Send();
    }
}
