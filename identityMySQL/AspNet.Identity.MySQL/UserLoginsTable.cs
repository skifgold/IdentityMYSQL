using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace AspNet.Identity.MySQL
{

    public class UserLoginsTable
    {
        private MySQLDatabase _database;

       
        public UserLoginsTable(MySQLDatabase database)
        {
            _database = database;
        }

    
        public int Delete(IdentityUser user, UserLoginInfo login)
        {
            string commandText = "Delete from UserLogins where UserId = @userId and LoginProvider = @loginProvider and ProviderKey = @providerKey";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("UserId", user.Id);
            parameters.Add("loginProvider", login.LoginProvider);
            parameters.Add("providerKey", login.ProviderKey);

            return _database.Execute(commandText, parameters);
        }

       
        public int Delete(string userId)
        {
            string commandText = "Delete from UserLogins where UserId = @userId";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("UserId", userId);

            return _database.Execute(commandText, parameters);
        }

        public int Insert(IdentityUser user, UserLoginInfo login)
        {
            string commandText = "Insert into UserLogins (LoginProvider, ProviderKey, UserId) values (@loginProvider, @providerKey, @userId)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("loginProvider", login.LoginProvider);
            parameters.Add("providerKey", login.ProviderKey);
            parameters.Add("userId", user.Id);

            return _database.Execute(commandText, parameters);
        }


        public string FindUserIdByLogin(UserLoginInfo userLogin)
        {
            string commandText = "Select UserId from UserLogins where LoginProvider = @loginProvider and ProviderKey = @providerKey";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("loginProvider", userLogin.LoginProvider);
            parameters.Add("providerKey", userLogin.ProviderKey);

            return _database.GetStrValue(commandText, parameters);
        }

   
        public List<UserLoginInfo> FindByUserId(string userId)
        {
            List<UserLoginInfo> logins = new List<UserLoginInfo>();
            string commandText = "Select * from UserLogins where UserId = @userId";
            Dictionary<string, object> parameters = new Dictionary<string, object>() { { "@userId", userId } };

            var rows = _database.Query(commandText, parameters);
            foreach (var row in rows)
            {
                var login = new UserLoginInfo(row["LoginProvider"], row["ProviderKey"]);
                logins.Add(login);
            }

            return logins;
        }
    }
}
