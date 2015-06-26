using IMR.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.ViewModels
{
    public class SettingVM
    {
        public int SettingId { get; set; }
        public string Avatar { get; set; }
        public SettingType SettingType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}