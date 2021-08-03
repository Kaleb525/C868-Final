using C868;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Xunit;


namespace C868.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void Updatecustomerinfo()
        {
            
            var expectedName = "John Smith";
            var expectedphone = "1234567890";
            var expectedaddress = "1 fifth ave";
            var expectedcity = "New York";
            var expectedzip = "11111";
            var expectedcountry = "United States";
            int editsuccess = 1;

            UpdateCustomer form = new UpdateCustomer();
            var createcontrol = form.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createcontrol.Invoke(form, new object[] { true });

            int actualResults = form.Updatecustomer(expectedName, expectedphone, expectedaddress, expectedcity, expectedzip, expectedcountry);

            Assert.Equal(editsuccess, actualResults);
        }

        [Fact]
        public void addcustomer()
        {
            var expectedName = "John Smith";
            var expectedphone = "1234567890";
            var expectedaddress = "1 fifth ave";
            var expectedcity = "New York";
            var expectedzip = "11111";
            var expectedcountry = "United States";
            int editsuccess = 1;

            CreateCustomer form = new CreateCustomer();
            var createcontrol = form.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createcontrol.Invoke(form, new object[] { true });

            int actualResults = form.AddCustomer(expectedName, expectedphone, expectedaddress, expectedcity, expectedzip, expectedcountry);

            Assert.Equal(editsuccess, actualResults);
        }

        [Fact]
        public void deletecustomer()
        {
            var expectedName = "John Smith";
            var expectedphone = "1234567890";
            var expectedaddress = "1 fifth ave";
            var expectedcity = "New York";
            var expectedzip = "11111";
            var expectedcountry = "United States";
            int editsuccess = 1;

            DeleteCustomer form = new DeleteCustomer();
            var createcontrol = form.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            createcontrol.Invoke(form, new object[] { true });

            int actualResults = form.Deletecustomer(expectedName, expectedphone, expectedaddress, expectedcity, expectedzip, expectedcountry);

            Assert.Equal(editsuccess, actualResults);
        }
    }
}