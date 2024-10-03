using System;
using System.Reflection.Metadata.Ecma335;

namespace SporteStore___2nd_try.Models.ViewModels;

public class PagingInfo
{
    public int TotalItems{get;set;}
    public int ItemsPerPage{get;set;}
    public int CurrentPage{get;set;}

    public int Pages()=> (int)Math.Ceiling((decimal)TotalItems/ItemsPerPage);
}