﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {//sadsada
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);//veritabanından kontrol edilmeis demek
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
       // IDataResult<UserForLoginDto> CheckPassword(int id,string password);
        //IResult UserExists(string email);//kullanıcı varmı ve maille yapıcaz
        IDataResult<AccessToken> CreateAccessToken(User user);//acces token üretmek  istiyoruz
        //IDataResult<User> GetByUserId(int userId);
    }
}

