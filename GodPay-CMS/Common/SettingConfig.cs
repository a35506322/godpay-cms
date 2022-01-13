namespace GodPay_CMS.Common
{
    public class SettingConfig
    {
        public Connectionstring ConnectionSettings { get; set; }
        public Url Urls { get; set; }
    }

    public class Connectionstring
    {
        public string IPASS { get; set; }
    }

    public class Url
    {
        public string BaseUrl { get; set; }
        public string GodApiUrl { get; set; }
    }
}
