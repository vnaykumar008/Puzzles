using System;
using System.Linq.Expressions;
using System.Linq;
using System.Linq.Expressions.Internal;
using System.Reflection;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Data;
using System.Threading;
using System.Diagnostics;

namespace PlayerPassCount
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test UnitOfWork concept

            Test1232DbContext dbContext = new Test1232DbContext();
            UnitOfWork unitOfWork = new UnitOfWork(dbContext);

            var a = unitOfWork.GetRepo<Employee>().GetAll().Select(p => p.Salary);

            foreach (Employee employee in unitOfWork.GetRepo<Employee>().GetAll())
            {
                Console.WriteLine(employee.Salary);
            }
            unitOfWork.GetRepo<Employee>().Delete(1);

            unitOfWork.GetRepo<Order>().Insert(new Order { Id = 2, Item = "dgads" });
            unitOfWork.GetRepo<Order>().Insert(new Order { Id = 3, Item = "dgads" });
            unitOfWork.GetRepo<Order>().Delete(2);
            unitOfWork.Save();

            #endregion

            #region Recursive test

            ReverseParagraph reversePara = new ReverseParagraph(@"Vinay Kumar nadiminti");
            Console.WriteLine(reversePara.GetReverseParagraph());

            RecursiveExample recObj = new RecursiveExample();
            Console.WriteLine(recObj.Getfactorial(5));
            recObj.GetFilesAndFoldersInsideTheDiretory(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));

            #endregion

            #region Player pass count test

            Console.WriteLine("Number of Passes: {0}.", PlayerPassCount.PassCount(5, 3, 2));
            Console.ReadKey();

            #endregion
        }

        public static IEnumerable<A> GetEnumerableData()
        {
            using (DataTable dt1 = new DataTable())
            {
                dt1.Columns.Add("Col1");
                dt1.Columns.Add("Col2");
                dt1.Columns.Add("Col3");
                dt1.Columns.Add("Col4");
                for (int j = 0; j < 2000000; j++)
                {
                    dt1.Rows.Add("Col", 1, 12.12, false);
                }

                using (IDataReader reader = dt1.CreateDataReader())
                {
                    A vari;
                    while (reader.Read())
                    {
                        vari = new A()
                                 {
                                     a = (string)reader[0],
                                     b = Convert.ToInt32(reader[1].ToString()),
                                     c = Convert.ToDouble(reader[2].ToString()),
                                     d = Convert.ToBoolean(reader[3].ToString())
                                 };

                        yield return vari;
                    }

                }
            }
        }
    }

    class MyStruct
    {
        public virtual void MyMethod()
        {
            Console.WriteLine("Base Class");
        }

    }
    class M : MyStruct
    {

        public void MyMethod()
        {
            Console.WriteLine("Derived Class");
        }
    }

    class A
    {
        public string a { get; set; }
        public int b { get; set; }
        public double c { get; set; }
        public bool d { get; set; }
    }
}



