using Microsoft.VisualStudio.TestTools.UnitTesting;
using LMIChallengesCollection;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp.Extensions;

namespace LMIChallengesCollection.Tests
{
    [TestClass()]
    public class ApiCallerTests
    {
        [TestMethod()]
        // Testing happy path to see if the api returns all users data
        public void getDataTest_forAllUsers()
        {
            ApiCaller caller = new ApiCaller();
            var response = caller.getData();
            response.Content.Should().NotBeNullOrEmpty();

        }


        [TestMethod()]
        //Testing happy path to see if the api returns single user data
        public void getDataTest_forSingleUser()
        {
            ApiCaller caller = new ApiCaller();
            var response = caller.getSingleUserData(3);
            response.Content.Should().NotBeNullOrEmpty();

        }


        [TestMethod()]
        //Testing to see if the api returns if non existing user id is passed
        public void getDataTest_forNonExistingUserId()
        {
            ApiCaller caller = new ApiCaller();
            var response = caller.getSingleUserData(30);
            response.StatusCode.Should().Be(404);

        }

        [TestMethod()]
        //Testing post operation with complete request body
        public void postDataTest_withCompleteRequestBody()
        {
            ApiCaller caller = new ApiCaller();
            var response = caller.postData(new ApiCaller.userData { name = "darth vader", job = "villain" });
            response.StatusCode.Should().Be(201);
            
            var responseContent = JsonConvert.DeserializeObject<insertResponseModel>(response.Content.ToString());
            response.Content.Should().NotBeNullOrEmpty();
            responseContent.name.Should().Be("darth vader");
            responseContent.job.Should().Be("villain");
            
        }

        [TestMethod()]
        //Testing post operation with partial request body
        public void postDataTest_withPartialRequestBody()
        {
            ApiCaller caller = new ApiCaller();
            var response = caller.postData(new ApiCaller.userData { name = "darth vader"});
            response.StatusCode.Should().Be(201);

            var responseContent = JsonConvert.DeserializeObject<insertResponseModel>(response.Content.ToString());
            response.Content.Should().NotBeNullOrEmpty();
            responseContent.name.Should().Be("darth vader");
          

        }

        [TestMethod()]
        //Testing post operation with empty request body
        public void postDataTest_withEmptyRequestBody()
        {
            ApiCaller caller = new ApiCaller();
            var response = caller.postData(new ApiCaller.userData { });
            response.StatusCode.Should().Be(201);
            response.Content.Should().NotBeNullOrEmpty();
        
        }

        [TestMethod()]
        //Testing post operation and persistance to backend
        public void postDataTest_VerifyPersistance()
        {
            ApiCaller caller = new ApiCaller();
            var response = caller.postData(new ApiCaller.userData { name = "darth vader", job = "villain" });
            var responseContent = JsonConvert.DeserializeObject<insertResponseModel>(response.Content.ToString());
            response.Content.Should().NotBeNullOrEmpty();
            responseContent.name.Should().Be("darth vader");
            responseContent.job.Should().Be("villain");

            // below code is to verify the persistance to database which ideally should find the recently inserted record
            //but it does not find it.
            //Tested the api response using postman as well
            //Any check to database with user id greater than 12 does not yield any records
            //though the POST command shows the operation is successful
            //But have included the code here to show how to verify the persistence.

            //Hence the test case currently fails.
            var verificationResponse = caller.getSingleUserData(responseContent.id);
            
            
            var verificationResponseContent = JsonConvert.DeserializeObject<getSingleUserModel>(verificationResponse.Content.ToString());
            verificationResponseContent.Should().NotBeNull();

        }
    }
}