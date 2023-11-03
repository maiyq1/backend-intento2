using Data;
using Data.Model;

namespace Domain;

public class SupplierDomain : ISupplierDomain
{
    public ISupplierData _SupplierData;

    public SupplierDomain(ISupplierData supplierData)
    {
        _SupplierData = supplierData;
    }
    
    public bool create(Supplier supplier)
    {
        if (supplier.phone.Length != 9)
            return false;
        return _SupplierData.create(supplier);
    }

    public bool update(Supplier supplier, int id)
    {
        return _SupplierData.update(supplier, id);
    }

    public bool delete(int id)
    {
        return _SupplierData.delete(id);
    }
}