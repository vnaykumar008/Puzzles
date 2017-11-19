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
        static void Main()
        {


            Console.WriteLine("Starting: " + DateTime.Now.ToString("hh:mm:ss"));
            IList<A> vari;
            //for (int i = 0; i < 10; i++)
            //{
            //DataTable dt1 = new DataTable();
            //using (DataTable dt1 = new DataTable())
            //{
            //    dt1.Columns.Add("Col1");
            //    dt1.Columns.Add("Col2");
            //    dt1.Columns.Add("Col3");
            //    dt1.Columns.Add("Col4");
            //    for (int j = 0; j < 2; j++)
            //    {
            //        dt1.Rows.Add("Col", 1, 12.12, false);
            //    }
            //    Console.WriteLine("fasdfa: " + DateTime.Now.ToString("hh:mm:ss"));
            //    vari = (from aa in dt1.AsEnumerable()
            //            select new A() { a = (string)aa[0], b = Convert.ToInt32(aa[1].ToString()), c = Convert.ToDouble(aa[2].ToString()), d = Convert.ToBoolean(aa[3].ToString()) }).ToList();
            //    Console.WriteLine("sdfsd: " + DateTime.Now.ToString("hh:mm:ss"));
            //}

            foreach (A va in GetEnumerableData())
            {
                string aa = va.a;
                int ba = va.b;
                double ca = va.c;
                bool da = va.d;
            }
            Console.WriteLine("Ending: " + DateTime.Now.ToString("hh:mm:ss"));
            Console.WriteLine("Starting: " + DateTime.Now.ToString("hh:mm:ss"));
            //DataTable dt2 = new DataTable();
            using (DataTable dt2 = new DataTable())
            {
                dt2.Columns.Add("Col1");
                dt2.Columns.Add("Col2");
                dt2.Columns.Add("Col3");
                dt2.Columns.Add("Col4");
                for (int j = 0; j < 2000000; j++)
                {
                    dt2.Rows.Add("Col", "1", "12.12", "false");
                }
                using (IDataReader reader = dt2.CreateDataReader())
                {
                    while (reader.Read())
                    {
                        string aa = (string)reader["Col1"];
                        int ba = Convert.ToInt32(reader["Col2"]);
                        double ca = Convert.ToDouble(reader["Col3"]);
                        bool da = Convert.ToBoolean(reader["Col4"]);
                    }
                }
            }
            Console.WriteLine("Ending: " + DateTime.Now.ToString("hh:mm:ss"));
            //DataTable dt3 = new DataTable();
            using (DataTable dt3 = new DataTable())
            {
                dt3.Columns.Add("Col");
                for (int j = 0; j < 500000; j++)
                {
                    dt3.Rows.Add("Col");
                }
            }
            //DataTable dt4 = new DataTable();
            using (DataTable dt4 = new DataTable())
            {
                dt4.Columns.Add("Col");
                for (int j = 0; j < 500000; j++)
                {
                    dt4.Rows.Add("Col");
                }
            }
            //DataTable dt6 = new DataTable();
            using (DataTable dt6 = new DataTable())
            {
                dt6.Columns.Add("Col");
                for (int j = 0; j < 500000; j++)
                {
                    dt6.Rows.Add("Col");
                }
            }


            //}



            #region Memory collectionTesting

            /*
            Dictionary<int, List<string>> dd = new Dictionary<int, List<string>>();
            List<string> temp1 = new List<string>();
            temp1.Add("a");
            temp1.Add("d");
            temp1.Add("g");
            List<string> temp2 = new List<string>();
            temp2.Add("b");
            temp2.Add("e");
            temp2.Add("h");
            temp2.Add("j");
            List<string> temp3 = new List<string>();
            temp3.Add("c");
            temp3.Add("f");
            temp3.Add("i");
            temp3.Add("k");
            temp3.Add("l");
            dd.Add(0, temp1);
            dd.Add(1, temp2);
            dd.Add(2, temp3);

            List<string> result = new List<string>();
            bool isExit = false;
            int i = 0;
            while (!isExit)
            {
                int exitCount = 0;
                for (int j = 0; j < dd.Count;j++)
                {
                    if (dd[j].Count > i)
                    {
                        result.Add(dd[j][i]);
                    }
                    else
                    {
                        exitCount++;
                    }
                }                                    
                i++;
                if(dd.Count == exitCount)
                {
                    isExit = true;
                }
            }
            Console.WriteLine(string.Join(",", result));*/

            long memory = GC.GetTotalMemory(true);
            Console.WriteLine(memory);
            Process currentProc = Process.GetCurrentProcess();
            long memoryUsed = currentProc.PrivateMemorySize64;
            Console.WriteLine(memoryUsed);
            Console.Read();


            //List<A> obj = new List<A>();

            //obj.Add(new A() { a = "1" });
            //obj.Add(new A() { a = "2" });

            //for(int i=0;i<obj.Count;i++)
            //{
            //    obj.Remove(obj[i]);
            //}
            #endregion
        }

        #region another main
        //static void Main(string[] args)
        //{
        //    Test1232DbContext dbContext = new Test1232DbContext();
        //    UnitOfWork unitOfWork = new UnitOfWork(dbContext);

        //    var a = unitOfWork.GetRepo<Employee>().GetAll().Select(p => p.Salary);

        //     foreach(Employee employee in unitOfWork.GetRepo<Employee>().GetAll())
        //    {
        //        Console.WriteLine(employee.Salary);
        //    }
        //    unitOfWork.GetRepo<Employee>().Delete(1);

        //    unitOfWork.GetRepo<Order>().Insert(new Order { Id = 2, Item = "dgads" });
        //    unitOfWork.GetRepo<Order>().Insert(new Order { Id = 3, Item = "dgads" });
        //    unitOfWork.GetRepo<Order>().Delete(2);
        //    unitOfWork.Save();

        //    M m = new M();
        //    m.MyMethod();

        //    ReverseParagraph reversePara = new ReverseParagraph(@"Vinay Kumar nadiminti");
        //    Console.WriteLine(reversePara.GetReverseParagraph());

        //    RecursiveExample recObj = new RecursiveExample();
        //    Console.WriteLine(recObj.Getfactorial(5));
        //    recObj.GetFilesAndFoldersInsideTheDiretory(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));

        //    Console.WriteLine("Number of Passes: {0}.", CandidateCode.PassCount(5, 3, 2));
        //    Console.ReadKey();

        //}
        #endregion

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


public class CandidateCode
{
    public static int PassCount(int playersCount, int maxPasses, int shiftLeftOrRightCount)
    {
        int passCount = 0;
        int i = 0;
        int[] playerPassCount = new int[playersCount];

        playerPassCount[i] = 1;
        while (!playerPassCount.Any(p => p == maxPasses))
        {
            if (playerPassCount[i] % 2 == 0)
            {
                i = (((i - shiftLeftOrRightCount) % playersCount) + playersCount) % playersCount;
            }
            else
            {
                i = (i + shiftLeftOrRightCount) % playersCount;
            }

            playerPassCount[i]++;
            passCount++;
        }

        return passCount;
    }
}




