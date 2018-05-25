using System;
using System.Collections.Generic;
using System.Data;


namespace PostDe
{
    public partial class GetMatters : System.Web.UI.Page
    {
        private string token = null;
        DataTable table;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["token"]==null)
            {
                string url = Convert.ToString(Request.UrlReferrer);
                Response.Redirect("~/Login.aspx?url=" + System.Web.HttpUtility.UrlEncode(url));
            }
            token = Session["token"].ToString(); ;
            List<Matters> matters = Helper.tryGetMatters(token);
            table = Helper.ToDataTable<Matters>(matters);
            GridView1.DataSource = table;
            GridView1.DataBind();
            
        }
   
        public DataTable sorting(string item,string sort=null)
        {
            table.DefaultView.Sort=item+sort;
            return table;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String item=Select1.Items[Select1.SelectedIndex].Text;
            GridView1.DataSource = sorting(item);
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            String item = Select1.Items[Select1.SelectedIndex].Text;
            GridView1.DataSource = sorting(item," desc");
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Dictionary<string,string> dictionary = new Dictionary<string,string>();
            dictionary.Add("id", Text1.Value);
            dictionary.Add("name",Text2.Value);
            dictionary.Add("createuserid", Text3.Value);
            dictionary.Add("createusername", Text4.Value);

            foreach(var item in dictionary)
            {
                string comment;
                if (item.Value != "")
                {
                    comment = item.Key + "='" + item.Value+ "'";
                    table.DefaultView.RowFilter = comment;
                }
            }
            
            GridView1.DataSource = table;
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            List<Matters> matters = Helper.tryGetMatters(token);
            table = Helper.ToDataTable<Matters>(matters);
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
    }
}