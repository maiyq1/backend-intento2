using Data.DbContext;
using Data.Model;

namespace Data;

public class SupplierData : ISupplierData
{
    private DatabaseDBContext _database;

    public SupplierData(DatabaseDBContext database)
    {
        _database = database;
    }
    
    public List<Supplier> GetAll()
    {
        return _database.Suppliers.ToList();
    }

    public bool create(Supplier supplier)
    {
        try
        {
            _database.Suppliers.Add(supplier);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool update(Supplier supplier, int id)
    {
        try
        {
            var SupplierUpdated = _database.Suppliers.Where(t => t.Id == id).FirstOrDefault();

            SupplierUpdated.firstName = supplier.firstName;
            SupplierUpdated.lastName = supplier.lastName;
            SupplierUpdated.address = supplier.address;
            SupplierUpdated.businessName = supplier.businessName;
            SupplierUpdated.email = supplier.email;
            SupplierUpdated.phone = supplier.phone;

            _database.Suppliers.Update(SupplierUpdated);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool delete(int id)
    {
        try
        {
            var _supplier = _database.Suppliers.Find(id);
            _supplier.isActive = false;

            _database.Suppliers.Update(_supplier);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Supplier GetById(int id)
    {
        return _database.Suppliers.Where(t => t.Id == id).FirstOrDefault();
    }
}