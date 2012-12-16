using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MM.DAL
{

    /// <summary>
    /// This is the Join Record (Rocky's Assignment)
    /// </summary>
    public class ContactInfoAssignmentDTO : mmDTObase
    {
        public int RenterID { get; set; }
        public int ContactInfoItemID { get; set; }
        public int ContactInfoType { get; set; }
        public DateTime Assigned { get; set; }
        public List<ContactInfoDTO> ContactInfoList { get; set; }
    }
}
