// <copyright file="AccountTypeController.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BudgetManagement.Controllers
{
    using BudgetManagement.Models;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for handling actions related to account types.
    /// </summary>
    public class AccountTypeController : Controller
    {
        /// <summary>
        /// Renders the create view.
        /// </summary>
        /// <returns>The create view.</returns>
        public IActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountType">Account type model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(AccountType accountType)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(accountType);
            }
            return this.View();
        }
    }
}
