namespace ContactFormAppSetting.ViewModel
{
    public class EmailSettingsViewModel
    {
        public string SmtpServer {  get; set; }
        public int SmptPort {  get; set; }
        public string SenderEmail { get; set; }
        public string SenderPassword { get; set; }
        public bool EnableSSL {  get; set; }
    }
}
