using System;

namespace SharpVersion90
{
    class Program
    {
        static void Main(string[] args)
        {
            MyUser myUser = new MyUser(1, "Max");
            MyUser myUser1 = new MyUser(1, "Max");


            MyUserClass myUserClass = new MyUserClass() { Id = 1, Name = "Max" };
            MyUserClass myUserClass1 = new MyUserClass() { Id = 1, Name = "Max" };

            #region == Operator with Records
            if (myUser == myUser1)
            {
                Console.WriteLine($"== Beipsiel (Records) : {myUser == myUser1}"); 
            }
            
            if (myUserClass == myUserClass1)
            {
                Console.WriteLine($"== Beipsiel (Records) : {myUserClass == myUserClass1}");
            }
            #endregion

            #region Euqals with Records
            if (myUser.Equals(myUser1))
            {
                Console.WriteLine($"Equeals Beipsiel (Records) : {myUser.Equals(myUser1)}");
            }

            if (myUserClass.Equals(myUserClass1))
            {
                Console.WriteLine($"Equeals Beipsiel (Records) : {myUserClass.Equals(myUserClass1)}");
            }
            #endregion

            int hashCode = myUser.GetHashCode();
            int hashCode1 = myUserClass.GetHashCode();

            //Dekonstruct - Methode ist auch vorhanden
            var (id, name) = myUser;
        }
    }

    record MyUser ( int id, string username);

    public record Employee
    {
        public string Name { get; set; }
    }


    public class MyUserClass : IEquatable<MyUserClass>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static bool operator == (MyUserClass left, MyUserClass right)
        {
            if (left.Id != right.Id)
                return false;

            if (left.Name != right.Name)
                return false; 

            return true;
        }

        public static bool operator != (MyUserClass left, MyUserClass right)
        {
            if (left.Id == right.Id)
                return false;

            if (left.Name == right.Name)
                return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public bool Equals(MyUserClass other)
        {
            throw new NotImplementedException();
        }
    }
}
