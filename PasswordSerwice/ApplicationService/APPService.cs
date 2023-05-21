using PasswordSerwice.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordSerwice.ApplicationService
{
    internal class APPService
    {
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
      
        public void AddUser(string nameU, string passwordU)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                try
                {
                    User user = new User() { Login = nameU, Password = CreateMD5(passwordU) };
                    Credential crd = new Credential() { Login = nameU, Password = passwordU, User = user };
                    db.users.Add(user);
                    db.credential.Add(crd);
                    db.SaveChanges();

                } catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

       
        public void AddSrevice(string name, string description)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Service serv = new Service() { Name = name, Description = description };
                db.services.Add(serv);
                db.SaveChanges();
            }
        }
        public void RemoveUser(string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User u = db.users.FirstOrDefault(us => us.Login == name);
                if(u != null)
                {
                    Credential crd = db.credential.FirstOrDefault(us => us.Login == name);
                    db.users.Remove(u);
                    db.credential.Remove(crd);
                    db.SaveChanges();
                    db.Database.Connection.Close();
                }
            }
        }
        public void RemoveService(string Sname)
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                Service sr = db.services.FirstOrDefault(s=>s.Name == Sname);
                db.services.Remove(sr);
                db.SaveChanges();
                db.Database.Connection.Close();
            }
        }
        
        public void CredentialAddServec(Credential crd, string servName)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Service ser = db.services.FirstOrDefault(s => s.Name == servName);
                if(ser == null)
                {
                    ser = new Service() { Name = servName, Description="Default" };
                    db.services.Add(ser);
                    crd.Service = ser;
                    
                    db.SaveChanges();
                    db.Database.Connection.Close();
                }
                else
                {
                    crd.Service = ser;

                    db.SaveChanges();
                    db.Database.Connection.Close();
                }

            }
        }
        public bool Validator(string user, string password)
        {
            using (ApplicationContext db = new ApplicationContext()) {

            Credential u = db.credential.FirstOrDefault(us => us.User.Login == user);
                if (u != null)
                {
                    if (password == u.Password)
                    {
                        db.Database.Connection.Close();
                        return true;

                        
                    }
                    else
                    {
                        db.Database.Connection.Close();
                        return false;
                    }
                }
                else
                {
                    db.Database.Connection.Close();
                    return false;
                }
               
            }
        }
        public bool PasswordChanger(string user, string pasword,string newpassword)
        {
           if( Validator(user, pasword))
            {
                using (ApplicationContext db = new ApplicationContext()) {
                    Credential crd = db.credential.FirstOrDefault(us => us.User.Login == user);
                    crd.Password = newpassword;
                    User u = db.users.FirstOrDefault(us => us.Login == user);
                    u.Password = CreateMD5(newpassword);
                return true; 
                }
            }
            return false;
        }

    }
}
