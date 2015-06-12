using IMR.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.Models
{
    public class Setting
    {
        public int SettingId { get; set; }
        public string Avatar { get; set; }
        public SettingType SettingType { get; set; }
        public ICollection<SettingDetail> SettingDetails { get; set; }
    }
}