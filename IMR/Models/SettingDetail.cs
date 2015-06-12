using IMR.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.Models
{
    public class SettingDetail
    {
        public int SettingDetailId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public Language Language { get; set; }
        public int SettingId { get; set; }
        public Setting Setting { get; set; }
    }
}