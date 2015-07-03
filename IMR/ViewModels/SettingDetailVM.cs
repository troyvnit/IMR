using IMR.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.ViewModels
{
    public class SettingDetailVM
    {
        public int SettingDetailId { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public Language Language { get; set; }
    }
}