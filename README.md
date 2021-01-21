# PagedList

A library for easily paging through any IQueryable in ASP.NET/ASP.NET Core.
It enables you to easily take an IEnumerable/IQueryable, chop it up into "pages", and grab a specific "page" by an index.

It can be useful for paginated Grid view or Infinite scroll implementation, once it provides all needed information to implement it.

The query is automatically generated according to the Paged Model filters implementation.
Paged Model is a class which represents the filters in the query, related properties including and ordering.

# Important resources
- BasePagedListModel<T>: base class for a Paged Model implementation. This class auto generates the query ;
- IIncludable<T>: an interface which can be used for related property including;

# Folders description
- APIExample: a .NET Core API including two examples os usage;
- PagedList: the library source code.

# How to use
You can find examples using EF Core in APIExample project.
Here follows an example of usage in a Controller

```csharp
public class BusinessController : ControllerBase
{
  private readonly Context _context;

  public BusinessController(Context context)
  {
      _context = context;
  }

  [HttpGet]
  public IActionResult Get([FromQuery]BusinessViewModel businessViewModel)
  {
      var pagedList = _context.Business.ToPagedList(businessViewModel);

      return new OkObjectResult(pagedList);
  }
}
```

The View Model implementation example is as follow. The CNPJ property is a filter example that can be passed in the Query string.

```csharp
public class BusinessViewModel : BasePagedListModel<Business>
{
    private string cnpj;
    public string CNPJ
    {
        get => cnpj;
        set
        {
            if (string.IsNullOrEmpty(value))
                return;

            cnpj = value;
            AppendFilter(x => x.CNPJ == CNPJ);
        }
    }
}
```

Enjoy it! Any suggestion is welcome for library improvement! :)
