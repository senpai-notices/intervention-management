using System.Collections.Generic;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Data
{
    public class UserRepository
    {
        public List<SimpleUser> UserList { get; set; }

        public SimpleUser GetUser(int userId)
        {
            var u = new SimpleUser();

            using (var conn = DatabaseHelper.GetSqlConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"select * from [dbo].[User] where [UserId] = {0};";

                    cmd.CommandText = string.Format(cmd.CommandText, userId.ToString());
                    var reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        u.Load(reader);
                    }
                }
            }

            return u;
        }
    }
}
