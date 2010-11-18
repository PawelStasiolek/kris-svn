using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartControl
{
    [ToolboxData("<{0}:SmartGridView runat=server></{0}:SmartGridView>")]
    public class SmartGridView : GridView
    {
        /// <summary>
        /// 纵向合并单元格
        /// </summary>
        /// <param name="columns">需要合并的列的序号</param>
        public void GroupRows(params int[] columns)
        {
            foreach(int columnNum in columns)
            {
                int i = 0, rowSpanNum = 1;
                while (i < this.Rows.Count - 1)
                {
                    GridViewRow row1 = this.Rows[i];
                    for (++i; i < this.Rows.Count; i++)
                    {
                        GridViewRow row2 = this.Rows[i];
                        if (row1.Cells[columnNum].Text.Trim() == row2.Cells[columnNum].Text.Trim())
                        {
                            row2.Cells[columnNum].Visible = false;
                            rowSpanNum++;
                        }
                        else
                        {
                            row1.Cells[columnNum].RowSpan = rowSpanNum;
                            rowSpanNum = 1;
                            break;
                        }
                        if (i == this.Rows.Count - 1)
                        {
                            row1.Cells[columnNum].RowSpan = rowSpanNum;
                        }
                    }
                }
            }
        }

        
    }
}
