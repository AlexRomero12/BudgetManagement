// <copyright file="AccountController.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BudgetManagement.Controllers
{
    using BudgetManagement.Models;
    using BudgetManagement.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    /// <summary>
    /// Account Controller.
    /// </summary>
    public class AccountController : Controller
    {
        private readonly IRepositoryAccountsTypes repositoryAccountsTypes;
        private readonly IServiceUser serviceUser;

        public AccountController(IRepositoryAccountsTypes repositoryAccountsTypes, IServiceUser serviceUser)
        {
            this.repositoryAccountsTypes = repositoryAccountsTypes;
            this.serviceUser = serviceUser;
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var userID = this.serviceUser.GetUserID();
            var accounType = await this.repositoryAccountsTypes.GetByUserID(userID);
            var model = new AccountCreationViewModel
            {
                AccountTypes = accounType.Select(s => new SelectListItem(s.Name, s.ID.ToString())),
            };
            return this.View(model);
        }
    }
}
