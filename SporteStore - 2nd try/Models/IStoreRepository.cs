using System;

namespace SporteStore___2nd_try.Models;

public interface IStoreRepository
{
    public IEnumerable<Product> Products {get;}
}
