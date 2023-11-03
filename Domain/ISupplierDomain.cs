using Data.Model;

namespace Domain;

public interface ISupplierDomain
{
    bool create(Supplier supplier);
    bool update(Supplier supplier, int id);
    bool delete(int id);
}