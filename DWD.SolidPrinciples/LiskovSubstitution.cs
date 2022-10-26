using System.Text;

namespace DWD.SolidPrinciples;

public class LiskovSubstitution
{
    #region The darkness
    public class SqlFile
    {
        public string LoadText()
        {
            /* Code to read text from sql file */
            return string.Empty;
        }

        public void SaveText()
        {
            /* Code to save text into sql file */
        }
    }

    public class ReadOnlySqlFile : SqlFile
    {
        public string? FilePath { get; set; }
        public string? FileText { get; set; }

        public string? LoadText()
        {
            /* Code to read text from sql file */
            return string.Empty;
        }

        public void SaveText()
        {
            /* Throw an exception when app flow tries to do save. */
            throw new IOException("Can't Save");
        }
    }

    public class SqlFileManager
    {
        public List<SqlFile>? SqlFiles { get; set; }

        public string GetTextFromFiles()
        {
            var objStrBuilder = new StringBuilder();

            foreach (var objFile in SqlFiles)
            {
                objStrBuilder.Append(objFile.LoadText());
            }

            return objStrBuilder.ToString();
        }

        public void SaveTextIntoFiles()
        {
            foreach (var objFile in SqlFiles)
            {
                //Check whether the current file object is read-only or not.If yes, skip calling it's  
                // SaveText() method to skip the exception.  

                if (!(objFile is ReadOnlySqlFile))
                {
                    objFile.SaveText();
                }
            }
        }
    }

    #endregion

    #region The light

    public interface IReadableSqlFile
    {
        string LoadText();
    }

    public interface IWritableSqlFile
    {
        void SaveText();
    }

    public class BetterReadOnlySqlFile : IReadableSqlFile
    {
        public string? FilePath { get; set; }
        public string? FileText { get; set; }

        public string LoadText()
        {
            /* Code to read text from sql file */
            return string.Empty;
        }
    }

    public class BetterSqlFile : IWritableSqlFile, IReadableSqlFile
    {
        public string? FilePath { get; set; }
        public string? FileText { get; set; }

        public string LoadText()
        {
            /* Code to read text from sql file */
            return string.Empty;
        }

        public void SaveText()
        {
            /* Code to save text into sql file */
        }
    }

    public class BetterSqlFileManager
    {
        public string GetTextFromFiles(List<IReadableSqlFile> aLstReadableFiles)
        {
            var objStrBuilder = new StringBuilder();
            foreach (var objFile in aLstReadableFiles)
            {
                objStrBuilder.Append(objFile.LoadText());
            }

            return objStrBuilder.ToString();
        }

        public void SaveTextIntoFiles(List<IWritableSqlFile> writableSqlFiles)
        {
            foreach (var objFile in writableSqlFiles)
            {
                objFile.SaveText();
            }
        }
    }

    #endregion
}