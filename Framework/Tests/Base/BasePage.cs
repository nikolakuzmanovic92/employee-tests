using System;
using System.Collections.Generic;
using System.Text;
using Tests.Pages;

namespace Tests.Base
{
    public abstract class BasePage
    {
        public readonly NavBar NavBar;

        public BasePage()
        {
            NavBar = new NavBar();
        }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage)Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }

    }
}
