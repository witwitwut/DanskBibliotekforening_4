using IO;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Biz
{
    public class ClassBiz : ClassNotify
    {

        ClassDbfDB CDBF = new ClassDbfDB();

        private ObservableCollection<ClassBog> _boeger = new ObservableCollection<ClassBog>();
        private ObservableCollection<ClassBog> _laanteBoeger = new ObservableCollection<ClassBog>();
        private ClassBog _Bog;
        private ClassPerson _person;
        private string _search;

        public ClassBiz()
        {
            search = "";
            //boeger = CDBF.GetAllBooksLike(search);
        }

        public ObservableCollection<ClassBog> laanteboeger
        {
            get { return _laanteBoeger; }
            set
            {
                if (value != _laanteBoeger)
                {
                    _laanteBoeger = value;
                    Notify("laanteboeger");
                }                
            }
        }
        public ObservableCollection<ClassBog> boeger
        {
            get { return _boeger; }
            private set
            {
                if (value != _boeger)
                {
                    _boeger = value;
                    Notify("boeger");
                }                
            }
        }

        public ClassPerson person
        {
            get { return _person; }
            set
            {
                if (value != _person)
                {
                    _person = value;
                    Notify("person");
                }                
            }
        }

        public ClassBog bog
        {
            get { return _Bog; }
            set
            {
                if (value != _Bog)
                {
                    _Bog = value;
                    Notify("bog");
                }
            }
        }
        
        public string search
        {
            get { return _search; }
            set
            {
                if (value != _search)
                {
                    _search = value;
                    if (_search != "")
                    {
                        boeger = GetAllBooksWhereTheTitleContainsTheseWords(_search);
                    }
                    Notify("search");
                }
            }
        }

        public ObservableCollection<ClassBog> GetAllLentBoks(string id)
        {
            return CDBF.GetAllBooksLendToUser(id);
        }

        public ObservableCollection<ClassBog> GetAllBooksWhereTheTitleContainsTheseWords(string search)
        {
            return CDBF.GetAllBooksLike(search);
        }

        public void LendThisBookToTheUser(ClassBog bog, ClassBog person)
        {

        }

        public void SubmiThisBookToTheLibrary(ClassBog bog, ClassPerson person)
        {

        }

        public bool CheckForDoubleLending(ClassBog bog)
        {
            throw new NotImplementedException();
        }
    }
}
