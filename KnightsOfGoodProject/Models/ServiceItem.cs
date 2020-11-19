using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KnightsOfGoodProject.Models;
//Какая-то услуга на сайте, (в нашем случае мероприятие)
namespace KnightsOfGoodProject.Models
{
    public class ServiceItem : EntityBase
    {
      

        [Required(ErrorMessage = "Заполните название мероприятия")]
        [Display(Name = "Название мероприятия")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание мероприятия")]
        public override string Subtitle { get; set; }

        [Display(Name = "Дата")]
        public  string Date { get; set; }

        [Display(Name = "Время")]
        public  string Time { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата и время")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Полное описание мероприятия")]
        public override string Text { get; set; }


    }
}
