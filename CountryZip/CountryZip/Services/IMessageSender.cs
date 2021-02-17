using CountryZip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryZip.Services
{
    public interface IMessageSender
    {
        void SendMessage(AccountRegisterViewModel registerViewModel);
    }
}
