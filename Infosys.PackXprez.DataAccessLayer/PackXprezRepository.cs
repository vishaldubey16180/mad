using Infosys.PackXprez.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;


namespace Infosys.PackXprez.DataAccessLayer
{
    public class PackXprezRepository
    {
        public PackXprezDBContext Context { get; set; }

        public PackXprezRepository()
        {
            Context = new PackXprezDBContext();
        }

        //Customer registration DAL
        public bool RegisterCustomer(Customer custobj)
        {
            bool status = false;
            try
            {
                Context.Customer.Add(custobj);
                Context.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            return status;
        }

        public Customer CustomerLogin(string emailId, string password)
        {
            Customer obj1 = new Customer();
            try
            {
                obj1 = (from b in Context.Customer
                        where b.CustEmailId == emailId && b.Password == password
                        select b).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                obj1 = null;
            }
            return obj1;
        }


        public bool ServiceAvailability(int pincode)
        {
            bool status = false;
            List<AvailableDeliveryPickup> lstAvailableDeliveryPickup = new List<AvailableDeliveryPickup>();
            try
            {
                lstAvailableDeliveryPickup = (from t1 in Context.AvailableDeliveryPickup where t1.Pincode == pincode select t1).ToList();
                if (lstAvailableDeliveryPickup.Count() == 1)
                {
                    Console.WriteLine(lstAvailableDeliveryPickup.Count());
                    status = true;
                    // return status;
                }
                else
                {
                    status = false;
                    // return status;
                }
            }
            catch (Exception ex)
            {
                status = false;
                lstAvailableDeliveryPickup = null;
                Console.WriteLine(ex.Message);
            }
            return status;
        }

        public bool AddFeedback(FeedBack fObj)
        {
            bool status = false;
            FeedBack fb = new FeedBack();
            fb.EmailId = fObj.EmailId;
            fb.FeedbackType = fObj.FeedbackType;
            fb.Comments = fObj.Comments;
            try
            {
                Context.FeedBack.Add(fb);
                Context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                Console.WriteLine(ex.Message);
            }
            return status;
        }


        //Update Customer Details DAL
        public bool UpdateCustomerDetails(Customer cobj)
        {
            Customer tempobj = new Customer();
            bool status = false;
            try
            {
                tempobj = (from c in Context.Customer
                           where cobj.CustEmailId == c.CustEmailId
                           select c).FirstOrDefault();
                if (tempobj != null)
                {
                    //Console.WriteLine("Not null");
                    tempobj.CustName = cobj.CustName;
                    tempobj.Password = cobj.Password;
                    tempobj.ContactNo = cobj.ContactNo;

                    Context.Customer.Update(tempobj);
                    Context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            return status;
        }
        //Add address in DB DAL
        public bool AddAddressindb(Address aobj)
        {
            bool status = false;
            try
            {
                Context.Address.Add(aobj);
                Context.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            return status;
        }
        //Delete Address from DB DAL
        public bool DeleteAddressindb(string address)
        {
            bool status = false;
            try
            {
                var tempaddobj = (from a in Context.Address
                                  where address == a.Address1
                                  select a).FirstOrDefault();
                Context.Address.Remove(tempaddobj);
                Context.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        //BranchOfficer Officer Login
        public BranchOfficer BranchOfficerLogin(string emailId, string password)
        {
            BranchOfficer obj1 = new BranchOfficer();
            try
            {
                obj1 = (from b in Context.BranchOfficer
                        where b.BoemailId == emailId && b.Password == password
                        select b).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                obj1 = null;
            }
            return obj1;
        }

        public List<ScheduledPickUp> GetPackageDetailsByLocation(string city)
        {
            List<ScheduledPickUp> pickupList = null;
            try
            {
                pickupList = (from ps in Context.ScheduledPickUp
                              join adp in Context.AvailableDeliveryPickup on ps.PickupPinCode equals
                                adp.Pincode
                              where adp.City == city
                              select ps).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                pickupList = null;

            }
            return pickupList;
        }

        public bool InsertDataIntoReceivePackage(ReceivePackage robj)
        {


            ReceivePackage fb = new ReceivePackage();
            //fb.AwbNumber = robj.AwbNumber;
            fb.CustomerName = robj.CustomerName;
            fb.FromLocation = robj.FromLocation;
            fb.ToAddress = robj.ToAddress;
            fb.UpdatedStatus = robj.UpdatedStatus;
            bool status = false;
            try
            {
                Context.ReceivePackage.Add(fb);

                Context.SaveChanges();
                status = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            return status;
        }


        public bool UpdateScheduledPickup(string emailId)
        {
            ScheduledPickUp tempobj = new ScheduledPickUp();
            bool status = false;
            //long num;
            try
            {
                tempobj = Context.ScheduledPickUp
                             .Where(x => x.EmailId == emailId)
                             .FirstOrDefault();
                if (tempobj != null)
                {
                    //Console.WriteLine("Not null");
                    tempobj.AwbNumber = (from db in Context.ReceivePackage where db.CustomerName == tempobj.Name select db.AwbNumber).FirstOrDefault();
                    //tempobj.AwbNumber = 100007;

                    Context.ScheduledPickUp.Update(tempobj);
                    status = true;

                    Context.SaveChanges();
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            return status;
        }

        public bool UpdateOrders(string emailId)
        {
            Orders tempobj = new Orders();
            bool status = false;
            //long num;
            try
            {
                tempobj = Context.Orders
                             .Where(x => x.EmailId == emailId)
                             .FirstOrDefault();
                if (tempobj != null)
                {
                    //Console.WriteLine("Not null");
                    tempobj.AwbNumber = (from db in Context.ReceivePackage where db.CustomerName == tempobj.Name select db.AwbNumber).FirstOrDefault();
                    //tempobj.AwbNumber = 100007;
                    tempobj.Status = "Shipped";
                    Context.Orders.Update(tempobj);
                    status = true;

                    Context.SaveChanges();
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            return status;
        }


        public bool UpdateOrders2(string emailId)
        {
            Orders tempobj = new Orders();
            bool status = false;
            //long num;
            try
            {
                tempobj = Context.Orders
                             .Where(x => x.EmailId == emailId)
                             .FirstOrDefault();
                if (tempobj != null)
                {
                    //Console.WriteLine("Not null");
                    //tempobj.AwbNumber = (from db in Context.ReceivePackage where db.CustomerName == tempobj.Name select db.AwbNumber).FirstOrDefault();
                    //tempobj.AwbNumber = 100007;
                    tempobj.Status = "Delivered";
                    Context.Orders.Update(tempobj);
                    status = true;

                    Context.SaveChanges();
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                status = false;
            }
            return status;
        }
    }
}
