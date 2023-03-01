﻿// <copyright file="AccountTypeController.cs" company="Alexander Romero">
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
        private readonly IServiceUser serviceUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTypeController"/> class.
        /// </summary>
        /// <param name="repositoryAccountsTypes">Irepository accounts types.</param>
        public AccountTypeController(IRepositoryAccountsTypes repositoryAccountsTypes, IServiceUser serviceUser)
        {
            this.repositoryAccountsTypes = repositoryAccountsTypes;
            this.serviceUser = serviceUser;
        }

        /// <summary>
        /// Index.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Index()
        {
            var userID = this.serviceUser.GetUserID();
            var accountType = await this.repositoryAccountsTypes.GetByUserID(userID);
            return this.View(accountType);
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

            accountType.UserID = this.serviceUser.GetUserID();

            var exist = await this.repositoryAccountsTypes.Exists(accountType.Name, accountType.UserID);
            if (exist)
            {
                this.ModelState.AddModelError(nameof(accountType.Name), $@"The name {accountType.Name} already exists");
                return this.View(accountType);
            }

            await this.repositoryAccountsTypes.Create(accountType);

            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Validate accounts types exist.
        /// </summary>
        /// <param name="name">Account type name.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public async Task<IActionResult> ValidateAccountsTypesExist(string name)
        {
            var usuarioID = this.serviceUser.GetUserID();
            var accountTypeExist = await this.repositoryAccountsTypes.Exists(name, usuarioID);
            if (accountTypeExist)
            {
                return this.Json($@"The name {name} already exists.");
            }

            return this.Json(true);
        }
    }
}
