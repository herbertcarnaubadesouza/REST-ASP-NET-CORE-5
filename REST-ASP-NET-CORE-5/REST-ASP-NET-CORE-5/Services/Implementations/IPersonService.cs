using REST_ASP_NET_CORE_5.Model;
using System.Collections.Generic;

namespace REST_ASP_NET_CORE_5.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
