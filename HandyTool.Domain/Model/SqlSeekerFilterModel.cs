namespace HandyTool.HandyTool.Domain.Model
{
    public class SqlSeekerFilterModel
    {
        public string ObjectType { get; set; }
        public string DatabaseName { get; set; }
        public string SchemaName { get; set; }
        public string ObjectName { get; set; }
        public string FullObject { get; set; }
        public string Parameters { get; set; }
        public string Rows { get; set; }
        public string Example { get; set; }
    }
}
