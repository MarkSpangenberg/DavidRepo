using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using David.Models;
using David.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Application = David.Models.Application;

namespace David.Views.Widgets
{
    /// <summary>
    /// This view acts as a widget to turn switches on and off.
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SwitchesWidgetView : ContentView {
        private ApplicationRepository _applicationRepository;

        public SwitchesWidgetView ()
		{
		    _applicationRepository = new ApplicationRepository();

            InitializeComponent ();

		    CreateView();
		}

        /// <summary>
        /// This acts as the initial populate of the screen.
        /// </summary>
	    private void CreateView() {
            // This makes use of the observer pattern to subscribe to the RoomSelected message and act upon any calls made to it.
	        MessagingCenter.Subscribe<RoomsWidgetView, string>(this, "RoomSelected", (sender, arg) => {
	            RepopulateView(arg);
	        });
        }

        /// <summary>
        /// This recreates the page based on the passed parameter.
        /// </summary>
	    private void RepopulateView(string selectedRoom)
	    {
            // Clear the MainStackLayout in order to repopulate it.
	        MainStackLayout.Children.Clear();

	        List<Application> applications = _applicationRepository.GetApplications(selectedRoom);

	        if (applications == null) {
	            Label notAvailableLabel = new Label {
	                Text = "None available."
	            };

                MainStackLayout.Children.Add(notAvailableLabel);

	            return;
	        }

	        foreach (Application application in applications)
	        {
	            MainStackLayout.Children.Add(GenerateSwitchObject(application));
	        }
	    }

        /// <summary>
        /// Creates a switch section based on a passed parameter.
        /// </summary>
        private StackLayout GenerateSwitchObject(Application application) {
	        StackLayout stackLayout = new StackLayout {
                Orientation = StackOrientation.Horizontal,
	            HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    new Label{
                        Text = application.Name,
                        VerticalTextAlignment = TextAlignment.Center,
                        Margin = new Thickness(0, 0, 50, 0),
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                    }
                }
	        };

            Switch mySwitch = new Switch {
                HorizontalOptions = LayoutOptions.EndAndExpand,
                IsToggled = application.IsOnState,
                // Add a call to the repo to update the switches state.
            };
            mySwitch.Toggled += (object sender, ToggledEventArgs e) => {
                application.IsOnState = e.Value;
                _applicationRepository.UpdateState(application);
            };

            stackLayout.Children.Add(mySwitch);

            return stackLayout;
	    }
	}
}