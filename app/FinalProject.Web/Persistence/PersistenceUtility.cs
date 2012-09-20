using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web;
using System.Web.UI;

namespace FinalProject.Web.Persistence
{
    /// <summary>
    /// Based on article found here: http://www.codeproject.com/KB/session/PersistAttribute.aspx
    /// </summary>
    public static class PersistenceUtility
    {
        private static BindingFlags FieldBindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;

        internal static void OnInit(IPersistable item)
        {
            if (item == null)
                return;

            foreach (FieldInfo fi in item.GetType().GetFields(FieldBindingFlags))
            {
                PersistFieldAttribute attr = PersistFieldAttribute.GetAttribute(fi);
                if (attr != null)
                {
                    switch (attr.Location)
                    {
                        case PersistLocation.Application:
                            TrySetValue(item, fi, item.Application[attr.GetKeyFor(fi)]);
                            break;
                        case PersistLocation.Session:
                            TrySetValue(item, fi, item.Session[attr.GetKeyFor(fi)]);
                            break;
                        case PersistLocation.Cookie:
                            if (item.Request.Cookies[attr.GetKeyFor(fi)] != null)
                                TrySetValue(item, fi, item.Server.UrlDecode(item.Request.Cookies[attr.GetKeyFor(fi)].Value));
                            break;
                    }
                }
            }
        }

        internal static void LoadViewState(IPersistable item)
        {
            if (item == null)
                return;

            foreach (FieldInfo fi in item.GetType().GetFields(FieldBindingFlags))
            {
                PersistFieldAttribute attr = PersistFieldAttribute.GetAttribute(fi, PersistLocation.ViewState);
                if (attr != null)
                {
                    TrySetValue(item, fi, item.LocalViewState[attr.GetKeyFor(fi)]);
                }
            }
        }

        internal static void SaveViewState(IPersistable item)
        {
            if (item == null)
                return;

            foreach (FieldInfo fi in item.GetType().GetFields(FieldBindingFlags))
            {
                PersistFieldAttribute attr = PersistFieldAttribute.GetAttribute(fi, PersistLocation.ViewState);
                if (attr != null)
                    item.LocalViewState[attr.GetKeyFor(fi)] = TryGetValue(item, fi);
            }
        }

        internal static void OnPreRender(IPersistable item)
        {
            if (item == null)
                return;

            foreach (FieldInfo fi in item.GetType().GetFields(FieldBindingFlags))
            {
                PersistFieldAttribute attr = PersistFieldAttribute.GetAttribute(fi, PersistLocation.Cookie);
                if (attr != null)
                {
                    HttpCookie cookie = new HttpCookie(attr.GetKeyFor(fi), item.Server.UrlEncode(TryGetValue(item, fi).ToString()));
                    cookie.Expires = DateTime.Now.AddYears(1);
                    item.Response.Cookies.Add(cookie);
                }
            }
        }

        internal static void OnUnload(IPersistable item)
        {
            if (item == null)
                return;

            foreach (FieldInfo fi in item.GetType().GetFields(FieldBindingFlags))
            {
                PersistFieldAttribute attr = PersistFieldAttribute.GetAttribute(fi);
                if (attr != null)
                {
                    switch (attr.Location)
                    {
                        case PersistLocation.Application:
                            item.Application[attr.GetKeyFor(fi)] = TryGetValue(item, fi);
                            break;
                        case PersistLocation.Session:
                            item.Session[attr.GetKeyFor(fi)] = TryGetValue(item, fi);
                            break;
                    }
                }
            }
        }

        private static void TrySetValue(object item, FieldInfo fi, object val)
        {
            if (val != null && item != null)
                fi.SetValue(item, val);
        }

        private static object TryGetValue(object item, FieldInfo fi)
        {
            return fi.GetValue(item);
        }
    }
}
