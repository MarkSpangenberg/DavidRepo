using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using David.Views.Widgets;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace David.Views.Pages
{
    /// <summary>
    /// This page acts as the home page for the applications.
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ApplicationsHomePage : ContentPage {

        /// <summary>
        /// This prevents the page from being created twice.
        /// </summary>
        private bool _alreadyCreated;

		public ApplicationsHomePage () {
		    Title = "Applications";

		    InitializeComponent ();

		    _alreadyCreated = false;
		}

	    /// <inheritdoc />
	    protected override void OnAppearing() {
            // Locks the call to avoid it recreating when the page appears again.
	        if (_alreadyCreated == false) {
                _alreadyCreated = true;
                // Add the widgets to the xaml sections.
                ApplicationLayout.Children.Add(new SwitchesWidgetView());
	            RoomLayout.Children.Add(new RoomsWidgetView());
	        }
        }
	}
}