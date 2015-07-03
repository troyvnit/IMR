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
                    SettingType = SettingType.Partial_Address, 
                    Avatar = "", 
                    SettingDetails = new List<SettingDetail>
                    { 
                        new SettingDetail
                        {
                            Language = Language.En, 
                            Name = "Address EN", 
                            Description = "<strong>IMR Image-Management GmbH</strong><br>Neue Weilheimer Straße 14<br>73230 Kirchheim u. Teck<br><br>Tel.: 07021 485078<br>Fax.:  07021 83411",
                            Link = ""
                        },
                        new SettingDetail
                        {
                            Language = Language.De, 
                            Name = "Address DE", 
                            Description = "<strong>IMR Image-Management GmbH</strong><br>Neue Weilheimer Straße 14<br>73230 Kirchheim u. Teck<br><br>Tel.: 07021 485078<br>Fax.:  07021 83411",
                            Link = ""
                        },
                        new SettingDetail
                        {
                            Language = Language.Vi, 
                            Name = "Address VI", 
                            Description = "<strong>IMR Image-Management GmbH</strong><br>Neue Weilheimer Straße 14<br>73230 Kirchheim u. Teck<br><br>Tel.: 07021 485078<br>Fax.:  07021 83411",
                            Link = ""
                        }
                    }
                },
                new Setting{
                    SettingType = SettingType.Layout_Header_Slogan, 
                    Avatar = "", 
                    SettingDetails = new List<SettingDetail>
                    { 
                        new SettingDetail
                        {
                            Language = Language.En, 
                            Name = "Slogan EN", 
                            Description = "»The scanning of documents and management of accounts payable are cost-intensive processes. The full range of services provided by IMR in digitisation and archiving releases potential savings and economies of significant proportions.«",
                            Link = ""
                        },
                        new SettingDetail
                        {
                            Language = Language.De, 
                            Name = "Slogan DE", 
                            Description = "»Dokumentenerfassung und Kreditoren-Management sind kostenintensive Abläufe. IMR erschließt mit seinem kompletten Leistungsprogramm der digitalen Erfassung und Archivierung signifikante Einspar- und Rationalisierungspotenziale.«",
                            Link = ""
                        },
                        new SettingDetail
                        {
                            Language = Language.Vi, 
                            Name = "Slogan VI", 
                            Description = "Đang cập nhật khẩu ngữ...",
                            Link = ""
                        }
                    }
                },
                new Setting{
                    SettingType = SettingType.DisclaimerPage_Content, 
                    Avatar = "", 
                    SettingDetails = new List<SettingDetail>
                    { 
                        new SettingDetail
                        {
                            Language = Language.En, 
                            Name = "Disclaimer", 
                            Description = "Updating...",
                            Link = ""
                        },
                        new SettingDetail
                        {
                            Language = Language.De, 
                            Name = "Impressum", 
                            Description = "Aktualisierung...",
                            Link = ""
                        },
                        new SettingDetail
                        {
                            Language = Language.Vi, 
                            Name = "Trách nhiệm", 
                            Description = "Đang cập nhật...",
                            Link = ""
                        }
                    }
                },
                new Setting{
                    SettingType = SettingType.QualityPage_Content, 
                    Avatar = "", 
                    SettingDetails = new List<SettingDetail>
                    { 
                        new SettingDetail
                        {
                            Language = Language.En, 
                            Name = "Certified security and scan quality", 
                            Description = "Updating...",
                            Link = ""
                        },
                        new SettingDetail
                        {
                            Language = Language.De, 
                            Name = "Zertifizierte Sicherheit und Erfassungsqualität", 
                            Description = "Aktualisierung...",
                            Link = ""
                        },
                        new SettingDetail
                        {
                            Language = Language.Vi, 
                            Name = "Chứng nhận an toàn và chất lượng quét", 
                            Description = "Đang cập nhật...",
                            Link = ""
                        }
                    }
                },
                new Setting{
                    SettingType = SettingType.HomePage_MainBox, 
                    Avatar = "icon_company.gif", 
                    SettingDetails = new List<SettingDetail>
                    { 
                        new SettingDetail
                        {
                            Language = Language.En, 
                            Name = "THE COMPANY", 
                            Description = "<p>IMR Image-Management GmbH  is a professional full-service provider for accounts payable management, document management and scanning services. Specialising in accounts payable processes, we tailor our solutions to organisational requirements in companies to fit in with their operational procedures in sales, bookkeeping and accounts in the best possible way. IMR operates with maximum data security and process efficiency to facilitate the rapid and reliable flow of information in the company. And its services are excellent value for money.</p>",
                            Link = "/a/company"
                        },
                        new SettingDetail
                        {
                            Language = Language.De, 
                            Name = "DAS UNTERNEHMEN", 
                            Description = "<p>Die IMR Image-Management GmbH ist der kompetente Full-Service-Dienstleister für Kreditoren- und Dokumentenmanagement sowie Scan-Dienstleistungen. Mit dem Schwerpunkt Kreditoren-Management erstellen wir maßgeschneiderte Lösungen, die optimal in den Arbeitsablauf von Vertrieb, Organisation und Buchhaltung der Unternehmen passen. Mit maximaler Datensicherheit und Prozesseffizienz unterstützt IMR den schnellen und zuverlässigen Datenfluss im Unternehmen. Und das zu einem beispielhaften Preis-Leistungs-Verhältnis.</p>",
                            Link = "/a/unternehmen"
                        },
                        new SettingDetail
                        {
                            Language = Language.Vi, 
                            Name = "CÔNG TY", 
                            Description = "<p>Đang cập nhật...</p>",
                            Link = "/a/công ty"
                        }
                    }
                },
                new Setting{
                    SettingType = SettingType.HomePage_MainBox, 
                    Avatar = "icon_services.gif", 
                    SettingDetails = new List<SettingDetail>
                    { 
                        new SettingDetail
                        {
                            Language = Language.En, 
                            Name = "OUR SERVICES", 
                            Description = "<p>IMR offers the full range of automated document capture and processing services. The main focus is on the digital capture and provision of data as required as well as the flexibility to adapt and incorporate the data in existing business processes. The service is not only for German documents. We also process bills, receipts and documents from all the West European countries in the respective national languages. For our customers there is no need to invest in additional hardware or data capture software.</p>",
                            Link = "/a/services"
                        },
                        new SettingDetail
                        {
                            Language = Language.De, 
                            Name = "UNSERE LEISTUNGEN", 
                            Description = "<p>IMR bietet das komplette Spektrum automatisierter Dokumenten-Erfassung und -Bearbeitung. Im Fokus stehen dabei die digitale Erfassung und Zurverfügungstellung der Daten sowie deren flexible Anpassung und Einbeziehung in bestehende Geschäftsprozesse. Verarbeitet werden nicht nur deutschsprachige Dokumente, sondern Belege aus dem gesamten westeuropäischen Ausland in den jeweiligen Landessprachen. Für unsere Kunden sind dabei keine Investitionen in zusätzliche Hardware oder Datenerfassungssoftware notwendig.</p>",
                            Link = "/a/leistungen"
                        },
                        new SettingDetail
                        {
                            Language = Language.Vi, 
                            Name = "DỊCH VỤ", 
                            Description = "<p>Đang cập nhật...</p>",
                            Link = "/a/dịch vụ"
                        }
                    }
                },
                new Setting{
                    SettingType = SettingType.HomePage_MainBox, 
                    Avatar = "icon_sectors.gif", 
                    SettingDetails = new List<SettingDetail>
                    { 
                        new SettingDetail
                        {
                            Language = Language.En, 
                            Name = "OUR SECTORS", 
                            Description = "<p>Every sector has its specific requirements and needs expert acquaintance with the business and exact knowledge of the target market. We talk to our customers and share professional insights for mutual benefit. This constant dialogue and our many years of experience in projects in a wide and diverse range of sectors enable us to tailor our services to the realities of the business in the best possible way in any given case and to cater to the specific requirements of the company or department.</p>",
                            Link = "/a/sectors"
                        },
                        new SettingDetail
                        {
                            Language = Language.De, 
                            Name = "UNSERE BRANCHEN", 
                            Description = "<p>Jede Branche hat ihre spezifischen Anforderungen und benötigt fachliches Know-how ebenso wie genaue Zielgruppenkenntnis. Durch den kontinuierlichen Dialog und gegenseitigen Kompetenzaustausch mit unseren Kunden und die langjährige Projekterfahrung in den unterschiedlichsten Branchen können wir unsere Leistungen optimal sowohl auf die jeweiligen branchenspezifischen Gegebenheiten als auch auf die Bedürfnisse des Unternehmens/der Abteilung anpassen.</p>",
                            Link = "/a/branchen"
                        },
                        new SettingDetail
                        {
                            Language = Language.Vi, 
                            Name = "LĨNH VỰC", 
                            Description = "<p>Đang cập nhật...</p>",
                            Link = "/a/lĩnh vực"
                        }
                    }
                },
            };
            context.Settings.AddRange(settings);
            context.SaveChanges();

            var articleCategories = new List<ArticleCategory>
            {
                new ArticleCategory
                {
                    ArticleCategoryDetails = new List<ArticleCategoryDetail> 
                    {
                        new ArticleCategoryDetail 
                        {
                            Language = Language.En,
                            Name = "Company"
                        },
                        new ArticleCategoryDetail 
                        {
                            Language = Language.De,
                            Name = "Unternehmen"
                        },
                        new ArticleCategoryDetail 
                        {
                            Language = Language.Vi,
                            Name = "Công ty"
                        }
                    }
                },
                new ArticleCategory
                {
                    ArticleCategoryDetails = new List<ArticleCategoryDetail> 
                    {
                        new ArticleCategoryDetail 
                        {
                            Language = Language.En,
                            Name = "Services"
                        },
                        new ArticleCategoryDetail 
                        {
                            Language = Language.De,
                            Name = "Leistungen"
                        },
                        new ArticleCategoryDetail 
                        {
                            Language = Language.Vi,
                            Name = "Dịch vụ"
                        }
                    }
                },
                new ArticleCategory
                {
                    ArticleCategoryDetails = new List<ArticleCategoryDetail> 
                    {
                        new ArticleCategoryDetail 
                        {
                            Language = Language.En,
                            Name = "Sectors"
                        },
                        new ArticleCategoryDetail 
                        {
                            Language = Language.De,
                            Name = "Branchen"
                        },
                        new ArticleCategoryDetail 
                        {
                            Language = Language.Vi,
                            Name = "Lĩnh vực"
                        }
                    }
                }
            };
            context.ArticleCategories.AddRange(articleCategories);
            context.SaveChanges();

            foreach (var articleCategory in articleCategories)
            {
                var article = new Article
                {
                    ArticleDetails = new List<ArticleDetail> 
                    {
                        new ArticleDetail 
                        {
                            Language = Language.En,
                            Title = articleCategory.ArticleCategoryDetails.FirstOrDefault(ac => ac.Language == Language.En).Name,
                            Description = "",
                            Content = ""
                        },
                        new ArticleDetail 
                        {
                            Language = Language.De,
                            Title = articleCategory.ArticleCategoryDetails.FirstOrDefault(ac => ac.Language == Language.De).Name,
                            Description = "",
                            Content = ""
                        },
                        new ArticleDetail 
                        {
                            Language = Language.Vi,
                            Title = articleCategory.ArticleCategoryDetails.FirstOrDefault(ac => ac.Language == Language.Vi).Name,
                            Description = "",
                            Content = ""
                        } 
                    },
                    ArticleCategoryId = articleCategory.ArticleCategoryId,
                    ArticleCategory = articleCategory
                };
                context.Articles.Add(article);
                context.SaveChanges();

                articleCategory.MainArticleId = article.ArticleId;
                context.Entry(articleCategory).State = EntityState.Modified;
                context.SaveChanges();
            }        
        }
    }
}