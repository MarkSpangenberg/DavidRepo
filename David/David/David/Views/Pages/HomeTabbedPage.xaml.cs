using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using TabbedPage = Xamarin.Forms.TabbedPage;

namespace David.Views.Pages
{
    /// <summary>
    /// This creates a tabbed view of several pages that can be added to the home page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeTabbedPage : TabbedPage
    {
        public HomeTabbedPage () {
            Title = "Home";
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            InitializeComponent();

            // Add the tabbed pages.
            this.Children.Add(new ApplicationsHomePage());
            this.Children.Add(new AutomationPage());
        }
    }
}