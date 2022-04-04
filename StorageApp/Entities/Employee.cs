namespace StorageApp.Entities
{
    public class Employee : EntityBase
    {
        public string? FirstName { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, First name: {FirstName}";
        }
    }
}
