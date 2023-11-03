using Data.Model;

namespace Data;

public interface ISupplierData
{
    public List<Supplier> GetAll();
    bool create(Supplier supplier);
    bool update(Supplier supplier, int id);
    bool delete(int id);
    public Supplier GetById(int id);
}