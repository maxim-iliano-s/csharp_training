﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW_WebAddressbookTests
{
    [TestFixture]

    public class HW_ContactModificationTests : HW_AuthTestBase
    {
        [Test]

        public void HW_ContactModificationTest()
        {
            ContactData newCont = new ContactData("Modified First name", "Modified Last name");
            newCont.Middlename = "Stepanovich";
            newCont.Nickname = "Kolodynski";
            newCont.Title = "Kozak";
            newCont.Company = "Zaporozhskaya Siczh";
            newCont.Address = "Dnepro, Zaporozhskaya Siczh";
            newCont.HomeTel = "5-12-25";
            newCont.MobileTel = "5-12-25";
            newCont.E_mail = "ataman@paper.org";
            newCont.Bday = "20";
            newCont.Bmonth = "March";
            newCont.Byear = "1639";
            newCont.Notes = "He played an important role in the Battle of Poltava";

            if (!appMan.Contact.IsContactTrue())
            {
                //if (!appMan.Contact.IsContactTrue())
                //{
                    ContactData contact = new ContactData("Empty", "Contact");
                    appMan.Contact.Create(contact);
                //}
            }

            var indx = 0;
            List<ContactData> oldContacts = appMan.Contact.GetContactList();
            appMan.Contact.Modify(newCont);
            List<ContactData> newContacts = appMan.Contact.GetContactList();
            oldContacts[indx].Firstname = newCont.Firstname;
            oldContacts[indx].Lastname = newCont.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}