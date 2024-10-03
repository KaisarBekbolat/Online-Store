using System;

namespace SporteStore___2nd_try.Models;

public class EFStoreRepository : IStoreRepository
{
    private StoreDbContext _context;
    public EFStoreRepository(StoreDbContext context){
        _context = context;
    }
    public IEnumerable<Product> Products => _context.Products;
}
