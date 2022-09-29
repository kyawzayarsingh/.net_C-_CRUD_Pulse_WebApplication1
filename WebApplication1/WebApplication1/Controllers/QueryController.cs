using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class QueryController : Controller
    {
        // GET: Query
        public ActionResult QuerySyntax()
        {
            List<int> list = new List<int>() { 1,2,3,4,5,6,7,8,9};

            //we can set IEnumerable to var keywords
            //var querySyntax = from  item in list
            //                  where item>2
            //                  select item;
            IEnumerable<int> querySyntax = from item in list
                              where item > 2
                              select item;
            ViewBag.querySyntax = querySyntax;

            List<Employee> employees = new List<Employee> { 
                new Employee() { Id =1 , Name="Kyaw", Email = "kyaw@gmail.com"},
                new Employee() { Id =2 , Name="Myint", Email = "myint@gmail.com"},
            };

            //with IEnumerable
            IEnumerable<Employee> emp0 = from emp in employees
                                           where emp.Id == 1
                                           select emp;

            //with IQueryable
            IQueryable<Employee> emp1 = employees.AsQueryable().Where(x => x.Id == 1);

            var methodSyntax = list.Where(x => x > 2);
            ViewBag.methodSyntax = methodSyntax;

            var mixedSyntax = (from obj in list
                              select obj).Max();
            ViewBag.mixedSyntax = mixedSyntax;

            return View();
        }

        public ActionResult BasicQuery()
        {
            List<Employee> employees = new List<Employee> {
                new Employee() { Id =1 , Name="Kyaw", Email = "kyaw@gmail.com"},
                new Employee() { Id =2 , Name="Myint", Email = "myint@gmail.com"},
                new Employee() { Id =2 , Name="ok", Email = "bb@gmail.com"},
                new Employee() { Id =2 , Name="gg", Email = "vv@gmail.com"},
                new Employee() { Id =2 , Name="ff", Email = "aa@gmail.com"},
            };

            var BasicQuery = (from emp in employees
                              select emp).ToList();

            var BasicMethod = employees.ToList();

            //Operations 
            var BasicPropQuery = (from emp in employees
                                  select emp.Id).ToList();
            //if we want the selected employee in a string format, you can set
            //(from emp in employees select emp.Id.ToString()).ToList();

            var BasicPropMethod = employees.Select(x => x.Id).ToList();

            //if we fetch only Id and Email from the employee
            var selectedQuery = (from emp in employees
                                 select new Employee()
                                 {
                                     Id = emp.Id,
                                     Email = emp.Email
                                 }).ToList();
            //output in a foreach, item.Id, item.Email

            //we can set the employees list of values to Student
            var selectedQuery1 = (from emp in employees
                                  select new Student()
                                  {
                                      StudentId = emp.Id,
                                      StudentName = emp.Name,
                                      StudentEmail = emp.Email
                                  }).ToList();
            //output in a foreach, item.StudentId, item.StudentName, item.StudentEmail

            var selectedMethod = employees.Select(emp => new Student()
            {
                StudentId = emp.Id,
                StudentName = emp.Name,
                StudentEmail = emp.Email
            }).ToList();

            // so in the above , we set employee type, student type
            // and now we are setting up anonymous type
            var selectedQuery3 = (from emp in employees
                                  select new
                                  {
                                      CustomId = emp.Id,
                                      CustomName = emp.Name,
                                      CustomEmail = emp.Email
                                  }).ToList();
            return View();
        }

        public ActionResult SelectManyQuery()
        {
            List<string> list = new List<string>() { "Raaj", "Simba" };

            var query = list.SelectMany(x => x).ToList();// total 9 results - "R","a","a","j","S","i","m","b","a" 

            var query1 = (from x in list
                          from res in x 
                          select res).ToList();

            //so for this, I can add one field in Employee Model, that is List of programming
            List<Employee> employees = new List<Employee> {
                new Employee() { Id =1 , Name="Kyaw", Email = "kyaw@gmail.com",Programming = new List<string>(){ "C#","PHP","JAVA"} },
                new Employee() { Id =2 , Name="Myint", Email = "myint@gmail.com",Programming = new List<string>(){ "SQL","Python","Laravel"}},
                new Employee() { Id =2 , Name="ok", Email = "bb@gmail.com",Programming = new List<string>(){ "React","LINQ","MONGO"}},
            };

            var methodSyntax = employees.SelectMany(emp => emp.Programming).ToList();

            var querySyntax = (from emp in employees
                               from skill in emp.Programming
                               select skill).ToList();


            List<Employee> employees1 = new List<Employee>() {
                new Employee() { Id =1 , Name="Kyaw", Email = "kyaw@gmail.com",NewProgramming = new List<Techs>(){
                    new Techs() { Technology = "C#"},
                    new Techs() { Technology = "PHP"},
                    new Techs() { Technology = "Laravle"},
                } },
                new Employee() { Id =2 , Name="Myint", Email = "myint@gmail.com",NewProgramming = new List<Techs>(){
                new Techs(){ Technology = "SQL"},
                new Techs(){ Technology = "Python"},
                new Techs(){ Technology = "Laravel"},
                }},
                new Employee() { Id =2 , Name="ok", Email = "bb@gmail.com",NewProgramming = new List<Techs>(){ 
                new Techs(){ Technology = "React" },
                new Techs(){ Technology = "LINQ" },
                new Techs(){ Technology = "Mongo" },
                }},
            };

            var methodSyntax1 = employees.SelectMany(emp => emp.NewProgramming).ToList();

            var querySyntax1 = (from emp in employees
                               from pro in emp.NewProgramming
                               select pro).ToList();

            return View();
        }

        public ActionResult Object_OfType()
        {
            var datasource = new List<Object>() { "Raaj", "Shilpa", "Arun", "Maya","Aradhaya", 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var methodSyntaxString = datasource.OfType<string>().ToList(); // "Raaj", "Shilpa", "Arun", "Maya"
            var methodSyntax1String = datasource.OfType<string>().Where(x => x.Length > 4).ToList();//"Shilpa","Aradhaya"
            var methodSyntaxInt = datasource.OfType<int>().ToList();// 1,,2,3,4,5,6,7,8,9

            var querySyntax = (from x in datasource
                               where x is string
                               select x).ToList();

            //OrderBy method is used to sort data in ascending order.
            //We can apply OrderBy method on any data type
            var dataSourceString = new List<string>()
            {
                "Raaj",
                "Danish",
                "Ganesh",
                "Suubo",
                "Papu",
                "Chotu"
            };

            var order1 = (from name in dataSourceString
                          where name.Length > 5
                          orderby name
                          select name).ToList();

            var order2 = dataSourceString.Where(x => x.Length > 5).OrderBy(x => x).ToList();

            //order by descending
            var order3 = (from name in dataSourceString
                          where name.Length > 5 
                          orderby name descending
                          select name).ToList();

            var order4 = dataSourceString.Where(x => x.Length > 5).OrderByDescending(x => x).ToList();

            //ThenBy method is used to sort data on the second level and so on in ascending order.
            // we used thenby after the orderby method becoz it is on the second level
            //we can use on the third level also
            var dataEmployee = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Kyaw", LastName = "Smith",Email = "kyaw@gmail.com"},
                new Employee() { Id = 2, Name = "Kyaw", LastName = "Anderson",Email = "kyaw@gmail.com"},
                new Employee() { Id = 3, Name = "Myint", LastName = "Thomas",Email = "Myint@gmail.com"},
                new Employee() { Id = 4, Name = "Myint", LastName = "Allen",Email = "Myint@gmail.com"}
            };

            var ms = dataEmployee.OrderBy(emp => emp.Name).ToList();// K,K,M,M all data will show, 
            var ms1 = dataEmployee.OrderBy(emp => emp.Name).ThenBy(emp => emp.LastName).ToList();//Aderson, Smith,Allen, Thomas
            var qs = (from emp in dataEmployee
                      orderby emp.Name descending, emp.LastName descending
                      select emp).ToList();

            //Reverse() method
            //both results will be same, the second one is Enumberable type
            dataSourceString.Reverse();
            var res = dataSourceString.AsEnumerable().Reverse();
            return View();
        }

        //set operations methods
        // Distinct (Removes duplicate values from data source)
        // Except ( Returns all the elements from one data source that don't exist in second data source
        // Intersect ( Returns all the elements which exist in both the data source
        //Union ( Returns all the elements that appear in either of the two data sources.
        public ActionResult SetOperations()
        {
            //Distinct method
            List<Student> students = new List<Student>()
            {
                new Student() {StudentId =1, StudentName = "Kim"},
                new Student() {StudentId =2, StudentName = "John"},
                new Student() {StudentId =3, StudentName = "GG"},
                new Student() {StudentId =4, StudentName = "FF"},
            };

            var ms = students.Select(x=>x.StudentName).Distinct().ToList();

            //Except method
            var datasource1 = new List<string>() { "A", "B", "C", "D" };
            var datasource2 = new List<string>() { "C", "D" ,"E","F"};

            var ms1 = datasource1.Except(datasource2).ToList(); // {"A","B"}
            var ms2 = datasource2.Except(datasource1).ToList(); // {"E","F"}

            List<Student> students1 = new List<Student>()
            {
                new Student() {StudentId =1, StudentName = "Kim"},
                new Student() {StudentId =2, StudentName = "John"},
                new Student() {StudentId =3, StudentName = "Kim"},
                new Student() {StudentId =4, StudentName = "John"},
            };
            
            var ms3 = students.Select(x=>x.StudentName).Except(students1.Select(x=>x.StudentName)).ToList();
            //anonymous 
            var ms4 = students.Select(x => new { x.StudentId, x.StudentName }).Except(students1.Select(x => new { x.StudentId, x.StudentName })).ToList();

            //Intersect method
            var intersectMs = datasource1.Intersect(datasource2).ToList(); // "C","D"
            var intersectQs = (from x in datasource1
                               select x).Intersect(datasource2).ToList();

            //Union method
            var unionMs = datasource1.Union(datasource2).ToList();//"A","B","C","D","E","F"
            var unionQs = (from x in datasource1
                               select x).Union(datasource2).ToList();

            return View();
        }


        //Partitions data method
        //Take , TakeWhile, Skip, SkipWhile
        public ActionResult PartitionsMethod()
        {
            //Take operator is used to get first n number of records from a data source. Where n is integer which
            //is passed in Take method.
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            var ms = numbers.Take(5).ToArray(); //1,2,3,4,5
            var ms1 = numbers.Where(x => x > 3).Take(5).ToList();// 4,5,6,7,8

            //if we use condition after the take method, so the result will be below:
            var ms2 = numbers.Take(5).Where(x => x > 3).ToArray();// 4,5


            //TakeWhile operator is used to get all record from a datasource until a specified conditon is true.
            //Once the condition is failed TakeWhile will not validate rest elements Event if the condition
            //is true for the remaining elements.
            int[] number1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] number2 = new int[] { 1, 2, 6, 7, 8, 9, 10, 3, 4, 5 };

            var takeWhileMs = number1.TakeWhile(x => x < 7).ToList();// 1,2,3,4,5,6
            var takeWhileMs1 = number2.TakeWhile(x => x < 7).ToList();// 1,2 becoz once the condition failed.....

            List<string> names = new List<string>() { "Kim", "John", "Mark", "Ada", "Raj" };

            var takeWhilems = names.TakeWhile((name, index) => name.Length > index).ToList(); // "Kim","John","Mark"


            //skip operator is used to skip first n number of records from a datasource and select remaining elements
            // as an output where n is an integer which is passed in Skip method

            var skipMs = number2.Skip(3).ToList(); //7,8,9,10,3,4,5
            var conditionMs = number2.Where(x => x > 4).Skip(3).ToList();//9,10,5
            var mixSkip = (from num in names
                           select num).Skip(3).ToList(); // "Ada","Raj"

            //skipWhile operator is used to skip all records from a data source until a codition is true and
            //and select remaining elements as an output
            int[] numberSkip = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ,2};
            var skipWhilems = numberSkip.SkipWhile(x => x < 6).ToArray();// 6,7,8,9,10,2
            var skipWhilems1 = names.SkipWhile(x => x.Length < 4).ToList();// "John", "Mark", "Ada", "Raj"
            return View();
        }

        //we are using skip and take for paging
        // we need to give the Pagenumber from browser
        public ActionResult Paging(int pageNumber)
        {
            int totalPagePerView = 4;
            var ms = GetEmployee().Skip((pageNumber - 1) * totalPagePerView).Take(totalPagePerView);
            return View();
        }

        public static List<Employee> GetEmployee()
        {
            return new List<Employee>()
            {
                new Employee() { Id = 1 , Name= "kyaw", LastName = "Wai",Email = "kyaw@gmail.com"},
                new Employee() { Id = 2 , Name= "kyaw", LastName = "Wai",Email = "kyaw@gmail.com"},
                new Employee() { Id = 3 , Name= "kyaw", LastName = "Wai",Email = "kyaw@gmail.com"},
                new Employee() { Id = 4 , Name= "kyaw", LastName = "Wai",Email = "kyaw@gmail.com"},
                new Employee() { Id = 5 , Name= "kyaw", LastName = "Wai",Email = "kyaw@gmail.com"},
                new Employee() { Id = 6 , Name= "kyaw", LastName = "Wai",Email = "kyaw@gmail.com"},
                new Employee() { Id = 7 , Name= "kyaw", LastName = "Wai",Email = "kyaw@gmail.com"},
                new Employee() { Id = 8 , Name= "kyaw", LastName = "Wai",Email = "kyaw@gmail.com"},
                new Employee() { Id = 9 , Name= "kyaw", LastName = "Wai",Email = "kyaw@gmail.com"},
                new Employee() { Id = 10 , Name= "kyaw", LastName = "Wai",Email = "kyaw@gmail.com"},
                new Employee() { Id = 11, Name= "kyaw", LastName = "Wai",Email = "kyaw@gmail.com"},
                new Employee() { Id = 12 , Name= "kyaw", LastName = "Wai",Email = "kyaw@gmail.com"}
            };
        }

        //Join Operation Method
        //Join (Used to get data from two-data sources or more than two)
        //GroupJoin ( Used to get data from two-data sources by grouping all the elements)


        //Element Operations
        //Select First Record from the datasource
        //Select Last Record from the datasource
        //Select nth Element from the datasource
        // ElementAt(), ElementAtOrDefault(),First(), FirstOrDefault(),Last(), LastOrDefault(),Single(),SingleOrDefault()

        public ActionResult ElementOperations()
        {
            //ok so ElementAt(), ElementAtOrDefault()
            //Both are used (independently) to return an element from a specific index
            //If the element is not available at given index - ElementAt will throw an exception but 
            //ElementAtOrDefault will return null

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var ms = numbers.ElementAt(3); //4
            var ms1= numbers.ElementAt(10); // throw an error
            var ms2 = numbers.ElementAtOrDefault(10); // if it is interger, it return 0, becoz the value isn't in List at index 10
            //if it is string or object , it return null
            var ms3 = numbers.Where(x => x > 3).ElementAtOrDefault(1); // for the condtion, we have {4,5,6,7,8,9,10} // so the result is 5


            //First(), FirstOrDefault()
            //Both are used (independently) to return first element from a datasource
            //If the element is not available at first index - First will throw an exception
            //But FirstOrDefault will return default value of data source element
            var firstMs = numbers.First(); // 1
            var firstMs1 = numbers.Where(x => x>5).First();// 6
            var firsttMs2 = numbers.First(x => x > 5); // 6 //recommond this one

            //Last(), LastOrDefault()
            //Both are used (independently) to return last element from a datasource
            //If the element is not available at last index - Last will throw an exception
            //But LastOrDefault will return default value of data source element
            var lastMs = numbers.Last();//10
            var lastMs1 = numbers.Where(x=> x>15).LastOrDefault(); // 0


            //Single(), SingleOrDefault()
            //Both are used (independently) to return single element from a datasource
            //If the element is available at multiple places then both the methods will throw an exception
            //if no element is available in the datasource -Single throw an exception
            //but SingleOrDefault  will return default value of data source element

            List<int> num1 = new List<int> { 1 };
            List<int> num2 = new List<int> { 1,2 };
            List<int> num3 = new List<int> { 1,2,3};

            var singleMs = num1.Single(); // 1
            var singleMs1 = num2.Single(); //error
            var signleMs2 = num2.Where(x => x > 1).Single(); //2 
            var signleMs3 = num3.Where(x => x > 1).Single(); // error
            //This time, singleOrDefault is not work as all the above work, it throw an error
            var signleMs4 = num3.Where(x => x > 1).SingleOrDefault(); // error
            return View();
        }
    }
}