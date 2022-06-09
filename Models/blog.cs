using System.ComponentModel.DataAnnotations;

namespace testaundit.Models
{
    public class blog
    {
        [Display(Name="Имя блога")]
        public string Id { get; set; }
        public string Name { get; set; }
        public int user_id { get; set;  }
        public ApplicationUser? user { get; set; }
        [UIHint("MultilineTex")]
        public string text { get; set; }
    }
}
