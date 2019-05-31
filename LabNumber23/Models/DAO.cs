using LabNumber21Take2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabNumber21Take2.Models
{
    public class DAO
    {
        private static ShopDBEntities ORM = new ShopDBEntities();

        public static List<Item> GetItemsAsList()
        {
            return ORM.Items.ToList();
        }

        public static List<Item> SearchNames(string queryString)
        {
            return ORM.Items.ToList().FindAll(x => x.Name.ToUpper().Contains(queryString.ToUpper())).ToList();
        }

        public static bool AddItem(Item addMe)
        {
            bool success;
            Item found = ORM.Items.ToList().Find(x => x.Name.ToUpper() == addMe.Name.ToUpper());
            if (found == null)
            {
                ORM.Items.Add(addMe);
                ORM.SaveChanges();
                success = true;
            }
            else
            {
                success = false;
            }
            return success;

        }

        public static Item FindItem(int ItemId)
        {
            return ORM.Items.Find(ItemId);
        }

        public static void EditItem(Item editMe)
        {
            Item original = ORM.Items.Find(editMe.Id);
            original.Name = editMe.Name;
            original.Description = editMe.Description;
            original.Quantity = editMe.Quantity;
            original.Price = editMe.Price;
            ORM.SaveChanges();
        }

        public static void DeleteItem(int ItemId)
        {
            Item deleteMe = ORM.Items.Find(ItemId);
            ORM.Items.Remove(deleteMe);
            ORM.SaveChanges();
        }

        public static void AddUserToDb(User newUser)
        {
            ORM.Users.Add(newUser);
            ORM.SaveChanges();
        }

        public static User FindUserExists(UserLogin thisUser)
        {
            return ORM.Users.ToList().Find(x => x.Email == thisUser.Email && x.Password == thisUser.Password);
        }


    }
}