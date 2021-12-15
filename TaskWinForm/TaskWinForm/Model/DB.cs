using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace TaskWinForm.Model
{
    public class DB
    {
        public SQLiteConnection con;
        public SQLiteCommand cmd;

        public string _error_command = "";
        public string _create_query = "";

        private DataTable _selectData;

        string _cs;


        public DB(string create_query)
        {
            _cs = @"URI=file:DataBase.db";
            _create_query = create_query;
            string path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DataBase.db");
            if (!File.Exists(path))
            {
                try
                {
                    con = new SQLiteConnection(_cs);
                    con.Open();
   
                    con.Close();
                }
                catch { }
            }

        }

        public void InitDataBase()
        {
            try
            {
                con = new SQLiteConnection(_cs);
                con.Open();
                cmd = new SQLiteCommand(con);
                cmd.CommandText = _create_query;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex) { }
        }

        public bool Command(string _query,List<DBParams> _params)
        {
            try
            {
                con = new SQLiteConnection(_cs);
                con.Open();
                cmd = new SQLiteCommand(con);

                cmd.CommandText = _query;

                foreach(var item in _params)
                {
                    cmd.Parameters.AddWithValue("@"+item.key, item.value);
                }
                cmd.Prepare();
                cmd.ExecuteNonQueryAsync();
                
                con.Close();
                return true;
            }
            catch(Exception ex) {
                _error_command= ex.Message;
            }

            return false;
        }

        public bool Select(string query, List<DBParams> _params, List<DBParams>_paramsInput)
        {
            DataTable dt = new DataTable();
            DataRow _row;

            dt.Clear();

            foreach (var item in _params)
            {
                dt.Columns.Add(item.key);
            }

            try
            {
                con = new SQLiteConnection(_cs);
                con.Open();
                cmd = new SQLiteCommand(con);

                string stm = query;

                cmd.CommandText = stm;

                foreach (var item in _paramsInput)
                {
                    cmd.Parameters.AddWithValue("@" + item.key, item.value);
                }
                cmd.Prepare();

                SQLiteDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                     _row = dt.NewRow();
                    int index = 0;
                    foreach (var item in _params)
                    {
                        if(item.type != null && item.type== "int")
                        {
                            _row[item.key] = rdr.GetInt32(index).ToString();
                        }
                        else
                        {
                            _row[item.key] = rdr.GetString(index);
                        }
                        index++;
                    }

                    dt.Rows.Add(_row);
                }

                _selectData = dt;

                con.Close();
                return true;
            }
            catch (Exception ex) {
                _error_command = ex.Message;
            }
            return false;
        }

        public DataTable GetData()
        {
            return _selectData;
        }

    }

   public class DBParams
    {
        public string key { get; set; }
        public string value { get; set; }
        public string type { get; set; }
    }
}
