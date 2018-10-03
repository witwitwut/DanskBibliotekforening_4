using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using Repository;

namespace IO
{
    public class ClassDbfDB : ClassDB
    {
        public ClassDbfDB()
        {
            SetCon(@"Server=10.205.44.39,49172;Database=DBF;User Id=AspIT;Password=Server2012;");
        }

        public ObservableCollection<ClassBog> GetAllBooksLike(string search)
        {
            ObservableCollection<ClassBog> obcBooks = new ObservableCollection<ClassBog>();
            DataTable dt = DbReturnDataTable("SELECT Books.id, Titel.titel, ISBNnr.isbnNr, Type.TypeNavn, Forfatter.forfatter, Forlag.forlagsNavn, Genre.genreType, Books.pris" +
                                             "FROM Books INNER JOIN Titel ON Books.titelID = Titel.id" +
                                             "INNER JOIN Type ON Books.typeID = Type.id " +
                                             "INNER JOIN Forfatter ON Books.forfatterID = Forfatter.id " +
                                             "INNER JOIN Forlag ON Books.forlagID = Forlag.id " +
                                             "INNER JOIN Genre ON Books.genreID = Genre.id " +
                                             "INNER JOIN ISBNnr ON Books.isbnID = ISBNnr.id" +
                                             "WHERE Titel.id LIKE '%" + search + "%'");
            foreach (DataRow row in dt.Rows)
            {
                obcBooks.Add(new ClassBog(Convert.ToInt32(row["id"]),
                                          row["titel"].ToString(),
                                          row["isbnNr"].ToString(),
                                          row["TypeNavn"].ToString(),
                                          row["forfatter"].ToString(),
                                          row["forlagsNavn"].ToString(),
                                          row["genreType"].ToString(),
                                          Convert.ToDecimal(row["pris"])));
            }

            return obcBooks;
        }

        public ObservableCollection<ClassBog> GetAllBooksLendToUser(string id)
        {
            ObservableCollection<ClassBog> obcLendBooks = new ObservableCollection<ClassBog>();
            DataTable dt = DbReturnDataTable("SELECT Books.id, ISBNnr.isbnNr, Titel.titel, Forfatter.forfatter, Forlag.forlagsNavn, Genre.genreType, Type.TypeNavn, Books.pris" +
                                             "FROM Books INNER JOIN ISBNnr ON Books.isbnID = ISBNnr.id " +
                                             "INNER JOIN Titel ON Books.titelID = Titel.id " +
                                             "INNER JOIN Forfatter ON Books.forfatterID = Forfatter.id " +
                                             "INNER JOIN Forlag ON Books.forlagID = Forlag.id " +
                                             "INNER JOIN Genre ON Books.genreID = Genre.id " +
                                             "INNER JOIN Type ON Books.typeID = Type.id " +
                                             "INNER JOIN Person ON Books.id = Person.id " +
                                             "WHERE Person.id = '" + id + "'");
            foreach (DataRow row in dt.Rows)
            {
                obcLendBooks.Add(new ClassBog(Convert.ToInt32(row["id"]),
                                              row["titel"].ToString(),
                                              row["isbnNr"].ToString(),
                                              row["TypeNavn"].ToString(),
                                              row["forfatter"].ToString(),
                                              row["forlagsNavn"].ToString(),
                                              row["genreType"].ToString(),
                                              Convert.ToDecimal(row["pris"])));
            }

            return obcLendBooks;
        }

        public void UpdateTheLendingStatus(string id, bool status)
        {
            try
            {
                string sqlString = "UPDATE UdlaansStatus SET status = " + status + " WHERE id = '" + id + "'";
                FunctionExecuteNonQuery(sqlString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl i DB kommunikationen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ClassPerson GetUser(string userID, string password)
        {
            ClassPerson cp = new ClassPerson();
            string id = DbReturnString("SELECT id FROM Access WHERE cprNr = '" + userID + "', password = '" + password + "'");
            if (id != "")
            {
                DataTable dt = DbReturnDataTable("SELECT Person.id, Person.navn, Person.adresse, Person.rolle, PersonMail.mailAdr, PersonTelefon.telefonnummer" +
                                                 "FROM Access INNER JOIN BrugerRolle ON Access.id = BrugerRolle.id " +
                                                 "INNER JOIN Person ON Access.userId = Person.id AND BrugerRolle.id = Person.rolle " +
                                                 "INNER JOIN PersonMail ON Person.id = PersonMail.personID " +
                                                 "INNER JOIN PersonTelefon ON Person.id = PersonTelefon.personID");
            }
            return cp;
        }
    }
}
