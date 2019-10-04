using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Data.Enums
{
    public enum BillStatus
    {
        New,            // Bill mới đặt, chưa có helper nào nhận                       SortOrder = 1
        IsChanging,     // Customer đang edit bill khi chưa có helper nào nhận         SortOrder = 2
        Inprocess,      // Bill đã có helper nhận                                      SortOrder = 3
        Cancelled,      // Bill bị customer hủy                                        SortOrder = 6
        Incomplete,     // Bill helper nhận làm nhưng không check đầy đủ               SortOrder = 5
        Completed       // Bill đã hoàn thành                                          SortOrder = 4
    }
}
