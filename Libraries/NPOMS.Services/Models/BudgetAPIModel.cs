using Microsoft.Graph;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using System.Collections.Generic;

namespace NPOMS.Services.Models
{
    public class BudgetAPIModel
    {
        public string source { get; set; }
        public string nationalprovincial { get; set; }
        public string financialyear { get; set; }
        public string departmentname { get; set; }
        public string assetslowestlevelcode { get; set; }
        public string assetslowestlevel { get; set; }
        public string assetslevel1 { get; set; }
        public string assetslevel2 { get; set; }
        public string assetslevel3 { get; set; }
        public string assetslevel4 { get; set; }
        public string assetslevel5 { get; set; }
        public string assetslevel6 { get; set; }
        public string assetslevel7 { get; set; }
        public string assetslevel8 { get; set; }
        public string assetslevel9 { get; set; }
        public string assetslevel10 { get; set; }
        public string econclass { get; set; }
        public string inconsistenteconclass { get; set; }
        public string funcclasslevel1 { get; set; }
        public string funcclasslevel2 { get; set; }
        public string funcclasslowestlevel { get; set; }
        public string fundlowestlevelcode { get; set; }
        public string fundlowestlevel { get; set; }
        public string fundlevel1 { get; set; }
        public string fundlevel2 { get; set; }
        public string fundlevel3 { get; set; }
        public string fundlevel4 { get; set; }
        public string fundlevel5 { get; set; }
        public string fundlevel6 { get; set; }
        public string fundlevel7 { get; set; }
        public string fundlevel8 { get; set; }
        public string fundlevel9 { get; set; }
        public string ictitem { get; set; }
        public string ictresp { get; set; }
        public string infrastructurelowestlevelcode { get; set; }
        public string infrastructurelowestlevel { get; set; }
        public string infrastructurelevel1 { get; set; }
        public string infrastructurelevel2 { get; set; }
        public string infrastructurelevel3 { get; set; }
        public string infrastructurelevel4 { get; set; }
        public string infrastructurelevel5 { get; set; }
        public string infrastructurelevel6 { get; set; }
        public string itemlowestlevelcode { get; set; }
        public string itemlowestlevel { get; set; }
        public string itemlevel1 { get; set; }
        public string itemlevel2 { get; set; }
        public string itemlevel3 { get; set; }
        public string itemlevel4 { get; set; }
        public string itemlevel5 { get; set; }
        public string itemlevel6 { get; set; }
        public string itemlevel7 { get; set; }
        public string itemlevel8 { get; set; }
        public string itemlevel9 { get; set; }
        public string itemlevel10 { get; set; }
        public string itemlevel11 { get; set; }
        public string programmelevel5 { get; set; }
        public string subprogrammelevel6 { get; set; }
        public string objectivelowestlevelcode { get; set; }
        public string objectivelowestlevel { get; set; }
        public string objectivelevel1 { get; set; }
        public string objectivelevel2 { get; set; }
        public string objectivelevel3 { get; set; }
        public string objectivelevel4 { get; set; }
        public string objectivelevel5 { get; set; }
        public string objectivelevel6 { get; set; }
        public string objectivelevel7 { get; set; }
        public string objectivelevel8 { get; set; }
        public string objectivelevel9 { get; set; }
        public string objectivelevel10 { get; set; }
        public string projectlowestlevelcode { get; set; }
        public string projectlowestlevel { get; set; }
        public string projectlevel1 { get; set; }
        public string projectlevel2 { get; set; }
        public string projectlevel3 { get; set; }
        public string projectlevel4 { get; set; }
        public string projectlevel5 { get; set; }
        public string projectlevel6 { get; set; }
        public string projectlevel7 { get; set; }
        public string projectlevel8 { get; set; }
        public string projectlevel9 { get; set; }
        public string projectlevel10 { get; set; }
        public string projectlevel11 { get; set; }
        public string regionalidlowestlevelcode { get; set; }
        public string regionalidlowestlevel { get; set; }
        public string regionalidlevel1 { get; set; }
        public string regionalidlevel2 { get; set; }
        public string regionalidlevel3 { get; set; }
        public string regionalidlevel4 { get; set; }
        public string regionalidlevel5 { get; set; }
        public string regionalidlevel6 { get; set; }
        public string regionalidlevel7 { get; set; }
        public string regionalidlevel8 { get; set; }
        public string researchanddevcode { get; set; }
        public string researchanddevclassification { get; set; }
        public string responsibilitylowestlevelcode { get; set; }
        public string responsibilitylowestlevel { get; set; }
        public string responsibilitylevel1 { get; set; }
        public string responsibilitylevel2 { get; set; }
        public string responsibilitylevel3 { get; set; }
        public string responsibilitylevel4 { get; set; }
        public string responsibilitylevel5 { get; set; }
        public string responsibilitylevel6 { get; set; }
        public string responsibilitylevel7 { get; set; }
        public string responsibilitylevel8 { get; set; }
        public string responsibilitylevel9 { get; set; }
        public string responsibilitylevel10 { get; set; }
        public string responsibilitylevel11 { get; set; }
        public string responsibilitylevel12 { get; set; }
        public string responsibilitylevel13 { get; set; }
        public string responsibilitylevel14 { get; set; }
        public string responsibilitylevel15 { get; set; }
        public string sonoprogramnumber { get; set; }
        public string sonosubprogrevcode { get; set; }
        public string originalbudget { get; set; }
        public string availablebudget { get; set; }
        public string currentbudget { get; set; }
        public string commitment { get; set; }
        public string virement { get; set; }
        public string finalvirementshifts { get; set; }
        public string fundshift { get; set; }
        public string rollover { get; set; }
    }

    public class BudgetAPIWrapperModel
    {
        public string name { get; set; }
        public List<BudgetAPIModel> elements { get; set; }
    }
}
