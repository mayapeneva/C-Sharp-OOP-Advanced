namespace PetClinic_EXER.Models
{
    public class Room
    {
        public Room()
        {
            this.State = string.Empty;
        }

        public string State { get; set; }

        public bool IfRoomEmpty()
        {
            if (this.State != string.Empty)
            {
                return false;
            }

            return true;
        }

        public string GetRoomState()
        {
            if (this.State != string.Empty)
            {
                return this.State;
            }

            return "Room empty";
        }
    }
}