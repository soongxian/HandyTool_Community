namespace HandyTool.HandyTool.Domain.Model
{
    public class ServerCredential
    {
        public Guid Id { get; set; }
        public string Server { get; set; }
        public bool LoginNeeded { get; set; } = false;
        public string Username { get; set; }
        public string Password { get; set; }
        public int Deleted { get; set; } = 0;
    }
}
