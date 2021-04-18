using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Servicos.Tabelas;
using Modelo.Tabelas;
using System.Web.Security;

namespace FutShirt.App_Start
{
    public class UserConfig
    {
        public void LogOff()
        {
            FormsAuthentication.SignOut();
        }
    }
}