﻿namespace ep.Contract.RequestModels
{
    public class UserRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Password{ get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
