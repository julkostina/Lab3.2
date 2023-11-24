using lab_work3._2.Entities;
using Bussiness_layer;
using Data_layer;
using lab_work3._2;
using System.Collections;

namespace Presentational_layer
{
    public class Menu
    {
        bool finish = false;
        int num;
        string path;
        ArrayList list = new ArrayList();

        public void MainMenu()
        {
            try
            {
                ChooseFile();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            while (!finish)
            {
                ChooseAction();
            }
            EntityContext<Human>.DeleteFile(path);
        }
        private void ChooseAction()
        {
            Console.Write("Enter:\n" +
                    "1. to add new person to the database.\n" +
                    "2. to delete person from position.\n" +
                    "3. to search person by last name.\n" +
                    "4. to view students with ideal weight.\n" +
                    "5. to view activities of humans.\n" +
                    "6. to view who can cycling.\n" +
                    "7. to quit\n");
            num = Convert.ToInt32(Console.ReadLine());
            bool err = false;
            switch (num)
            {
                case 1://add new person
                    Console.Clear();
                    CreateEntity();
                    break;
                case 2:// delete person
                    Console.Clear();
                    int index = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] != null)
                        {
                            index++;
                        }
                    }
                    for (int i = 0; i < index; i++)
                    {
                        Console.Write(i);
                        if (list[i] is Student)
                        {
                            Student student = (Student)list[i];
                            Console.WriteLine(". Student" + " " + student.Name + " " + student.Surname + "\n{\r\n    \"entity\": \"student\",\r\n    \"firstName\": \"" + student.Name + "\",\r\n    \"lastName\": \"" + student.Surname + "\",\r\n    \"height\": \"" + student.Height + "\",\r\n    \"weight\": \"" + student.Weight + "\",\r\n    \"stCard\": \"" + student.StudentCard + "\"\r\n    \"passport\": \"" + student.Passport + "\"\r\n\n}");
                        }
                        if (list[i] is Librarian)
                        {
                            Librarian librarian = (Librarian)list[i];
                            Console.WriteLine(". Librarian" + " " + librarian.Name + " " + librarian.Surname + "\n{\r\n    \"entity\": \"librarian\",\r\n    \"firstName\": \"" + librarian.Name + "\",\r\n    \"lastName\": \"" + librarian.Surname + "\"\r\n     \"passport\": \"" + librarian.Passport + "\"\r\n\n}");
                        }
                        if (list[i] is SoftwareDeveloper)
                        {
                            SoftwareDeveloper softwareDeveloper = (SoftwareDeveloper)list[i];
                            Console.WriteLine(". Software developer" + " " + softwareDeveloper.Name + " " + softwareDeveloper.Surname + "\n{\r\n    \"entity\": \"software developer\",\r\n    \"firstName\": \"" + softwareDeveloper.Name + "\",\r\n    \"lastName\": \"" + softwareDeveloper.Surname + "\",\r\n    \"passport\": \"" + softwareDeveloper.Passport + "\"\r\n\n}");
                        }
                    }
                    do
                    {
                        err = false;
                        try
                        {
                            Console.WriteLine("Enter index: ");
                            if (!int.TryParse(Console.ReadLine(), out index) || (index > list.Count))
                                throw new("Incorrect index\n");
                            EntityService<Human>.Remove(index, path, list);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            err = true;
                        }
                    } while (err == true);
                    Console.WriteLine("Entity deleted successful!");
                    break;
                case 3:// search person by last name
                    int num = 0;
                    Console.Clear();
                    string lastName = CreateNameSurname("surname");
                    if (EntityService<Human>.SearchByLastName(lastName, list, out num) == true)
                    {
                        Console.WriteLine($"\nPerson found on {num} postion.\n");
                    }
                    else
                    {
                        Console.WriteLine("\nSuch person wasn`t found.\n");
                    }
                    break;
                case 4://students with ideal weight
                    Console.Clear();
                    ArrayList stList = Student.StudentsWithIdealWeight(ref list);
                    int n = 0;
                        try
                        {
                            if (stList != null)
                            {
                                for (int i = 0; i < stList.Count; i++)
                                {
                                    if (list[i] != null && list[i] is Student)
                                    {
                                        Student st = (Student)list[i];
                                        Console.WriteLine(i + ". " + st.Name + " " + st.Surname + "\n{\r\n    \"entity\": \"student\",\r\n    \"firstName\": \"" + st.Name + "\",\r\n    \"lastName\": \"" + st.Surname + "\",\r\n    \"height\": \"" + st.Height + "\",\r\n    \"weight\": \"" + st.Weight + "\",\r\n    \"stCard\": \"" + st.StudentCard + "\"\r\n    \"passport\": \"" + st.Passport + "\"\r\n}");
                                        n++;
                                    }

                                }
                                Console.WriteLine($"There are {n} students with ideal weight.\n\n");
                            }
                            else
                            {

                                throw new("0 students with ideal weight\n");
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    break;
                case 5://activities of humans
                    Console.Clear();
                    for (int i = 0; i < list.Count; i++)
                    {
                        Human human = (Human)list[i];
                        string entity = "";
                        if (list[i] is Student)
                        {
                            human = (Student)list[i];
                            entity = "Student";
                        }
                        if (list[i] is Librarian)
                        {
                            human = (Librarian)list[i];
                            entity = "Librarian";
                        }
                        if (list[i] is SoftwareDeveloper)
                        {
                            human = (SoftwareDeveloper)list[i];
                            entity = "Software developer";
                        }
                        Console.WriteLine($"{entity} {human.Name} {human.Surname}:\n\r{human.Activity()}\n");
                    }
                    break;
                case 6:// who can cycling
                    Console.Clear();
                    for (int i = 0; i < list.Count; i++)
                    {
                        Human human = (Human)list[i];
                        string entity = "";
                        if (list[i] is Student)
                        {
                            human = (Student)list[i];
                            entity = "Student";
                        }
                        if (list[i] is Librarian)
                        {
                            human = (Librarian)list[i];
                            entity = "Librarian";
                        }
                        if (list[i] is SoftwareDeveloper)
                        {
                            human = (SoftwareDeveloper)list[i];
                            entity = "Software developer";
                        }
                        Console.WriteLine($"{entity} {human.Name} {human.Surname}:\n\r{human.Cycling()}\n");
                    }
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("Program completed successful!");
                    finish = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
                    break;
            }
        }
        private void ChooseFile()
        {
            bool err = false;
            string nameOfFile = "";

            do
            {
                try
                {
                    Console.WriteLine("Enter the name of the file:");
                    nameOfFile = Console.ReadLine();
                    if (nameOfFile=="" || nameOfFile==" ")
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    else
                    {
                        Console.WriteLine("Choose extension:\n" +
                       "1.Binary\n" +
                       "2.JSON\n" +
                       "3.XML\n" +
                       "4.Custom");
                        int input = Convert.ToInt32(Console.ReadLine());

                        bool innerErr = false;
                        do
                        {
                            try
                            {
                                switch (input)
                                {
                                    case 1:
                                        CreateFileOfType(".bin", nameOfFile);
                                        break;
                                    case 2:
                                        CreateFileOfType(".json", nameOfFile);
                                        break;
                                    case 3:
                                        CreateFileOfType(".xml", nameOfFile);
                                        break;
                                    case 4:
                                        CreateFileOfType(".dat", nameOfFile);
                                        break;
                                    default:
                                        innerErr = true;
                                        throw new IndexOutOfRangeException();
                                }
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        } while (innerErr);
                    }
                       
                }
                catch(Exception e)
                {
                    err = true;
                    Console.WriteLine(e.Message);
                }
            } while (err);
        }

        private void CreateEntity()
        {
            bool err = false;
            string name = "";
            string surname = "";
            string passport = "";
            do
            {
                Console.WriteLine("Enter:" +
            "\r\n1. to create student" +
            "\r\n2. to create librarian" +
            "\r\n3. to create software developer");
                try
                {
                    int person = Convert.ToInt32(Console.ReadLine());
                    switch (person)
                    {
                        case 1:
                            err = false;
                            CreatePerson(out name, out surname, out passport);
                            EntityService<Student>.Add(new Student(name, surname, CreateWeightHeight("height"), CreateWeightHeight("weight"), passport, CreateStCard()), path, list);
                            Console.Clear();
                            Console.WriteLine("Student added!\n");
                            break;

                        case 2:
                            err = false;
                            CreatePerson(out name, out surname, out passport);
                            EntityService<Librarian>.Add(new Librarian(name, surname, passport),path, list);
                            Console.Clear();
                            Console.WriteLine("Librarian added!\n");
                            break;
                        case 3:
                            err = false;
                            CreatePerson(out name, out surname, out passport);
                            EntityService<SoftwareDeveloper>.Add(new SoftwareDeveloper(name, surname, passport),path, list);
                            Console.Clear();
                            Console.WriteLine("Software developer added!\n");
                            break;
                        default:
                            err = true;
                            throw new Exception("Unknown entity!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (err);

        }
        private void CreatePerson(out string name, out string surname, out string passport)
        {
            name = CreateNameSurname("name");
            surname = CreateNameSurname("surname");
            passport = CreatePassport();

        }
        private string CreateNameSurname(string checkValue)
        {
            string input = "";
            bool err = false;
            string res = "";
            do
            {
                try
                {
                    Console.WriteLine($"Enter {checkValue}: ");
                    input = Console.ReadLine();
                    if (!Exceptions.validNameSurname.IsMatch(input))
                    {
                        err = true;
                        throw new Exception($"Invalid {checkValue}!");
                    }
                    res = input;
                    err = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (err);
            return res;
        }
        private string CreatePassport()
        {
            string input = "";
            bool err = false;
            string res = "";
            do
            {
                try
                {
                    Console.WriteLine("Enter pasport: ");
                    input = Console.ReadLine();
                    if (!Exceptions.validPassport.IsMatch(input))
                    {
                        err = true;
                        throw new Exception("Invalid passport!");
                    }
                    res = input;
                    err = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (err);
            return res;
        }
        private string CreateStCard()
        {
            string input = "";
            bool err = false;
            string res = "";
            do
            {
                try
                {
                    Console.WriteLine("Enter student card in format KB12345678: ");
                    input = Console.ReadLine();
                    if (!Exceptions.validStCard.IsMatch(input))
                    {
                        err = true;
                        throw new Exception("Invalid student card!");
                    }
                    res = input;
                    err = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (err);
            return res;
        }
        private int CreateWeightHeight(string checkValue)
        {
            int input = 0;
            bool err = false;
            int res = 0;
            do
            {
                try
                {
                    Console.WriteLine($"Enter {checkValue}: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (!Exceptions.validWeightHeight.IsMatch(Convert.ToString(input)))
                    {
                        err = true;
                        throw new Exception($"Invalid {checkValue}!");
                    }
                    res = Convert.ToInt32(input);
                    err = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            } while (err);
            return res;
        }
        void CreateFileOfType(string extension, string name)
        {

               path= EntityContext<Human>.CreateFile(name + extension);
        
        }
        
    }

}
