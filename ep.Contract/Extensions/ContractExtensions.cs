using ep.Contract.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ep.Contract.Extensions
{
    public static class ContractExtensions
    {
        public static ResponseView<T> ToResponse<T>(this T data, int totalCount)
        {
            var response = new ResponseView<T>(data, totalCount);
            return response;
        }
    }
}
