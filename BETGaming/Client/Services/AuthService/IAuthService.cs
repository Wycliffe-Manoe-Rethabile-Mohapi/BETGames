﻿namespace BETGaming.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegister userRegister);
    }
}
