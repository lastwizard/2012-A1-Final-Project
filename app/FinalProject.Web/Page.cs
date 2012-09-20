using System;
using System.Web.UI;
using FinalProject.Web.Persistence;

namespace FinalProject.Web
{
    public abstract class Page : System.Web.UI.Page, IPersistable
    {
        protected const int NewId = -1;

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
