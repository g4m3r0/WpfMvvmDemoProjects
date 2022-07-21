namespace WpfAsync
{
    public class DownloadResult
    {
        public string Url { get; set; }
        public string Html { get; set; }
        public int ContentLength => Html?.Length ?? 0;
    }
}
