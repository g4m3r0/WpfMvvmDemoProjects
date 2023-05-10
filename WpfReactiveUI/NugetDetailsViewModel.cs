using NuGet.Protocol.Core.Types;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace WpfReactiveUI
{
    // This class wraps our NuGet model object into a ViewModel and allows
    // us to have a ReactiveCommand to open the NuGet package URL.
    public class NugetDetailsViewModel : ReactiveObject
    {
        private readonly IPackageSearchMetadata _metadata;
        private readonly Uri _defaultUrl;

        public NugetDetailsViewModel(IPackageSearchMetadata metadata)
        {
            _metadata = metadata;
            _defaultUrl = new Uri("https://git.io/fAlfh");
            OpenPage = ReactiveCommand.Create(() =>
            {
                Process.Start(new ProcessStartInfo(this.ProjectUrl.ToString())
                {
                    UseShellExecute = true
                });
            });
        }

        public Uri IconUrl => _metadata.IconUrl ?? _defaultUrl;
        public string Description => _metadata.Description;
        public Uri ProjectUrl => _metadata.ProjectUrl;
        public string Title => _metadata.Title;

        // ReactiveCommand allows us to execute logic without exposing any of the 
        // implementation details with the View. The generic parameters are the 
        // input into the command and its output. In our case we don't have any 
        // input or output so we use Unit which in Reactive speak means a void type.
        public ReactiveCommand<Unit, Unit> OpenPage { get; }
    }
}
