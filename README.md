# PagedList

A library for easily paging through any IQueryable in .NET Core.
It enables you to easily take an IQueryable, chop it up into "pages", and grab a specific "page" by an index.

It can be useful for paginated Grid view, API JSON array return or Infinite scroll implementation, once it provides all needed information to implement it.

The query is automatically generated according to the Paged Model filters implementation.

# Important resources
- BasePagedListModel<T>: base class for a Paged Model implementation. This class auto generates the query. The library also exposes the IPagedListModel<T> interface, which you can use abstracting implementations;
- IIncludable<T>: implementations of PagedListModel which implements this interface are enabled to include entities related properties;

# Folders description
- APIExample: a .NET Core API including two examples os usage;
- PagedList: the library source code.
  
# Dependencies
The library depends on:
- Entity Framework Core 3.0.0 or higher;
 
# How to use
You can find examples using EF Core in APIExample project.
Here follows an example of usage in a Controller. You can use sync/async methods. 

```csharp
public class BusinessController : ControllerBase
{
  private readonly Context _context;

  public BusinessController(Context context)
  {
      _context = context;
  }

  [HttpGet]
  public Task<IActionResult> Get([FromQuery]BusinessViewModel businessViewModel)
  {
      var pagedList = await _context.Business.ToPagedListAsync(businessViewModel);

      return Ok(pagedList);
  }
}
```
  
The extension method ToPagedList is as follows:
  
```csharp
public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> DBSetQuery) where T : class
{
    var pagedList = new PagedList<T>(DBSetQuery);
    await pagedList.FillAsync();

    return pagedList;
}
```

The Paged DTO implementation is as follow. The CNPJ property is a filter example that can be passed in the Querystring.

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
