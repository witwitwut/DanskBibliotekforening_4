using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using IO;

namespace Biz
{
    public class ClassLogin
    {
        ClassDbfDB classDbfDB = new ClassDbfDB();

        private string _id;
        private string _user;
        private ClassPerson _cp;

        public ClassLogin()
        {
            id = "";
            user = "";
        }
        public ClassLogin(string inId, string inUser)
        {
            id = inId;
            user = inUser;
        }

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string user
        {
            get { return _user; }
            set { _user = value; }
        }
        
        public ClassPerson cp
        {
            get { return _cp; }
            set { _cp = value; }
        }
        
        public ClassPerson GetUserData()
        {
            cp = classDbfDB.GetUser(id, user);
            return cp;
        }
    }
}
