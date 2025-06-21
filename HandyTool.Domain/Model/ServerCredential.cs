namespace HandyTool.HandyTool.Domain.Model
{
    public class ServerCredential
    {
        public Guid Id { get; set; }
        public string ServerName { get; set; }
        public bool Authentication { get; set; } = false;
        public string Login { get; set; }
        public string Password { get; set; }
        public int Deleted { get; set; } = 0;
    }
}
