using DWD.Shared;

namespace CSharpBasics;

/// <summary>
/// This is one example of where making use of Generics could prove useful.
/// In this context, we are creating a generic service to create new instances of a generic type. The other is to save to the database.
/// </summary>
public class UserServiceWithGenericMethods
{
    private readonly UserDataService _userDataService;

    public UserServiceWithGenericMethods(UserDataService userDataService)
    {
        _userDataService = userDataService;
    }
    
    /// <summary>
    /// A generic parameter to save a user
    /// </summary>
    /// <param name="t"></param>
    /// <typeparam name="T"></typeparam>
    public void CreateUser<T>(T t) where T : IUser
    {
        _userDataService.User?.Add(t);
    }

    /// <summary>
    /// This will return a new instance of the generic argument if the provided type is of type IUser and is 'newable' (meaning it has parameterless constructors)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetNewInstance<T>() where T : IUser, new()
    {
        return new T();
    }
}

/// <summary>
/// This can represent our temporary data context class
/// </summary>
public class UserDataService
{
    public List<IUser>? User { get; set; }
}


