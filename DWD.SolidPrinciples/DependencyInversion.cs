using System.Data;
using DWD.Shared;

namespace DWD.SolidPrinciples;

public class DependencyInversion
{
    #region The darkness

    public class MySqlConnection
    {
        public List<object> Read(string query, object parameters)
        {
            return new List<object>();
        }

        public int Write(string statement, object value)
        {
            return 1;
        }
    }

    public class PersonService
    {
        private readonly MySqlConnection _mySqlConnection;

        public PersonService(MySqlConnection mySqlConnection)
        {
            _mySqlConnection = mySqlConnection;
        }

        public void SavePerson(Person person)
        {
            _mySqlConnection.Write("insert into people (age, first_name, last_name) VALUES (@Age, @FirstName, @LastName)", person);
        }
    }
    #endregion
    
    #region The light
    public interface IDatabaseConnection
    {
        List<object> Read(string query, object parameters);
        int Write(string statement, object parameters);
    }
    
    public class BetterPersonService
    {
        private readonly IDatabaseConnection _databaseConnection;

        public BetterPersonService(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public void SavePerson(Person person)
        {
            _databaseConnection.Write("insert into people (age, first_name, last_name) VALUES (@Age, @FirstName, @LastName)", person);
        }
    }
    
    #endregion
}