using IMR.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMR.Areas.BO.Models
{
    public class SettingBO
    {
        public int SettingId { get; set; }
        public string Avatar { get; set; }
        public SettingType SettingType { get; set; }
        public int IdEn { get; set; }
        public string NameEn { get; set; }
        public string DescriptionEn { get; set; }
        public string LinkEn { get; set; }
        public int IdDe { get; set; }
        public string NameDe { get; set; }
        public string DescriptionDe { get; set; }
        public string LinkDe { get; set; }
        public int IdVi { get; set; }
        public string NameVi { get; set; }
        public string DescriptionVi { get; set; }
        public string LinkVi { get; set; }
    }
}