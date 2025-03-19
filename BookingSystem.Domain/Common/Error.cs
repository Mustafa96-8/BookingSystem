using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Common;
public class Error
{

    public string Code { get; private set; }

    public string Message { get; private set; }

    public Error(string code,string message)
    {
        Code = code;
        Message = message;
    }
}

public static class Errors
{

    /// <summary>
    /// Список общих ошибок
    /// </summary>
    public static class General
    {
        public static Error NotFound(Guid? id = null)
        {
            var forId = id == null ? "" : $" for id = {id}" ;
            return new Error("record.notFound", $"Record not found{forId}");
        }

        public static Error ValueIsRequired(string? field = null) =>
            new Error("value.is.Required", $"The value is required {field}");

        public static Error ValueIsInvalid(string? field = null) =>
            new Error("value.is.Invalid", $"The value is invalid {field}");

        public static Error InvalidLength(string? field = null) =>
            new Error("value.length.is.invalid", $"The value length is invalid {field}");
    }
}
