using ExtJSBack.Model;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ExtJSBack.DB
{
    public class DBFillHelper : IDBFillHelper
    {
        private readonly DatabaseContext _databaseContext;
        public DBFillHelper(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void FillDb()
        {
            FillPersons();
            FillUsers();
            _databaseContext.SaveChanges();
        }

        private void FillUsers()
        {
            // ни в коем случае нельзя хранить пароль в открытом виде!!! чисто для теста
            var user1 = new User { Login = "root", Password = "root123" };
            var user2 = new User { Login = "admin", Password = "admin123" };

            _databaseContext.Add<User>(user1);
            _databaseContext.Add<User>(user2);
        }

        private void FillPersons()
        {
            string dept = "bridge";
            for (int i = 0; i < 100; i++)
            {
                var newPerson = new Person { Name = $"User{i}", Email = $"user{i}@enterprise.com", Phone = $"555-{i}{i}{i}-1111", Dept = dept };
                _databaseContext.Add<Person>(newPerson);

                if (dept == "bridge")
                {
                    dept = "engine";
                }
            }
        }
    }
}
