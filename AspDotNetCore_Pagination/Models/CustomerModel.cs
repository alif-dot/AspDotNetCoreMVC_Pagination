namespace AspDotNetCore_Pagination.Models
{
    public class CustomerModel
    {
        public List<Customer> Customers { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }
}
