using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KnightsOfGoodProject.Models
{
    public class ChangePasswordModel
    {
        [Required, DataType(DataType.Password), Display(Name ="Действующий пароль")]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Повторите новый пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают!")]
        public string ConfirmNewPassword { get; set; }
    }
}