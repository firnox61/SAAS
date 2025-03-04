﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
        /* IDataResult<User> GetByEmailUser(string email);
         IDataResult<List<UserDetailDto>> GetUserDetailDtos();
         IDataResult<UserDetailDto> GetUserByDetail(int id);
         IDataResult<User> GetByUserId(int userId);
         IDataResult<List<User>> GetAll();*/
        /* IResult Update(User user);
         IResult Delete(User user);
         IResult EditProfil(User user, string password);*/
    }
}
