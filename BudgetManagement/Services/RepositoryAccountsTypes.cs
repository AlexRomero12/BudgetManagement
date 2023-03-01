// <copyright file="RepositoryAccountsTypes.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BudgetManagement.Services
{
    using BudgetManagement.Models;
    using Dapper;
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

        /// <inheritdoc cref="IRepositoryAccountsTypes.Create(AccountType)"/>
        public async Task Create(AccountType accountType)
        {
            using var connection = new SqlConnection(this.connectionString);
            var id = await connection.QuerySingleAsync<int>(
                                                    $@"INSERT INTO AccountType (Name, UserID, [Order]) 
                                                    VALUES (@Name, @UserID, 0)
                                                    SELECT SCOPE_IDENTITY();", accountType);
            accountType.ID = id;
        }

        /// <inheritdoc cref="IRepositoryAccountsTypes.Exists(string, int)"/>
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

        /// <inheritdoc cref="IRepositoryAccountsTypes.GetByUserID(int)"/>
        public async Task<IEnumerable<AccountType>> GetByUserID(int userID)
        {
            using var connection = new SqlConnection(this.connectionString);
            return await connection.QueryAsync<AccountType>(
                @"SELECT ID,Name,[Order]
                 FROM ACCOUNTTYPE
                 WHERE USERID = @USERID", new { userID });
        }

        /// <inheritdoc cref="IRepositoryAccountsTypes.Update(AccountType)"/>
        public async Task Update(AccountType accountType)
        {
            using var connection = new SqlConnection(this.connectionString);
            await connection.ExecuteAsync(
                @"UPDATE ACCOUNTTYPE
                SET Name = @Name 
                WHERE ID = @Id", accountType);
        }

        /// <inheritdoc cref="IRepositoryAccountsTypes.GetByID(int, int)"/>
        public async Task<AccountType> GetByID(int id, int UserId)
        {
            using var connection = new SqlConnection(this.connectionString);
            return await connection.QueryFirstOrDefaultAsync<AccountType>(
                                    @"SELECT ID,Name,[Order]
                                    FROM AccountType
                                    WHERE ID = @id AND UserID = @UserId", new { id, UserId });
        }
    }
}
