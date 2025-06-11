using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SqlInjection
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        /// <summary>
        /// このアプリケーションで使用するデータベース接続文字列を取得する
        /// </summary>
        /// <returns>データベース接続文字列</returns>
        public string getConnectionString()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "192.168.162.200"; // "localhost";
            sqlConnectionStringBuilder.InitialCatalog = "ADONET";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "Teki1$2tou_"; // "P@ssword";
            return sqlConnectionStringBuilder.ConnectionString;
        }

        /// <summary>
        ///「パラメータクエリ」ボタンがクリックされた際に呼び出されるイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Parameter_Click(object sender, EventArgs e)
        {
            List<MyTableDto> list = new List<MyTableDto>();

            String query = "SELECT* FROM [MyTable] WHERE [StringData] = @StringData";
            this.Label_SQL.Text = query;

            using (SqlConnection conn = new SqlConnection(this.getConnectionString()))
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.Add("@StringData", SqlDbType.NVarChar).Value = this.Where_TextBox.Text;

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (true == reader.Read())
                    {
                        MyTableDto result = new MyTableDto();
                        result.IntData = (int)reader["IntData"];
                        result.DoubleData = reader["DoubleData"] as double?;
                        result.DecimalData = reader["DecimalData"] as decimal?;
                        result.StringData = reader["StringData"] as string;
                        result.DateTimeData = reader["DatetimeData"] as DateTime?;
                        result.BoolData = reader["BoolData"] as bool?;
                        list.Add(result);
                    }
                }
            }

            this.Result_GridView.DataSource = list;
            this.Result_GridView.DataBind();
        }

        /// <summary>
        ///「文字列編集」ボタンがクリックされた際に呼び出されるイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_StringEdit_Click(object sender, EventArgs e)
        {
            List<MyTableDto> list = new List<MyTableDto>();

            String query = "SELECT* FROM [MyTable] WHERE [StringData] = ";
            query += "'" + this.Where_TextBox.Text + "'";

            this.Label_SQL.Text = query;

            using (SqlConnection conn = new SqlConnection(this.getConnectionString()))
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand(query, conn);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (true == reader.Read())
                    {
                        MyTableDto result = new MyTableDto();
                        result.IntData = (int)reader["IntData"];
                        result.DoubleData = reader["DoubleData"] as double?;
                        result.DecimalData = reader["DecimalData"] as decimal?;
                        result.StringData = reader["StringData"] as string;
                        result.DateTimeData = reader["DatetimeData"] as DateTime?;
                        result.BoolData = reader["BoolData"] as bool?;
                        list.Add(result);
                    }
                }
            }

            this.Result_GridView.DataSource = list;
            this.Result_GridView.DataBind();
        }

        /// <summary>
        /// ページがロードされたときに呼び出されるイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            List<MyTableDto> list = new List<MyTableDto>();

            using (SqlConnection conn = new SqlConnection(this.getConnectionString()))
            {
                conn.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT* FROM [MyTable] ORDER BY [IntData] ASC", conn);
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (true == reader.Read())
                    {
                        MyTableDto result = new MyTableDto();
                        result.IntData = (int)reader["IntData"];
                        result.DoubleData = reader["DoubleData"] as double?;
                        result.DecimalData = reader["DecimalData"] as decimal?;
                        result.StringData = reader["StringData"] as string;
                        result.DateTimeData = reader["DatetimeData"] as DateTime?;
                        result.BoolData = reader["BoolData"] as bool?;
                        list.Add(result);
                    }
                }
            }

            this.AllRecord_GridView.DataSource = list;
            this.AllRecord_GridView.DataBind();
        }
    }
}