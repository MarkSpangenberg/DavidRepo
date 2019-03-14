namespace DavidBackend.Models
{

    /// <summary>
    /// This is the applications that are controlled by wifi switches with on and off states.
    /// </summary>
    public class Application
    {
        public string Name { get; set; }
        public bool IsOnState { get; set; }
        public string IpAddress { get; set; }
        public string RoomName { get; set; }
    }
}