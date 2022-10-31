using Dapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;

namespace HPPay.DataRepository.DBDapper
{
    public class DapperContextBase
    {



        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            if (sp is null)
            {
                throw new ArgumentNullException(nameof(sp));
            }

            if (parms is null)
            {
                throw new ArgumentNullException(nameof(parms));
            }

            throw new NotImplementedException();
        }
    }

    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            string displayName;
            displayName = enumValue.GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
            if (String.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }
    }
}