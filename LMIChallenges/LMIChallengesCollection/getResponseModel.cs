using System;
using System.Collections.Generic;
using System.Text;

namespace LMIChallengesCollection
{
    public class userDetails
    {
        public int id;
        public string email;
        public string first_name;
        public string last_name;
        public string avatar;
    }

    public class Support
    {
        public string url;
        public string text;
    }
   public class getResponseModel
    {
        public int page;
        public int per_page;
        public int total;
        public int total_pages;
        public List<userDetails> data;
        public Support support;
    }

    public class getSingleUserModel
    {
        public userDetails data;
        public Support support;
    }
}
