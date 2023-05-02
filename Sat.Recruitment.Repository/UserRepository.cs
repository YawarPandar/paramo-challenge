using Microsoft.Extensions.Configuration;
using Sat.Recruitment.Abstractions.Helpers;
using Sat.Recruitment.Abstractions.Repositories;
using Sat.Recruitment.Models.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using static Sat.Recruitment.Models.Configuration.Constants;

namespace Sat.Recruitment.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IErrorHandlerService _errorHandler;
        public UserRepository(IConfiguration configuration, IErrorHandlerService errorHandler)
        {
            _configuration = configuration;
            _errorHandler = errorHandler;
        }
        public UserDto Create(UserDto user)
        {
            /* To implement actual user creation*/
            return user;
        }
        public List<UserDto> GetAllUsers()
        {
            return ReadUsersFromFile();
        }
        private List<UserDto> ReadUsersFromFile()
        {
            List<UserDto> _users = new List<UserDto>();
            var path = AppDomain.CurrentDomain.BaseDirectory + _configuration.GetConnectionString("DefaultConnection");

            if (!File.Exists(path)) { throw _errorHandler.GetCustomException(INVALID_DATA_SOURCE);  }

            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result.Split(',');
                _users.Add(new UserDto
                {
                    Name = line[0].ToString(),
                    Email = line[1].ToString(),
                    Phone = line[2].ToString(),
                    Address = line[3].ToString(),
                    UserType = line[4].ToString(),
                    Money = decimal.Parse(line[5].ToString()),
                });
            }
            reader.Close();
            return _users;
        }
    }
}
