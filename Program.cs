using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Bank_Application
{
    public class AccLimitExceeded : Exception
    {
        public AccLimitExceeded() : base()
        {
            Console.WriteLine("Daily Limit Exceeded\n\n");
        }
    }
    public delegate int deposit(int amt);
    public delegate void withdraw();

    public class Bank
    {
        public string accname { get; set; }
        public string gender { get; set; }
        public int accid { get; set; }
        public int age { get; set; }
        public int deposit { get; set; }
        public int depo;

        List<Bank> cu = new List<Bank>();
        public ArrayList a = new ArrayList();

        public void accinfo()
        {
            Bank c1 = new Bank()
            {
                accid = 010,
                accname = "Amit",
                gender = "M",
                age = 30,
            };
            Bank c2 = new Bank()
            {
                accid = 011,
                accname = "Banu",
                gender = "F",
                age = 28,
            };
            Bank c3 = new Bank()
            {

                accid = 012,
                accname = "Chan",
                gender = "M",
                age = 30,

            };
            Bank c4 = new Bank()
            {
                accid = 013,
                accname = "Davi",
                gender = "M",
                age = 35,

            };
            Bank c5 = new Bank()
            {
                accid = 014,
                accname = "Anoo",
                gender = "F",
                age = 30,
            };
            cu.Add(c1);
            cu.Add(c2);
            cu.Add(c3);
            cu.Add(c4);
            cu.Add(c5);
            Console.WriteLine("Enter Account ID:");
            accid = Convert.ToInt32(Console.ReadLine());
            if (accid == 010)
            {
                accname = c1.accname;
                gender = c1.gender;
                age = c1.age;
            }
            else if (accid == 011)
            {
                accname = c2.accname;
                gender = c2.gender;
                age = c2.age;

            }
            else if (accid == 012)
            {
                accname = c3.accname;
                gender = c3.gender;
                age = c3.age;

            }
            else if (accid == 013)
            {
                accname = c4.accname;
                gender = c4.gender;
                age = c4.age;

            }
            else if (accid == 014)
            {
                accname = c5.accname;
                gender = c5.gender;
                age = c5.age;

            }
            else
            {
                Console.WriteLine("Account Does not exist");
                accinfo();
            }

        }
        public void dispinfo()
        {
            Console.WriteLine("\nAccount ID: {0}\nAccount Name: {1}\n", accid, accname);

        }
        public void td(int depo)
        {
            if (accid == 010)
                cu[0].deposit = depo;
            else if (accid == 011)
                cu[1].deposit = depo;
            else if (accid == 012)
                cu[2].deposit = depo;
            else if (accid == 013)
                cu[3].deposit = depo;
            else
                cu[4].deposit = depo;

        }
        public void display()
        {
            string f1= "C:/Users/adminvm.adminvm/source/repos/Bank_Application/f1.txt";
            string name, gender, id, age, bal;
            StreamWriter sw = new StreamWriter(f1);
            sw.WriteLine(" Acc no.   Name    Age   Gender   Balance");
            sw.WriteLine("-----------------------------------------");
            for (int i = 0; i <= 4; i++)
            {
                id = cu[i].accid.ToString();
                name = cu[i].accname;
                age = cu[i].age.ToString();
                gender = cu[i].gender;
                bal = cu[i].deposit.ToString();
                sw.Write("  " + id + "      ");
                sw.Write(name + "      ");
                sw.Write(age + "      ");
                sw.Write(gender + "      ");
                sw.Write(bal);
                sw.WriteLine();
            }
            sw.WriteLine(cu);
            sw.Flush();
            sw.Close();
            Console.WriteLine("============================================");
            Console.WriteLine(" Acc no.|| Name || Age || Gender || Balance");
            Console.WriteLine("============================================");
            for (int i= 0;i<= 4;i++)
            {
                Console.WriteLine("   " + cu[i].accid + "     " + cu[i].accname + "     " + cu[i].age + "      " + cu[i].gender + "         " +cu[i].deposit);
            }
        }
    }
    class Account : Bank
    {
        public int c, amt, prev = 0, dep = 0, m, d, co = 0;
        bool b = true;
        public int amount(int amt)
        {
            prev = amt;
            dep = dep + prev;
            Console.WriteLine("Total Deposit: " + dep + "\n");
            return dep;
        }


        public void withdraw()
        {
            if (co >= 3)
            {

                Console.WriteLine("Withdraw limit exceeded\n");
                d = amount(-500);
                return;
            }
            else
            {
                Console.WriteLine("Enter money to withdraw");
                m = Convert.ToInt32(Console.ReadLine());
                if (m > dep)
                {
                    Console.WriteLine("Insufficient Balance\n");
                    return;
                }
                dep = amount(-m);
                ++co;

            }

        }
        public void openacc()
        {
            while (b == true)
            {
                Console.WriteLine("===Welcome to Bank===");
                Console.WriteLine("Choose type of Account\n 1.Savings\n 2.Current\n 3.Child\n 4.Withdraw\n 5.Logout\n 6.Exit\n");
                c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        Console.WriteLine("Opening Savings Account");
                        Console.WriteLine("Enter Amount, Max limit: 100000");
                        amt = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            if (amt > 100000)
                            {
                                throw new AccLimitExceeded();
                            }
                            else
                            {
                                dispinfo();
                                Console.WriteLine("Amount Deposited: " + amt + "\n");
                                amount(amt);

                            }
                        }
                        catch (AccLimitExceeded)
                        {

                        }
                        break;
                    case 2:
                        Console.WriteLine("Opening Current Account");
                        Console.WriteLine("Enter Amount, Max limit: 200000");
                        amt = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            if (amt > 200000)
                            {
                                throw new AccLimitExceeded();
                            }
                            else
                            {
                                dispinfo();
                                Console.WriteLine("Amount Deposited: " + amt + "\n");
                                amount(amt);


                            }
                        }
                        catch (AccLimitExceeded)
                        {

                        }
                        break;
                    case 3:
                        Console.WriteLine("Opening ChildCare Account");
                        Console.WriteLine("Enter Amount, Max limit: 50000");
                        amt = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            if (amt > 50000)
                            {
                                throw new AccLimitExceeded();
                            }
                            else
                            {
                                dispinfo();
                                Console.WriteLine("Amount Deposited: " + amt + "\n");
                                amount(amt);

                            }
                        }
                        catch (AccLimitExceeded)
                        {
                            Console.WriteLine("Daily Limit Exceeded\n\n");
                        }
                        break;
                    case 4:
                        withdraw();
                        break;
                    case 5:
                        depo = amount(0);
                        td(depo);
                        dep = 0;
                        co = 0;
                        accinfo();
                        break;
                    case 6:
                        b = false;
                        amt = 0;
                        prev = 0;
                        depo = amount(0);
                        td(depo);
                        display();
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Option does not exist");
                        break;
                }
            }
        }

    }



    class Program
    {
        static void Main(string[] args)
        {

            Account a = new Account();
            a.accinfo();
            a.openacc();


            Console.ReadKey();
        }
    }
}
