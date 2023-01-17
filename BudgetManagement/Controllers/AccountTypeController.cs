// <copyright file="AccountTypeController.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BudgetManagement.Controllers
{
    using BudgetManagement.Models;
    using BudgetManagement.Services;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for handling actions related to account types.
    /// </summary>
    public class AccountTypeController : Controller
    {
        private readonly IRepositoryAccountsTypes repositoryAccountsTypes;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTypeController"/> class.
        /// </summary>
        /// <param name="repositoryAccountsTypes">Irepository accounts types.</param>
        public AccountTypeController(IRepositoryAccountsTypes repositoryAccountsTypes)
        {
            this.repositoryAccountsTypes = repositoryAccountsTypes;
        }

        /// <summary>
        /// Renders the create view.
        /// </summary>
        /// <returns>The create view.</returns>
        public IActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// Create accountType in DB.
        /// </summary>
        /// <param name="accountType">Account type model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(AccountType accountType)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(accountType);
            }

            accountType.UserID = 2;

            var exist = await this.repositoryAccountsTypes.Exists(accountType.Name, accountType.UserID);
            if (exist)
            {
                this.ModelState.AddModelError(nameof(accountType.Name), $@"The name {accountType.Name} already exists");
                return this.View(accountType);
            }

            await this.repositoryAccountsTypes.Create(accountType);

            return this.View();
        }
    }
}
