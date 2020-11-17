using KnightsOfGoodProject.Data.Repositories.Abstract;


namespace KnightsOfGoodProject.Service
{
    public class DataManager
    {
      
        public IHomeRepository HomeRepository { get; set; }
        public IAccountRepository AccountRepository { get; set; }

        public DataManager(IHomeRepository homeRepository,
          IAccountRepository accountRepository)
        {
            HomeRepository = homeRepository;
            AccountRepository = accountRepository;
        }
    }
}
 