// <copyright file="IRepositoryAccountsTypes.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BudgetManagement.Services
{
    using System.Collections.Generic;
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
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task Create(AccountType accountType);

        /// <summary>
        /// Validates if an AccountType exists.
        /// </summary>
        /// <param name="name">AccountType name.</param>
        /// <param name="userID">User identifier.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task<bool> Exists(string name, int userID);

        /// <summary>
        /// Get AccountType by ID.
        /// </summary>
        /// <param name="id">AccountType ID.</param>
        /// <param name="UserId">User ID.</param>
        /// <returns>Accounttype.</returns>
        Task<AccountType> GetByID(int id, int UserId);

        /// <summary>
        /// Get AccountType by UserID.
        /// </summary>
        /// <param name="userID">User identifier.</param>
        /// <returns>IEnumerable AccountType.</returns>
        Task<IEnumerable<AccountType>> GetByUserID(int userID);

        /// <summary>
        /// Update AccountType.
        /// </summary>
        /// <param name="accountType">AccountType.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task Update(AccountType accountType);
    }
}