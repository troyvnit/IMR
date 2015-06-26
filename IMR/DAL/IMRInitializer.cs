using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IMR.Models;
using IMR.Models.Enums;

namespace IMR.DAL
{
    public class IMRInitializer : CreateDatabaseIfNotExists<IMRContext>
    {
        protected override void Seed(IMRContext context)
        {
            var settings = new List<Setting>
            {
                new Setting{
                    SettingType = SettingType.Layout_Header_Slogan, 
                    Avatar = "", 
                    SettingDetails = new List<SettingDetail>
                    { 
                        new SettingDetail
                        {
                            Language = Language.En, 
                            Name = "Slogan En", 
                            Description = "",
                            Link = ""
                        }
                    }
                }
            };
        }
    }
}