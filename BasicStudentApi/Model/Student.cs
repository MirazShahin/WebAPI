namespace BasicStudentApi.Model
{
    public class Student
    {
        private string Id;
        private string ContactNumber;
        public string id
        {
            get { return Id;  }
            set
            {
                if (value != null && value.All(char.IsDigit) && value.Length == 11) {
                    Id = value;
                }
                else
                {
                    throw new Exception("Invalid ID");
                }
            }
        } 
        public string Name { get; set; }
        public int Intake { get; set; }
        public string Mail {  get; set; }
        public string contactNumber {
            get { return ContactNumber; }
            set
            {
                if (value != null && value.All(char.IsDigit) && value.Length == 11)
                {
                    ContactNumber = value;
                }
                else
                {
                    throw new Exception("Invalid Contact Number");
                }
            }
        }
    }
}
