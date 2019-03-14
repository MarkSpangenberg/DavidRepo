using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DavidBackend.Models;

namespace DavidBackend.Services
{
    public class ApplicationRepository
    {
        /// <summary>
        /// Returns a list of applications for the specific room.
        /// </summary>
        /// <returns></returns>
        public List<Application> GetApplications(string room)
        {
            return GetTestApplications(room);
        }

        private List<Application> GetTestApplications(string room)
        {
            List<Application> applications;

            switch (room)
            {
                case "Living Room":
                    applications = new List<Application>() {
                        new Application() {
                            Name = "TV Backlight",
                            IpAddress = "192.168.1.50",
                            IsOnState = false,
                            RoomName = "Living Room"
                        },
                        new Application() {
                            Name = "Main Light",
                            IpAddress = "192.168.1.51",
                            IsOnState = false,
                            RoomName = "Living Room"
                        },
                        new Application() {
                            Name = "Fan",
                            IpAddress = "192.168.1.52",
                            IsOnState = false,
                            RoomName = "Living Room"
                        }
                    };
                    break;
                case "Kitchen":
                    applications = new List<Application>() {
                        new Application() {
                            Name = "Counters",
                            IpAddress = "192.168.1.60",
                            IsOnState = false,
                            RoomName = "Kitchen"
                        },
                        new Application() {
                            Name = "Table",
                            IpAddress = "192.168.1.61",
                            IsOnState = false,
                            RoomName = "Kitchen"
                        },
                        new Application() {
                            Name = "Fan",
                            IpAddress = "192.168.1.62",
                            IsOnState = false,
                            RoomName = "Kitchen"
                        }
                    };
                    break;
                case "Bed Room":
                    applications = new List<Application>() {
                        new Application() {
                            Name = "Bed Backlight",
                            IpAddress = "192.168.1.70",
                            IsOnState = false,
                            RoomName = "Bed Room"
                        },
                        new Application() {
                            Name = "Side Table",
                            IpAddress = "192.168.1.71",
                            IsOnState = false,
                            RoomName = "Bed Room"
                        },
                        new Application() {
                            Name = "Fan",
                            IpAddress = "192.168.1.72",
                            IsOnState = false,
                            RoomName = "Bed Room"
                        }
                    };
                    break;
                default:
                    return null;
            }

            return applications;
        }
    }
}