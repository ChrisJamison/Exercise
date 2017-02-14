using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DataModel.UnitOfWork;

namespace BusinessServices
{
    public class UserServices : IUserServices
    {
         private readonly UnitOfWork _unitOfWork;
         public UserServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
         public List<DataModel.User> GetAllUsers()
        {
            var promotions = _unitOfWork.UserRepository.GetAll().ToList();
            return promotions;
        }


         public DataModel.User CreateUser(DataModel.User user)
         {
             using (var scope = new TransactionScope())
             {
                 _unitOfWork.UserRepository.Insert(user);
                 _unitOfWork.Save();
                 scope.Complete();
                 return user;
             }
         }
    }
}
