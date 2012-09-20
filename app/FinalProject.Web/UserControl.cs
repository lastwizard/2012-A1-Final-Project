using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using FinalProject.Web.Persistence;
using System.Web.UI.WebControls;

namespace FinalProject.Web
{
    public abstract class UserControl : System.Web.UI.UserControl, IPersistable
    {
        public StateBag LocalViewState
        {
            get { return ViewState; }
        }

        #region Page events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            PersistenceUtility.OnInit(this);
        }

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            PersistenceUtility.LoadViewState(this);
        }

        protected override object SaveViewState()
        {
            PersistenceUtility.SaveViewState(this);
            return base.SaveViewState();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            PersistenceUtility.OnPreRender(this);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            PersistenceUtility.OnUnload(this);
        }

        #endregion
    }
}
