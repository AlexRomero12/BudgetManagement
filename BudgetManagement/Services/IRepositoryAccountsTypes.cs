// <copyright file="IRepositoryAccountsTypes.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BudgetManagement.Services
{
    using BudgetManagement.Models;

    /// <summary>
    /// Inteface repository accounts types.
    /// </summary>
    public interface IRepositoryAccountsTypes
    {
        /// <summary>
        /// Create account type in DB.
        /// </summary>
        /// <param name="accountType">Account type model.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Create(AccountType accountType);

        /// <summary>
        /// Validates if an AccountType exists.
        /// </summary>
        /// <param name="name">AccountType name.</param>
        /// <param name="userID">User identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<bool> Exists(string name, int userID);
    }
}