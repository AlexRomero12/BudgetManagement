// <copyright file="Account.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BudgetManagement.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Account model.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "The {0} field length must be maximum {1} characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets account Type Id.
        /// </summary>
        [Display(Name = "Account type")]
        public int AccountTypeId { get; set; }

        /// <summary>
        /// Gets or sets balance.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        [StringLength(maximumLength: 1000, ErrorMessage = "The {0} field length must be maximum {1} characters.")]
        public string Description { get; set; }
    }
}
