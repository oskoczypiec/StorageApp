namespace StorageApp.Entities
{
    public class Organization : EntityBase
    {
        public string? FirstName { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, FirstName: {FirstName}";
        }
    }
}
