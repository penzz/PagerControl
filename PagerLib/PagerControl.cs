using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace PagerLib
{
    /// <summary>
    /// 分页控件
    /// </summary>
    public partial class PagerControl : UserControl
    {
        #region property
        private int lastPage;
        /// <summary>
        /// 获取与设置每页记录数 
        /// </summary>
        private int rowsPerPage;

        public int RowsPerPage
        {
            get
            {
                if (rowsPerPage <= 0)
                {
                    return 5;
                }
                return rowsPerPage;
            }
            set
            {
                if (rowsPerPage == value)
                {
                    return;
                }
                rowsPerPage = value;
                this.ComboBoxRowsPerPage.Text = rowsPerPage.ToString();
                CalcPageValue();
            }
        }
        /// <summary>
        /// 获取总页数
        /// </summary>
        private int totalPage;

        public int TotalPage
        {
            get { return totalPage; }
            set
            {
                if (totalPage == value)
                {
                    return;
                }
                totalPage = value;
                CalcPageValue();
            }
        }
        /// <summary>
        /// 获取与设置当前页数
        /// </summary>     
        private int currentPage;

        public int CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                if (currentPage == value)
                {
                    return;
                }
                currentPage = value;
                this.txtCurrentPage.Text = currentPage.ToString();
            }
        }
        /// <summary>
        /// 总记录数
        /// </summary>     
        private int recordCount;

        public int RecordCount
        {
            get { return recordCount; }
            set
            {
                if (recordCount == value)
                {
                    return;
                }
                recordCount = value;
                CalcPageValue();
            }
        }
        #endregion

        #region ctor
        ///<summary>
        /// 构造函数
        /// </summary>
        public PagerControl()
        {
            InitializeComponent();
            this.BackColorChanged += new EventHandler(PagerControl_BackColorChanged);
            this.BackColor = Color.FromArgb(194, 217, 247);
            this.bindingNavigator.BackColor = this.BackColor;
        }
        #endregion

        #region method
        /// <summary>
        /// 计算控件的各属性值
        /// </summary>
        private void CalcPageValue()
        {
            //每页显示的记录数为空，则返回不计算
            if (rowsPerPage <= 0)
            {
                return;
            }
            //计算。如果总记录数与每页显示的记录数可以整除，则总页数即为总记录数与每页显示的记录数的除数
            if (recordCount % rowsPerPage == 0)
            {
                totalPage = (int)(recordCount / rowsPerPage);
            }
            //否则总页数为总记录数与每页显示的记录数的除数加1
            else
            {
                totalPage = (int)(recordCount / rowsPerPage) + 1;
            }
            //默认设置当前页为第1页
            this.CurrentPage = 1;
            //更新按钮可用性和属性值
            UpdateAllValue();
        }
        /// <summary>
        /// 更新按钮可用性和属性值
        /// </summary>
        private void UpdateAllValue()
        {
            //默认将按钮均可用
            this.bindingNavigatorMoveFirstItem.Enabled = true;
            this.bindingNavigatorMovePreviousItem.Enabled = true;
            this.bindingNavigatorMoveLastItem.Enabled = true;
            this.bindingNavigatorMoveNextItem.Enabled = true;
            //如果当前页不大于1，则前一页与第一页按钮不可用
            if (this.CurrentPage <= 1)
            {
                this.bindingNavigatorMoveFirstItem.Enabled = false;
                this.bindingNavigatorMovePreviousItem.Enabled = false;
            }
            //如果当前页不小于总页数，则后一页与最后页按钮不可用
            if (this.CurrentPage >= this.TotalPage)
            {
                this.bindingNavigatorMoveLastItem.Enabled = false;
                this.bindingNavigatorMoveNextItem.Enabled = false;
            }
            //更新界面显示的属性值
            this.txtCurrentPage.Text = this.CurrentPage.ToString();
            lastPage = Convert.ToInt32(this.txtCurrentPage.Text);
            this.lblCountPage.Text = this.TotalPage.ToString();
            this.ComboBoxRowsPerPage.Text = this.RowsPerPage.ToString();
            this.lblCountRecord.Text = this.RecordCount.ToString();
            //触发事件，通知外部注册更新当前显示页数记录等信息。
            OnPageChange();
            OnPageChange(this);
        }
        #endregion

        #region events
        /// <summary>
        /// 第一条
        /// </summary>
        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            this.CurrentPage = 1;
            UpdateAllValue();
        }
        /// <summary>
        /// 上一条
        /// </summary>
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            this.CurrentPage--;
            UpdateAllValue();
        }
        /// <summary>
        /// 下一条
        /// </summary>
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            this.CurrentPage++;
            UpdateAllValue();
        }
        /// <summary>
        /// 最后条
        /// </summary>
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            this.CurrentPage = TotalPage;
            UpdateAllValue();
        }
        /// <summary>
        /// 每页显示几条改变事件
        /// </summary>
        private void ComboBoxRowsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RowsPerPage = Convert.ToInt32(this.ComboBoxRowsPerPage.SelectedItem.ToString());
        }

        /// <summary>
        /// 当前页数改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCurrentPage_TextChanged(object sender, EventArgs e)
        {
            if (this.bindingNavigator.Enabled == false)
            {
                return;
            }
            int newPage;
            if (!Int32.TryParse(this.txtCurrentPage.Text, out newPage))
            {
                this.txtCurrentPage.Text = lastPage.ToString();
                return;
            }
            if (TotalPage == 0)
            {
                return;
            }
            if (newPage > this.TotalPage || newPage < 0)
            {
                this.txtCurrentPage.Text = lastPage.ToString();
                return;
            }
            this.currentPage = newPage;
            UpdateAllValue();
        }
        /// <summary>
        /// 分页控件背景颜色随着母窗体的背景颜色变化而变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void PagerControl_BackColorChanged(object sender, EventArgs e)
        {
            this.bindingNavigator.BackColor = this.BackColor;
        }
        #endregion

        #region 外部事件注册
        /// <summary>
        /// 无参事件，需要用户自己知道是哪个对象触发该事件
        /// </summary>
        public event Action PageChange;
        /// <summary>
        /// 触发无对象事件
        /// </summary>
        private void OnPageChange()
        {
            Action temp = Interlocked.CompareExchange(ref PageChange, null, null);
            if (temp != null)
            {
                temp();
            }
        }

        /// <summary>
        /// 有对象事件，可以得到触发该事件的分页控件对象
        /// </summary>
        public event Action<object> PageChangeWithObject;
        /// <summary>
        /// 触发有对象事件
        /// </summary>
        /// <param name="sender">对象</param>
        private void OnPageChange(PagerControl sender)
        {
            Action<object> temp = Interlocked.CompareExchange(ref PageChangeWithObject, null, null);
            if (temp != null)
            {
                temp(sender);
            }
        }
        #endregion
    }
}
