using System;

namespace BinaryTree
{
    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public double TestScore { get; set; }
        public Student(string name, string testName, DateTime testDate, double testScore)
        {
            Name = name;
            TestName = testName;
            TestDate = testDate;
            TestScore = testScore; 
        }

        public int CompareTo(Student other)
        {
            return this.TestScore.CompareTo(other.TestScore);
        }

        public override string ToString()
        {
            return $"Name: {Name}, TestName: {TestName}, TestScore: {TestScore}";
        }
    }
}
