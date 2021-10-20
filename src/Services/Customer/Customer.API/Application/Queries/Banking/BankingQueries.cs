using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Customer.Api.Application.Queries.Banking
{
    public class BankingQueries : IBankingQueries
    {
        private string _connectionString = string.Empty;

        public BankingQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<IEnumerable<BankingViewModel>> GetBankListAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<BankingViewModel>(
                    @"SELECT Id,
                             Name AS BankName,
                             Description,
                             Phone
                      FROM SAFT.banks WITH(nolock)");
            }
        }

        public async Task<BankingViewModel> GetBankByIdAsync(int bankId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(@"SELECT Id,
                           Name AS BankName,
                           Description,
                           Phone
                    FROM   SAFT.banks WITH(nolock)
                    WHERE  Id = @bankId",
                    new { bankId }
                    );

                if (result.AsList().Count == 0)
                {
                    throw new KeyNotFoundException();
                }

                return MapBank(result);
            }
        }

        private BankingViewModel MapBank(dynamic result)
        {
            BankingViewModel _bank = new BankingViewModel
            {
                BankName = result[0].BankName,
                Id = result[0].Id,
                Description = result[0].Description,
                Phone = result[0].Phone,

            };

            return _bank;
        }
    }
}
