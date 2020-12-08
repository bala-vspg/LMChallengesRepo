using Microsoft.VisualStudio.TestTools.UnitTesting;
using LMIChallengesCollection;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using FluentAssertions;
using System.Linq;

namespace LMIChallengesCollection.Tests
{
    [TestClass()]
    public class CustomerTests
    {
        [TestMethod()]
        public void calculateBillTest()
        {
            Mock<IItem> item = new Mock<IItem>();
            int k = 0;
            item.Setup(x => x.getPrice(It.IsAny<string>())).Returns(1);

            List<IItem> items = new List<IItem>();

            for (int i = 0; i < 10; i++)

            {

                items.Add(item.Object);

            }

            Customer cust = new Customer();
            int c = k;

            cust.setListOfItems(items);
            Assert.AreEqual(cust.calculateBill(), 10);

        }

        
    }

}
    
