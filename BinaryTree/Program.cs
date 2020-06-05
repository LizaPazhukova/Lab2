using System;
using System.Collections.Generic;

namespace BinaryTree
{
    class Program
    {
        public static void Main(string[] args)
        {
            BinaryTree<Student> studentTree = new BinaryTree<Student>();

            studentTree.Notify += DisplayMessage;
            Student student1 = new Student("Liza", "biology", DateTime.Now, 99.5);
            Student student2 = new Student("Masha", "biology", DateTime.Now, 3);
            Student student3 = new Student("Alisa", "biology", DateTime.Now, 5);
            Student student4 = new Student("Petro", "biology", DateTime.Now, 2);
            Student student5 = new Student("Artem", "biology", DateTime.Now, 21);
            //List<Student> list = new List<Student>
            //{
            //    student1,
            //    student2
            //};
            //studentTree.InsertRange(list);
            studentTree.Insert(student1);
            studentTree.Insert(student2);
            studentTree.Insert(student3);
            studentTree.Insert(student4);
            studentTree.Insert(student5);
           
            studentTree.Remove(student2);
            
            foreach (var st in studentTree)
            {
                Console.WriteLine(st.Name);
            }
            
            var r = studentTree.Find(student5);
            Console.WriteLine(r.Data.Name); 
        }

        private static void DisplayMessage(Student data, string message)
        {
            Console.WriteLine(message);
        }
    }
}



