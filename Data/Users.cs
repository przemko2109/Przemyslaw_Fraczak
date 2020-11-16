using System;

namespace Data
{
    public class Users
    {
        private int user_id;

        public int userId
        {
            get { return user_id; }
            set { user_id = value; }
        }

        private String user_name;
        public String userName
        {
            get { return user_name; }
            set { user_name = value; }
        }

        public Users(String un, int ui)
        {
            this.user_name = un;
            this.user_id = ui;
        }
    }
}
