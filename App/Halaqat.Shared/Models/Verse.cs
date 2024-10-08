namespace Halaqat.Shared.Models
{
    public class Verse : ModelBase
    {
        public Sorah Sorah { get; set; }
        public int Number { get; set; }
        public int Page { get; set; }
        public int Quarter { get; set; }
        public int Hezb { get; set; }
        public int Joza { get; set; }
        public string Text { get; set; }
        public string SearchText { get; set; }
    }
}
