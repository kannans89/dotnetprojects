using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace SCMProfit.LanguageClasses
{
    public static class SiteLanguage
    {
        public static List<Languages> listOfLanguage = new List<Languages>() { 
            new Languages{LangFullName="English", LangCultureName="en"},
            new Languages{LangFullName="हिंदी", LangCultureName="hi"},
        };

        public static bool IsLanguageAvailable(string lang)
        {
            return listOfLanguage.Where(m => m.LangCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage()
        {
            return listOfLanguage[0].LangCultureName;
        }

        public static void SetLanguage(string lang)
        {
            try
            {
                if (!IsLanguageAvailable(lang))
                    lang = GetDefaultLanguage();
                var cultureInfo = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                HttpCookie cookie = new HttpCookie("culture", lang);
                cookie.Expires = DateTime.Now.AddMinutes(5);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}