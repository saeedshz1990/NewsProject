namespace NewsManagement.Application.Contracts.NewsCategory
{
    public class NewsCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int ShowOrder { get; set; }
        public string CreationDate { get; set; }
        public long NewsCount { get; set; }

    }

}
