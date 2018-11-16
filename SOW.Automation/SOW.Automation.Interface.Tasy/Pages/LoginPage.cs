using SOW.Automation.Common.WEB;
using SOW.Automation.Platform.WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOW.Automation.Interface.Tasy.Pages
{
    public class LoginPage:BasePages
    {
        DriverContextInfo _infoContext;
        public LoginPage(DriverContextInfo i)
        {
            _infoContext = i;
        }
        public void OpenURL(string url)
        {
            this.CheckDriverLoaded(_infoContext);

            //this._webServices.BaseWebElement.OpenURL(url, _infoContext.Timeout);
        }

        public void InsertUserNameAndPassword(string user, string pws)
        {
            this.CheckDriverLoaded(_infoContext);

            //this._webServices.BaseWebElement.InsertTextInLabelByName("idLabelUsuario", user, _infoContext.Timeout);
            //this._webServices.BaseWebElement.InsertTextInLabelByName("idLabelSenha", pws, _infoContext.Timeout);
        }
    }
}
