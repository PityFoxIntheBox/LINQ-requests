namespace LINQ_requests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Users> users = new List<Users>();
            string Path = "Users.csv";
            getData(Path, users);
            printData(users);
            List<Users> fem = users.Where(x => x.Gender == 'ж').ToList();
            //List<Users> fem = users.Where(x => x.Age >= 40).ToList();
            /*Console.WriteLine();
            foreach(Users f in fem)
            {
                f.show();
            }*/
        }

        static void getData(string path, List<Users> L)
        {

            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream != true)
                {
                    string[] array = sr.ReadLine().Split(';');
                    L.Add(new Users()
                    {
                        Surname = array[0],
                        Name = array[1],
                        Patronymic = array[2],
                        Phone = Convert.ToString(array[3]),
                        Login = Convert.ToString(array[4]),
                        Password = Convert.ToString(array[5]),
                        Gender = Convert.ToChar(array[6]),
                        Age = Convert.ToInt32(array[7])
                    });
                }
            }
        }
        static void printData(List<Users> L)
        {
            foreach (Users u in L)
            {
                u.show();
            }
        }
      
    }
    public struct Users
    {
        public string Surname;
        public string Name;
        public string Patronymic;
        public string Phone;
        public string Login;
        public string Password;
        public char Gender;
        public int Age;
        public void show()
        {
            Console.WriteLine("{0, -15} {1, -15} {2, -15} {3, -15} {4, -15} {5, -15} {6, -15} {7}", Surname, Name, Patronymic, Phone, 
                Login, Password, Gender, Age);
        }
        public string concat()
        {
            return Surname + ";" + Name + ";" + Patronymic + ';' + Phone + ';' + Login + ';' + Password + ';' + Gender + ';' + Age;
        }
    }
    
}