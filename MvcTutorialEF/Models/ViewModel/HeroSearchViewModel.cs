using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcTutorialEF.Models.ViewModel
{
    public class HeroSearchViewModel
    {   
        private readonly List<GenderOptions> _genderOptions = new List<GenderOptions>
        {
            new GenderOptions() { DisplayText = "男", OptionValue = "male"},
            new GenderOptions() { DisplayText = "女", OptionValue = "female"},
        };
        // 搜尋條件
        public HeroSearchParams SearchParams { get; set; }
        // 搜尋結果(英雄們)
        public List<TblHero> Heroes { get; set; }
        // 下拉選單選項
        public SelectList GenderSelectList { get; set; }

        public HeroSearchViewModel()
        {
            // 初始化記憶體 => 把房間打掃乾淨，才能入住
            SearchParams = new HeroSearchParams();
            Heroes = new List<TblHero>();
            GenderSelectList = new SelectList(_genderOptions, "OptionValue", "DisplayText");
        }
    }
    public class HeroSearchParams
    {
        public int MinAtk { get; set; }
        public int MaxAtk { get; set; }
        public string Gender { get; set; }
    }

    public class GenderOptions
    {
        public string OptionValue { get; set; }
        public string DisplayText { get; set; }
    }
}
