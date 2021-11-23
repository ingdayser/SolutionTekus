using System;
using System.Collections.Generic;

namespace Tekus.Core.Application.Helpers
{
    public sealed class RequestResult<T>
    {
        #region Fields
       
        public bool IsSuccessful { get; set; }
        public bool IsError { get; set; }   
        public IEnumerable<string> ErrorMessages { get; set; }
        public dynamic Result { get; set; }

        #endregion

        #region Builders
        public RequestResult()
        {
        }

        internal RequestResult(bool isSuccessful, bool isError, IEnumerable<string> errorMessages, dynamic result)
        {
            IsSuccessful = isSuccessful;
            IsError = IsError;
            ErrorMessages = errorMessages;
            Result = result;
        }

        #endregion

        #region Methods
    
        public static RequestResult<T> CreateSuccessful(dynamic result) => new RequestResult<T>(true, false,null, result);
      
        public static RequestResult<T> CreateUnsuccessful(IEnumerable<string> errorMessages) => new RequestResult<T>(false, false,errorMessages, null);

        public static RequestResult<T> CreateError(Exception ex)
        {
           IEnumerable<string> errorMessages = new string[] { ex.Message,ex.StackTrace};
            return new RequestResult<T>(false,true,errorMessages,null);
        }

        #endregion
    }
}
