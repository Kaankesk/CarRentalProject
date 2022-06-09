using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DataDbContext>, IUserDal
    {
        public List<OperationClaimDto> GetClaims(User user)
        {
            using (DataDbContext context = new DataDbContext())
            {
                /* -- Aşağıdaki SQL query'nin LinQ versiyonu aşağıda yazılmaktadır:
                 * Select operationClaim
                 * FROM UserOperationClaims
                 *      JOIN OperationClaims ON UserOperationClaims.OperationClaimId = OperationClaims.Id
                 */
                var result = from userOperationClaim in context.UserOperationClaims
                             join operationClaim in context.OperationClaims
                                on userOperationClaim.OperationClaimId  equals operationClaim.Id
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaimDto { Id=operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
