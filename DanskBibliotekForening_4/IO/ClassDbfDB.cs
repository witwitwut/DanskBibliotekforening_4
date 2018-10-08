using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            

            DataTable dt = DbReturnDataTable("EXECUTE getAllBooksLike " + $"{search}");

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
            DataTable dt = DbReturnDataTable("EXECUTE spGetAllBooksLentToUser " + $"{id}");

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
                FunctionExecuteNonQuery("EXECUTE UpdateTheLendingStatus " + $"{id}," +
                    $" {status}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl i DB kommunikationen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ClassPerson GetUser(string userID, string password)
        {
            ClassPerson cp = new ClassPerson();

           DataTable dt = DbReturnDataTable("EXECUTE GetUser " + $"{userID}, {password}");

            foreach (DataRow row in dt.Rows)
            {
                cp = new ClassPerson(Convert.ToInt32(row["id"]),
                                    row["navn"].ToString(),
                                    row["adresse"].ToString(),
                                    row["mailAdr"].ToString(),
                                    row["telefonnummer"].ToString(),
                                    Convert.ToInt32(row["rolle"])); 
            }
            return cp;
        }
    }
}
