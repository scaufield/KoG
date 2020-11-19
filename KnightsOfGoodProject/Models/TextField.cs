using System.ComponentModel.DataAnnotations;
//В этом классе будет содержание (текстовое?) какой-то страницы (контакты, главная)
namespace KnightsOfGoodProject.Models
{
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { get; set; } = "Информационная страница";

        [Display(Name = "Cодержание страницы")]
        public override string Text { get; set; } = "Содержание заполняется администратором";
    }
}
