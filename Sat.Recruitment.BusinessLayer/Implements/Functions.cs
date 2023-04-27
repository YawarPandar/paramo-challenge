using Sat.Recruitment.Abstractions.Business;
using Sat.Recruitment.Abstractions.Helpers;
using Sat.Recruitment.Models.Dto;
using System;
using System.Text.RegularExpressions;
using static Sat.Recruitment.Abstractions.Helpers.IConstants;

namespace Sat.Recruitment.BusinessLayer.Implements
{
    public class Functions : IFunctions
    {
        private readonly IErrorHandler _errorHandler;
        public Functions(IErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
        }
        public void UpdateGif(ref UserDto user)
        {
            decimal gif(decimal userMoney, decimal percentage)
            {
                return userMoney * percentage;
            }

            if (!Enum.TryParse(user.UserType, out UserType userType)) 
                throw _errorHandler.RaiseException(INVALID_USER_TYPE);

            switch (userType)
            {
                case UserType.Normal:
                    if (user.Money > 100) //If new user is normal and has more than USD100
                    {
                        user.Money += gif(user.Money, Convert.ToDecimal(0.12));
                    } else if (user.Money < 100 && user.Money > 10)
                    {
                        user.Money += gif(user.Money, Convert.ToDecimal(0.8));
                    }
                    break;
                case UserType.SuperUser:
                    if (user.Money > 100)
                    {
                        user.Money += gif(user.Money, Convert.ToDecimal(0.20));
                    }
                    break;
                case UserType.Premium:
                    if (user.Money > 100)
                    {
                        user.Money += gif(user.Money, 2);
                    }
                    break;
            }
        }
        public string NormalizeEmail(string email)
        {
            if (!IsValid(email)) throw _errorHandler.RaiseException(INVALID_EMAIL);

            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);
            return string.Join("@", aux[0], aux[1]);
        }
        private bool IsValid(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }
    }
}
