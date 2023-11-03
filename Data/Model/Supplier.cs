using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model;

public class Supplier : Base
{
    public int Id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string address { get; set; }
    public string businessName { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public int users_id { get; set; }
}