using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Workshop.API.Application.Queries.TireType
{
    public class TireTypeQueries : ITireTypeQueries
    {
        private string _connectionString = string.Empty;

        public TireTypeQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<TireTypeViewModel> GetTireTypeByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                      @"SELECT id,
                               name
                        FROM   saft.tireTypes WITH(nolock)
                        WHERE Id = @id",
                        new { id }
                    );

                if (result.AsList().Count == 0)
                {
                    throw new KeyNotFoundException();
                }

                return MapTireTypeWork(result);
            }
        }

        public async Task<IEnumerable<TireTypeViewModel>> GetTireTypeListAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<TireTypeViewModel>
                    (
                    @"SELECT id, 
                             name
                      FROM saft.tireTypes WITH(nolock)"
                    );
            }
        }

        private TireTypeViewModel MapTireTypeWork(dynamic result)
        {
            TireTypeViewModel _brand = new TireTypeViewModel
            {
                Id = result[0].id,
                Name = result[0].name
            };

            return _brand;
        }
    }
}
