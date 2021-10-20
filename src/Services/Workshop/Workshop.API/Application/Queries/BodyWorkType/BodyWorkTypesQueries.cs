using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Workshop.API.Application.Queries.BodyWorkType
{
    public class BodyWorkTypesQueries : IBodyWorkTypeQueries
    {
        private string _connectionString = string.Empty;

        public BodyWorkTypesQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<IEnumerable<BodyWorkViewModel>> GetBodyWorkListAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<BodyWorkViewModel>(
                    @"SELECT id, 
                             description
                      FROM saft.bodyWorkTypes WITH(nolock)");
            }
        }

        public async Task<BodyWorkViewModel> GetBodyWorkByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                      @"SELECT id,
                               description
                        FROM   saft.bodyWorkTypes WITH(nolock)
                        WHERE Id = @id",
                        new { id }
                    );

                if (result.AsList().Count == 0)
                {
                    throw new KeyNotFoundException();
                }

                return MapBodyWork(result);
            }
        }

        private BodyWorkViewModel MapBodyWork(dynamic result)
        {
            BodyWorkViewModel _brand = new BodyWorkViewModel
            {
                Id = result[0].id,
                Description = result[0].description
            };

            return _brand;
        }
    }
}
