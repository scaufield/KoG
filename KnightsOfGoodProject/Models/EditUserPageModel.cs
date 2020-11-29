using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfGoodProject.Models
{
    public class EditUserPageModel
    {
        [DataType(DataType.Text), Display(Name = "Ваше имя")]
        public string FirstName { get; set; }
        [DataType(DataType.Text), Display(Name = "Ваша фамилия")]
        public string LastName { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:MM.dd.yyyy}")]
        [DataType(DataType.Date), Display(Name = "Дата рождения")]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.Text), Display(Name = "О себе")]
        public string Bio { get; set; }

        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; }

    }

}