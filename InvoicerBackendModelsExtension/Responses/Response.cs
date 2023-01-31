using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicerBackendModelsExtension.Responses
{
    public record Response<T>(T Data, IEnumerable<string>? Errors, string Message, bool Success) where T : class
    {

    }

    public record EnumerableResponse<T>(IEnumerable<T> Data, bool Success) where T : class;
}
