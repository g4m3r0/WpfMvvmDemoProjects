using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using GSL.Util.WpfMvvmBase;

namespace WpfAsync
{
    public class MainWindowViewModel : NotifiableBaseObject
    {
        public MainWindowViewModel()
        {
            this.DownloadCmd = new DelegateCommand((o) => Download());
            this.DownloadCmdAsync = new DelegateCommand((o) => DownloadAsync());
            this.DownloadCmdParallel = new DelegateCommand((o) => DownloadParallelAsync());
        }

        public List<string> Urls = new()
        {
            "https://google.com",
            "https://www.youtube.com/",
            "https://forum.xda-developers.com/",
            "https://www.cloudflare.com/",
            "https://usa1lib.org/",
            "https://gsoftwarelab.com/",
            "https://thefasthost.net/"
        };

        private string _infoText;

        public string InfoText
        {
            get { return _infoText; }
            set
            {
                if (_infoText != value)
                {
                    _infoText = value;
                    OnPropertyChanged();
                }
            }
        }

        public DelegateCommand DownloadCmd { get; private set; }
        public DelegateCommand DownloadCmdAsync { get; private set; }
        public DelegateCommand DownloadCmdParallel { get; private set; }

        private void Download()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            List<DownloadResult> results = new List<DownloadResult>(Urls.Count);
            foreach (var url in Urls)
            {
                results.Add(DownloadUrl(url).Result);
                ShowResults(results);
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            InfoText += $"Total Execution Time {elapsedMs}ms";
        }

        private void ShowResults(List<DownloadResult> results)
        {
            StringBuilder text = new();

            foreach (var result in results)
            {
                text.Append(result.Url);
                text.Append('\t');
                text.Append(result.ContentLength);
                text.Append(Environment.NewLine);
            }

            this.InfoText = text.ToString();
        }

        private async Task DownloadAsync()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            List<DownloadResult> results = new List<DownloadResult>(Urls.Count);
            foreach (var url in Urls)
            {
                results.Add(await DownloadUrl(url));
                ShowResults(results);
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            InfoText += $"Total Execution Time {elapsedMs}ms";
        }

        private async Task DownloadParallelAsync()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            List<Task<DownloadResult>> taskList = new List<Task<DownloadResult>>(Urls.Count);

            foreach (var url in Urls)
            {
                taskList.Add(Task.Run(() => DownloadUrl(url)));
            }

            var results = await Task.WhenAll(taskList);
            ShowResults(results.ToList());

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            InfoText += $"Total Execution Time {elapsedMs}ms";
        }

        private async Task<DownloadResult> DownloadUrl(string url)
        {
            var httpClient = new HttpClient();
            string html =  await httpClient.GetStringAsync(url);

            return new DownloadResult() { Url = url, Html = html };
        }

    }
}
