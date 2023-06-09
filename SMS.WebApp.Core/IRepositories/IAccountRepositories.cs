﻿using SMS.WebApp.Data.Helper;
using SMS.WebApp.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.WebApp.Core.IRepositories
{
    public interface IAccountRepositories
    {
        Task<DataResult> LoginAsync(LoginViewModel model);
        Task<DataResult> RegisterAsync(RegisterViewModel model);
        Task<DataResult> LogoutAsync();
    }
}
