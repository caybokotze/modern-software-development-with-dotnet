using System.ComponentModel.Design;
using DWD.Shared;

namespace CSharpBasics;

public class DependencyInjection
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void SaveUser(User person)
        {
            _userRepository.SaveObject(person);
        }
    }

    public class UserRepository
    {
        public void SaveObject(object value)
        {
            // save logic...
        }
    }

    public static class ContainerExtensions
    {
        public static IServiceContainer Add(IServiceContainer serviceContainer)
        {
            serviceContainer.AddService(typeof(UserService), serviceContainer);
            return serviceContainer;
        }
    }
}