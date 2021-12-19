using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskWinForm.Model;

namespace TaskWinForm.Controller
{
    public class MainCtr
    {
        public bool _CommandState = false;
        public int _TotalData = 0;
        public int _TotalDataPage = 0;
        public bool _WaitForGet = false;
        public DataTable _CommandData;
        DB _db;

        public MainCtr()
        {
            string create_query = @"CREATE TABLE tb_comment(id INTEGER PRIMARY KEY, name TEXT, date TEXT, comment TEXT)";
            _db = new DB(create_query);
        }

        public bool SelectData(int page, int pagesize, string search = "")
        {

            if (_WaitForGet)
            {
                return false;
            }

            SelectDataCount(pagesize);

            List<DBParams> _params = new List<DBParams>();
            _params.Add(new DBParams() { key = "id", type = "int" });
            _params.Add(new DBParams() { key = "name" });
            _params.Add(new DBParams() { key = "date" });
            _params.Add(new DBParams() { key = "comment" });

            List<DBParams> _paramsInput = new List<DBParams>();

            string search_query = "";
            if(search.Count()>0)
            {
                search_query = " and (name like '%"+search+"%' ";
                search_query = " or comment like '%" + search + "%' )";
            }

            _paramsInput.Add(new DBParams() { key = "page", value = (page * pagesize).ToString() });
            _paramsInput.Add(new DBParams() { key = "pagesize", value = pagesize.ToString() });

            string query = "SELECT * FROM tb_comment WHERE 1=1  "+ search_query + " ORDER BY id DESC LIMIT @page,@pagesize";
            _CommandState = _db.Select(query, _params, _paramsInput);

            if (_CommandState)
            {
                _CommandData = _db.GetData();
            }
            else
            {
                _db.InitDataBase();
            }
            return true;
        }


        //get count select query
        public bool SelectDataCount(int pagesize)
        {
            if (_WaitForGet)
            {
                return false;
            }
            List<DBParams> _params = new List<DBParams>();
            _params.Add(new DBParams() { key = "cnt", type = "int" });

            List<DBParams> _paramsInput = new List<DBParams>();
            _paramsInput.Add(new DBParams() { key = "id", value = "0" });
            string query = "SELECT count(*) as cnt FROM tb_comment WHERE id>@id";

            _CommandState = _db.Select(query, _params, _paramsInput);

            if (_CommandState)
            {
                _CommandData = _db.GetData();
            }
            else
            {
                _db.InitDataBase();
            }

            try
            {
                _TotalData = int.Parse(_CommandData.Rows[0]["cnt"].ToString());
            }
            catch { }
            


            _TotalDataPage = _TotalData / pagesize;

            if (_TotalData % pagesize > 0)
            {
                _TotalDataPage++;
            }

            return true;
        }


        public string InsertData(Label Lb_wait, MainFrm frm,string name, string date, string comment,bool post=false)
        {
            if (name.Count() > 20)
            {
                _CommandState = false;
                return "length of name invalid (max 20 character)";
            }

            if (name.Count() == 0)
            {
                _CommandState = false;
                return "name required";
            }

            if (comment.Count() > 100)
            {
                _CommandState = false;
                return "length of comment invalid (max 100 character)";
            }

            if (comment.Count() == 0)
            {
                _CommandState = false;
                return "comment required";
            }


            if(post)
            {
                Comments post_comment = new Comments() {  name=name, date=date,comment=comment};
                PostAsync( Lb_wait,  frm,post_comment);
            }
            else
            {
                string str = "INSERT INTO tb_comment(name, date, comment) VALUES(@name, @date, @comment)";

                List<DBParams> _params = new List<DBParams>();
                _params.Add(new DBParams() { key = "name", value = name });
                _params.Add(new DBParams() { key = "date", value = date });
                _params.Add(new DBParams() { key = "comment", value = comment });

                _CommandState = _db.Command(str, _params);

                if (_CommandState)
                {
                    return "Successfull insert data";
                }
            }

            return _db._error_command;
        }

