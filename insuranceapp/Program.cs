using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using insuranceBO_lib.BO;
using insuranceBO_lib.models;

namespace insuranceapp
{
   public class Program
    {
        public  static void Main(string[] args)
        {
           
            while (true)
            {
                Console.WriteLine("1.Add Customers");
                Console.WriteLine("2.View All Customers");
                Console.WriteLine("3.Update Customers");
                Console.WriteLine("4.Create Policy");
                Console.WriteLine("5.Get Policies");
                Console.WriteLine("6.Delete Policy");
                Console.WriteLine("7.Update Policy");
                Console.WriteLine("8.Submit Claim");
                Console.WriteLine("9.Get Claim Details");
                Console.WriteLine("10.Process claim");
                Console.WriteLine("11.Register User");
                Console.WriteLine("12.Login USer");
                Console.WriteLine("13.Get user Profile");
                //Console.WriteLine("14.Calculate Premium");
                Console.WriteLine("14.Exit");
                
               int option = Convert.ToInt32(Console.ReadLine());
               switch(option)
                {
                    case 1:
                        Console.WriteLine(" Wish to Enter the Customer details? Press Y");
                        string ans=Console.ReadLine();
                        while (ans.ToUpper()[0]=='Y')
                        {
                            Console.WriteLine("Enter Name, email, Phone and Address");
                            insuranceBO_lib.models.Customer c=new insuranceBO_lib.models.Customer()
                            {
                                //CustomerId=Convert.ToInt32(Console.ReadLine()),
                                Name=Console.ReadLine(),
                                Email=Console.ReadLine(),   
                                Phone=Console.ReadLine(),   
                                Address=Console.ReadLine(),
                            };
                            CustomerBO.AddCustomer(c);
                            Console.WriteLine("Wish to add more customer details? Press Y");
                            ans= Console.ReadLine();    
                        }
                        break;
                    case 2:
                        CustomerBO.ViewCustomers();
                        break;
                    case 3:
                        Console.WriteLine("Enter valid Customer Id, for update");
                        string id=Console.ReadLine();
                        CustomerBO.UpdateCustomer(id);
                        break;
                    case 4:
                        Console.WriteLine(" Wish to Create a new Policy ? Press Y");
                        string pa = Console.ReadLine();
                        while (pa.ToUpper()[0] == 'Y')
                        {
                            Console.WriteLine("Enter PolicyType, CoverageAmount, PremiumAmount, ValidityStartDAte, ValidityEndDate");
                            insuranceBO_lib.models.Policy p = new insuranceBO_lib.models.Policy()
                            {
                                //CustomerId=Convert.ToInt32(Console.ReadLine()),
                                PolicyType = Console.ReadLine(),
                                CoverageAmount = Console.ReadLine(),
                                PremiumAmount = Console.ReadLine(),
                                ValidityStartDate = Console.ReadLine(),
                                ValidityEndDate = Console.ReadLine(),
                            };
                            PolicyBO.CreatePolicy(p);
                            Console.WriteLine("Wish to Create more policies ? Press Y");
                            pa = Console.ReadLine();
                        }
                        break;
                    case 5:
                        PolicyBO.ViewPolicy();
                        break;
                    case 6:
                        Console.WriteLine("Enter valid policyId");
                        string id1=Console.ReadLine();
                       PolicyBO.RemovePolicy(id1);
                        break;
                    case 7:
                        Console.WriteLine("Ente valid policyId for update");
                        string id2=Console.ReadLine();
                        PolicyBO.UpdatePolicy(id2);
                        break;
                    case 8:
                        Console.WriteLine(" Wish to Enter the Claim details? Press Y");
                        string cres = Console.ReadLine();
                        while (cres.ToUpper()[0] == 'Y')
                        {
                            Console.WriteLine("Enter policyId, claimAmount, claimStatus, submissionDate and settlementDate");
                            insuranceBO_lib.models.Claim c = new insuranceBO_lib.models.Claim()
                            {
                                PolicyId=Convert.ToInt32(Console.ReadLine()),
                                
                                ClaimAmount=Convert.ToInt32(Console.ReadLine()),
                                ClaimStatus = Console.ReadLine(),
                                //SubmissionDate = DateTime.TryParse(Console.ReadLine(), out DateTime submissionDate) ? submissionDate : throw new ArgumentException("Invalid date"),
                                SubmissionDate=Console.ReadLine(),  
                                SettlementDate = Console.ReadLine(),
                            };
                            ClaimBO.SubmitClaim(c);
                            Console.WriteLine("Wish to add more claim details? Press Y");
                            cres= Console.ReadLine();
                        }
                        break;
                    case 9:
                        ClaimBO.getClaimDetails();
                        break;
                    case 10:
                        Console.WriteLine("Enter valid Claim Id, for Processing claim");
                        string id3 = Console.ReadLine();
                        ClaimBO.ProcessClaim(id3);
                        break;
                    case 11:
                        Console.WriteLine(" Wish to Register the New User? Press Y");
                        string Ures = Console.ReadLine();
                        while (Ures.ToUpper()[0] == 'Y')
                        {
                            Console.WriteLine("Enter UserName,Password and Role");
                            insuranceBO_lib.models.User u = new insuranceBO_lib.models.User()
                            {
                               UserName=Console.ReadLine(),
                               Password=Console.ReadLine(),
                               Role=Console.ReadLine(),
                            };
                            UserBO.RegisterUser(u);
                            Console.WriteLine("Wish to register more users? Press Y");
                            cres = Console.ReadLine();
                        }
                        break;
                    case 12:
                        Console.WriteLine("Enter UserName");
                        string uname = Console.ReadLine();
                        Console.WriteLine("Enter Password: ");
                        string pass = Console.ReadLine();
                        UserBO.LoginUser(uname, pass);
                        break;
                    case 13:
                        UserBO.getUserProfile();
                        break;
                    //case 14:
                      //  break;
                    case 14:
                        Console.WriteLine("Terminating...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter the  correct option");
                        break;
                }
            }
        }
    }
}
