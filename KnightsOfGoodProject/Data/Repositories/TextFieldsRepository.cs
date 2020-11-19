using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using KnightsOfGoodProject.Data;
using KnightsOfGoodProject.Repositories.Abstract;
using KnightsOfGoodProject.Models;


//Этот класс реалтзует все методы соответствующего интерфейса 
namespace KnightsOfGoodProject.Data.Repositories
{
    public class TextFieldsRepository : ITextFieldsRepository
    {
        //Связываем этот класс с контекстом
        private readonly ApplicationDbContext context;
        public TextFieldsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<TextField> GetTextFields()
        {
            return context.TextFields;
        }

        public TextField GetTextFieldById(Guid id)
        {
            return context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        //При сохранении контекста будет подразумеваться, что объекта нет он его добавит, иначе объект есть, но он изменен
        public void SaveTextField(TextField entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTextField(Guid id)
        {
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }
    }
}
