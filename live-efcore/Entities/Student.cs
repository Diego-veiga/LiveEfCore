namespace live_efcore.Entities
{
    public class Student
    {
        public Student(string fullName)
        {
            FullName = fullName;
        }
        protected Student() { }
        public int Id { get; private set; }
        public string FullName { get; private set; }

        public School School { get; set; }
        public int SchoolId { get; set; }
    }
}
