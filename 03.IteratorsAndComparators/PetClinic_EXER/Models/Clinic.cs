using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PetClinic_EXER.Models
{
    public class Clinic : IEnumerable<Room>
    {
        private readonly List<Room> rooms;
        private int roomsNumber;

        public Clinic(string name, int roomsNumber)
        {
            this.Name = name;
            this.RoomsNumber = roomsNumber;
            this.rooms = new List<Room>();
        }

        public string Name { get; set; }

        public int RoomsNumber
        {
            get { return this.roomsNumber; }
            private set
            {
                if (value % 2 == 0)
                {
                    throw new ArgumentException("Invalid Operation!");
                }

                this.roomsNumber = value;
            }
        }

        public List<Room> Rooms => this.rooms;

        public void CreateClinic()
        {
            for (int i = 0; i < this.roomsNumber; i++)
            {
                this.rooms.Add(new Room());
            }
        }

        public bool Add(Pet pet)
        {
            if (this.HasEmptyRooms())
            {
                var startIndex = this.rooms.Count / 2;

                if (this.rooms[startIndex].State == string.Empty)
                {
                    this.rooms[startIndex].State = pet.ToString();
                    return true;
                }

                for (int i = 1; i <= startIndex; i++)
                {
                    if (this.rooms[startIndex - i].State == string.Empty)
                    {
                        this.rooms[startIndex - i].State = pet.ToString();
                        return true;
                    }

                    if (this.rooms[startIndex + i].State == string.Empty)
                    {
                        this.rooms[startIndex + i].State = pet.ToString();
                        return true;
                    }
                }
            }

            return false;
        }

        public bool Release()
        {
            if (this.rooms.Any(r => !r.IfRoomEmpty()))
            {
                var startIndex = this.rooms.Count / 2;

                if (this.rooms[startIndex].State != string.Empty)
                {
                    this.rooms[startIndex].State = string.Empty;
                    return true;
                }

                for (int i = 1; i <= startIndex; i++)
                {
                    if (this.rooms[startIndex + i].State != string.Empty)
                    {
                        this.rooms[startIndex + i].State = string.Empty;
                        return true;
                    }
                }

                for (int j = 0; j < startIndex; j++)
                {
                    if (this.rooms[j].State != string.Empty)
                    {
                        this.rooms[j].State = string.Empty;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool HasEmptyRooms()
        {
            return this.rooms.Any(r => r.IfRoomEmpty());
        }

        public void Print()
        {
            foreach (var room in this.rooms)
            {
                Console.WriteLine(room.GetRoomState());
            }
        }

        public void PrintRoom(int roomNumber)
        {
            Console.WriteLine($"{this.rooms[roomNumber].GetRoomState()}");
        }

        public IEnumerator<Room> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}