// <copyright file="AccountType.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BudgetManagement.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Account Type model.
    /// </summary>
    public class AccountType
    {
        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "The {0} field length must be between {2} and {1} characters.")]
        [Remote(action: "ValidateAccountsTypesExist", controller: "AccountType")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets user identifier.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the order of the AccountType in the list.
        /// </summary>
        public int Order { get; set; }
    }
}