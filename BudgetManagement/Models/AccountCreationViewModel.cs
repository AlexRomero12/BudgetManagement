// <copyright file="AccountCreationViewModel.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BudgetManagement.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    /// <summary>
    /// Account Creation View Model.
    /// </summary>
    public class AccountCreationViewModel : Account
    {
        /// <summary>
        /// Gets or sets account types.
        /// </summary>
        public IEnumerable<SelectListItem> AccountTypes { get; set; }
    }
}