        public string ClearData()
        {
            string str = "DELETE FROM  tb_comment";

            List<DBParams> _params = new List<DBParams>();

            _CommandState = _db.Command(str, _params);

            if (_CommandState)
            {
                return "Successfull clear data";
            }

            return _db._error_command;
        }

        public async Task PostAsync(Label Lb_wait, MainFrm frm,Comments comment)
        {
            if (_WaitForGet)
            {
                return;
            }

            try
            {
                _WaitForGet = true;
                frm.BeginInvoke((Action)(() => //Invoke at UI thread
                { //run in UI thread
                    Lb_wait.Text = "Waiting for post data to server";
                    Lb_wait.ForeColor = Color.Red;
                }), null);

                var client = new HttpClient();
                client.Timeout = TimeSpan.FromMinutes(5);
                var response = string.Empty;

                string json = JsonConvert.SerializeObject(comment);

                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+

                HttpResponseMessage result = await client.PostAsync("http://tasks.cloudsite.ir/api/", stringContent);

                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }

                frm.BeginInvoke((Action)(() => //Invoke at UI thread
                { //run in UI thread
                    Lb_wait.Text = "Data Posted";
                    Lb_wait.ForeColor = Color.Green;
                }), null);
            }
            catch (Exception ex)
            {
                frm.BeginInvoke((Action)(() => //Invoke at UI thread
                { //run in UI thread
                    Lb_wait.Text = "Error in get data . please try again. " + ex.Message;
                    Lb_wait.ForeColor = Color.Red;
                }), null);
            }
            _WaitForGet = false;

        }
        public async Task GetAsync(Label Lb_wait, MainFrm frm, bool fillGrid = true, bool fillDatabase = false)
        {
            if (_WaitForGet)
            {
                return;
            }

            try
            {
                _WaitForGet = true;
                frm.BeginInvoke((Action)(() => //Invoke at UI thread
                { //run in UI thread
                    Lb_wait.Text = "Waiting for get data from api";
                    Lb_wait.ForeColor = Color.Red;
                }), null);

                var client = new HttpClient();
                client.Timeout = TimeSpan.FromMinutes(5);
                var response = string.Empty;

                HttpResponseMessage result = await client.GetAsync("http://tasks.cloudsite.ir/api/");
               
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }

                frm.BeginInvoke((Action)(() => //Invoke at UI thread
                { //run in UI thread
                    Lb_wait.Text = "Data received";
                    Lb_wait.ForeColor = Color.Green;
                    List<Comments> list = JsonConvert.DeserializeObject<List<Comments>>(response);
                    frm.FillGridFrmApi(list);
                }), null);
            }
            catch (Exception ex)
            {
                frm.BeginInvoke((Action)(() => //Invoke at UI thread
                { //run in UI thread
                    Lb_wait.Text = "Error in get data . please try again. " + ex.Message;
                    Lb_wait.ForeColor = Color.Red;
                }), null);
            }
            _WaitForGet = false;
        }

        public  async Task ImportData(Label Lb_wait, MainFrm frm,List<Comments>  list)
        {
            //Stuff Happens on the original UI thread

            await Task.Run(() => //This code runs on a new thread, control is returned to the caller on the UI thread.
            {
                _WaitForGet = true;
                int index = 0;
                foreach (var item in list)
                {
                    InsertData(Lb_wait,  frm,item.name, item.date, item.comment);
                    index++;
                    frm.BeginInvoke((Action)(() => //Invoke at UI thread
                    { //run in UI thread
                        Lb_wait.Text = "Data imported to database "+index.ToString();
                    }), null);
                }

                frm.BeginInvoke((Action)(() => //Invoke at UI thread
                { //run in UI thread
                    Lb_wait.Text = "Data imported to database";
                    Lb_wait.ForeColor = Color.Green;
                }), null);
                _WaitForGet = false;
                //Do Stuff
            });

            //Stuff Happens on the original UI thread after the loop exits.
        }

    }
}
