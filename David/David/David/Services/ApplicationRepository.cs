using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using David.Models;
using SQLite;

namespace David.Services {
    public class ApplicationRepository {

        // This is for test purposes.
        private SQLiteAsyncConnection _dbContext;

        public ApplicationRepository() {
            TestConstructor();
        }

        /// <summary>
        /// Return a list of Applications for a specific room.
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public List<Application> GetApplications(string room) {
            return ReturnApplicationsTestData(room);

            //The real implementation can be done here.
        }

        public void UpdateState(Application application) {
            UpdateTestState(application);

            // The real implementation can be done here.
        }

        #region Test Methods

        private void TestConstructor() {
            _dbContext = new SQLiteAsyncConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.SQLiteDirectory));
            _dbContext.CreateTableAsync<Application>().Wait();
        }

        /// <summary>
        /// Return a precreated list of data for a specific room.
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        private List<Application> ReturnApplicationsTestData(string room) {
            string roomName = room;
            // Query the database for any application records.
            Task<List<Application>> applicationsDb = _dbContext.QueryAsync<Application>("SELECT * FROM Application WHERE RoomName = ?", room);
           applicationsDb.Wait();
            

            // If the database is not empty, returns the records.
            if (applicationsDb.Result.Count != 0) {
                return applicationsDb.Result;
            }

            // This section executes if the database is empty.
            List<Application> applications;

            switch (room) {
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
                    applications =  new List<Application>() {
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
                    applications =  new List<Application>() {
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

            foreach (Application application in applications) {
                InsertTestData(application);
            }

            return applications;
        }

        /// <summary>
        /// Insert test data into the database.
        /// </summary>
        /// <param name="application"></param>
        private void InsertTestData(Application application) {
            _dbContext.InsertAsync(application);
        }

        private void UpdateTestState(Application application) {
            string queryUpdate = "UPDATE [Application] " +
                                 "SET IsOnState = ? " +
                                 "WHERE RoomName = ? AND Name = ?";
            _dbContext.ExecuteAsync(queryUpdate, application.IsOnState, application.RoomName, application.Name ).Wait();
        }

        #endregion

    }
}
