namespace UsernameApi.Models
{
    
    public class Username
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ApiKey ApiKey { get; set; }
    }
}