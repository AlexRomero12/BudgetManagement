// <copyright file="RepositoryAccountsTypes.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BudgetManagement.Services
{
    using BudgetManagement.Models;
    using Dapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Data.SqlClient;

    /// <summary>
    /// Repository accounts types.
    /// </summary>
    public class RepositoryAccountsTypes : IRepositoryAccountsTypes
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryAccountsTypes"/> class.
        /// </summary>
        /// <param name="configuration">IConfiguration.</param>
        public RepositoryAccountsTypes(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /// <summary>
        /// Create AccountType in DB.
        /// </summary>
        /// <param name="accountType">AccountType model.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Create(AccountType accountType)
        {
            using var connection = new SqlConnection(this.connectionString);
            var id = await connection.QuerySingleAsync<int>(
                                                    $@"INSERT INTO AccountType (Name, UserID, [Order]) 
                                                    VALUES (@Name, @UserID, 0)
                                                    SELECT SCOPE_IDENTITY();", accountType);
            accountType.ID = id;
        }

        /// <summary>
        /// Validates if an AccountType exists.
        /// </summary>
        /// <param name="name">AccountType name.</param>
        /// <param name="userID">User identifier.</param>
        /// <returns><bool>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
        public async Task<bool> Exists(string name, int userID)
        {
            using var connection = new SqlConnection(this.connectionString);
            var exists = await connection.QueryFirstOrDefaultAsync<int>(
                                                                        $@"SELECT 1
                                                                        FROM AccountType
                                                                        WHERE Name = @Name AND UserID = @UserID;",
                                                                        new { name, userID });
            return exists == 1;
        }
    }
}
