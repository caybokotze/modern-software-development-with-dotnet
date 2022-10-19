using EF.BasicCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF.BasicCrud.Controllers;

[ApiController]
[Route("[controller]")] // we can make use of templates which .NET will auto-route to the correct corresponding controller.
public class PersonController : ControllerBase
{
    private readonly DataContext _dataContext;

    public PersonController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpPost]
    [Route("insert")]
    public void InsertPerson(Person person)
    {
        _dataContext.People.Add(person);
        _dataContext.SaveChanges();
    }
}