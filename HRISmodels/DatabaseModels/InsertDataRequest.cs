using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISdatabaseModels.DatabaseModels
{
    public class InsertDataRequest
    {
        public string TableName { get; set; }
        public string ColumnList { get; set; }
        public string ValueList { get; set; }
        public int CreateBy { get; set; }
    }
}
