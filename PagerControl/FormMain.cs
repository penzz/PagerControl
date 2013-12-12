using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagerControl
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            //this.pagerControlTest.PageChange += pagerControlTest_PageChange;
            this.pagerControlTest.PageChangeWithObject += pagerControlTest_PageChangeWithObject;
            //GetSource();
        }
        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="obj"></param>
        void pagerControlTest_PageChangeWithObject(object obj)
        {
            PagerLib.PagerControl pager = obj as PagerLib.PagerControl;
            if (pager != null)
            {
                Console.WriteLine(pager.Name);
            }
        }
        /// <summary>
        /// 事件处理
        /// </summary>
        void pagerControlTest_PageChange()
        {
            GetSource();
        }
        /// <summary>
        /// 处理分页
        /// </summary>
        private void GetSource()
        {
            //获得总记录条数
            //string sqlcount = "select count(*) from originaldata";
            //pagerControlTest.RecordCount = DBAccess.GetCount(sqlcount);
            //获得当前页
            int cur = pagerControlTest.CurrentPage;
            //获得每页显示的记录数
            int rows = pagerControlTest.RowsPerPage;
            //计算显示记录的开始值
            int start = (cur - 1) * rows;
            //计算显示记录的结束值
            int end = cur * rows + 1;
            //获得从开始值到结束值的记录
            //string sql = string.Format("select * from (select rownum rn,t.* from (select * from originaldata) t where rownum <{0}) where rn>{1}", end, start);
            //DataTable DT = DBAccess.GetDataTable(sql);
            //将得到的记录绑定到DataGridView显示给用户
            //.dataGridView1.DataSource = DT.DefaultView;
        }
    }
}
