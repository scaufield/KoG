using KnightsOfGoodProject.Data.Repositories.Abstract;
using KnightsOfGoodProject.Repositories.Abstract;

namespace KnightsOfGoodProject.Service
{
    public class DataManager
    {
      
        public IHomeRepository HomeRepository { get; set; }
        public IAccountRepository AccountRepository { get; set; }
        public IServiceItemsRepository ServiceItemsRepository { get; set; }
        public IUserService UserService { get; set; }
        public ITextFieldsRepository TextFields { get; set; }

        public DataManager(IHomeRepository homeRepository,
          IAccountRepository accountRepository,
          IServiceItemsRepository serviceItemsRepository, 
          ITextFieldsRepository textFieldsRepository,
          IUserService userService
          )
        {
            HomeRepository = homeRepository;
            AccountRepository = accountRepository;
            ServiceItemsRepository = serviceItemsRepository;
            UserService = userService;
            TextFields = textFieldsRepository;
        }
    }
}
 