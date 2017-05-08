using System;

namespace classroom
{
    class Room
    {

        public int RoomNumber{get; set;}

        public int Period{get; set;}

        public string[] DaysOfWeek{get; set;}

        public string TeacherName{get; set;}

    }

    class Student
    {

        public string Name{get; set;}

        public int StudentID{get; set;}

        public int[] roomNumbers{get; set;}

        public float GPA{get; set;}

        public void SitDown(Seat seatID){

            setID.IsOccupied(true);
        }

    }

    class Teacher
    {
        public string Name{get; set;}

        public string Subject{get; set;}

        public int Period{get; set;}

        public int RoomID{get; set;}

        public string[] DaysOfWeek{get; set;}

    }

    class Seat
    {

        public int SeatID{get; set;}

        public bool IsOccupied{get; set;}

        public int RoomNumber{get; set;}

        // In a classroom 2-dimensional grid, what is the position
        public int[] position{get; set;}

        public id StudentID{get; set;}

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Room firstRoom = new Room();
            firstRoom.setTeacherName("Cecil Phillip");
            firstRoom.setRoomNumber(8310);
            firstRoom.setDaysOfWeek("Monday", "Wednesday");
            firstRoom.setPeriod("6PM-9PM");

            Seat firstSeat = new Seat();
            Student firstStudent - new Student();
            firstStudent.SitDown(firstSeat);
        }
    }
}
