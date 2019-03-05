using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using David.Models;
using SQLite;

namespace David.Services {
    public class RoomRepository {

        // This is for test purposes.
        private SQLiteAsyncConnection _dbContext;

        public RoomRepository() {
            TestConstructor();
        }

        /// <summary>
        /// Returns a list of rooms with their linked applications
        /// </summary>
        /// <returns></returns>
        public List<Room> GetRooms() {
            return ReturnRoomsTestData();

            //The real implementation can be done here.
        }

        #region Test Methods

        private void TestConstructor() {
            // Create the database connection.
            _dbContext = new SQLiteAsyncConnection(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.SQLiteDirectory));
            _dbContext.CreateTableAsync<Room>().Wait();
        }

        /// <summary>
        /// Returns a list of test data.
        /// </summary>
        /// <returns></returns>
        private List<Room> ReturnRoomsTestData() {

            // Query the database for any room records.
            Task<List<Room>> roomsDb = _dbContext.QueryAsync<Room>("SELECT * FROM [Room]");
            roomsDb.Wait();

            // If the database is not empty, returns the records.
            if (roomsDb.Result.Count != 0) {
                return roomsDb.Result;
            }

            // This section executes if the database is empty.
            List<Room> rooms = new List<Room> {
                new Room() {
                    Name = "Living Room"
                },
                new Room() {
                    Name = "Kitchen"
                },
                new Room() {
                    Name = "Bed Room"
                },
            };

            foreach (Room room in rooms) {
                InsertTestData(room);
            }

            return rooms;
        }

        /// <summary>
        /// Insert test data into the database.
        /// </summary>
        /// <param name="room"></param>
        private void InsertTestData(Room room) {

            _dbContext.InsertAsync(room);
        }

        #endregion
    }
}
