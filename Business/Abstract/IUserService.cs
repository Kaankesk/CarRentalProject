using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetAll();
        IDataResult<List<OperationClaimDto>> GetClaims(User user);
        IDataResult<User> GetbyMail(string email);

    }
}
