using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using David.Models;
using David.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace David.Views.Widgets
{
    /// <summary>
    /// This view acts as a widget to contain all the available rooms.
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoomsWidgetView : ContentView {
	    private const double BlockPercentage = 0.4;

        private RoomRepository _roomRepository;

        public RoomsWidgetView() {
            _roomRepository = new RoomRepository();

            InitializeComponent ();

            CreateView();
		}

		/// <summary>
        /// This creates the view.
        /// </summary>
	    private void CreateView() {
	        List<Room> rooms = _roomRepository.GetRooms();

	        foreach (Room room in rooms) {
	            ScrollViewContainer.Children.Add(GenerateGridObject(room));
	        }
        }

        /// <summary>
        /// Creates a selectable section based on the passed parameter.
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
	    private Frame GenerateGridObject(Room room) {

	        Frame frame = new Frame {
	            BorderColor = Constants.AppThemeColor,
                HeightRequest = CalculateBlockSize(),
                WidthRequest = CalculateBlockSize(),
                CornerRadius = 5
	        };

	        frame.GestureRecognizers.Add(new TapGestureRecognizer {
	            Command = new Command(() => {
	                SetFramesUnselected();
                    SetFrameTapped(frame);
	            })
            });

	        Label name = new Label {
	            Text = room.Name,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
	            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };

	        frame.Content = name;

            // Sets the state of the first frame to selected.
            if (ScrollViewContainer?.Children != null && ScrollViewContainer.Children.Count == 0) {
                SetFrameTapped(frame);
            }
            
            return frame;
	    }

        /// <summary>
        /// This returns the size the blocks should be.
        /// </summary>
        /// <returns></returns>
	    private double CalculateBlockSize() {
	        return 100;
        }

        /// <summary>
        /// This sets the passed frame in the selected state.
        /// </summary>
        /// <param name="frame"></param>
	    private void SetFrameTapped(Frame frame) {
            frame.BackgroundColor = Color.LightGray;

            // Does a check to ensure the content of frame is a label.
            if (frame?.Content != null && object.ReferenceEquals(frame.Content.GetType(), typeof(Label))) {
                Label lb = (Label)frame.Content;

                // Sends a message to all subscribed listeners with a parameter.
                MessagingCenter.Send<RoomsWidgetView, string>(this, "RoomSelected", lb.Text);
            }
	        
	    }

        /// <summary>
        /// Sets all the frames to the unselected state.
        /// </summary>
	    private void SetFramesUnselected() {
            // Loops through all the items in ScrollViewContainer and sets the background to the unselected color.
	        foreach (var child in ScrollViewContainer.Children) {
	            if (child != null && ReferenceEquals(child.GetType(), typeof(Frame))) {
	                Frame frame = (Frame) child;
                    frame.BackgroundColor = Color.White;
	            }
	        }
        }
	}
}