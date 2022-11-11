using System.Collections.Generic;

namespace UsernameApi.Models
{
    
    public class ApiKey
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public List<Username> Usernames { get; set; }
    }
}