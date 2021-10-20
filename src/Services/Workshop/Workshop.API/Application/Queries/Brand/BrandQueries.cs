using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Workshop.API.Application.Queries.Brand
{
    public class BrandQueries : IBrandQueries
    {
        private string _connectionString = string.Empty;

        public BrandQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<IEnumerable<BrandViewModel>> GeBrandListAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<BrandViewModel>(
                    @"SELECT id, 
                             name
                      FROM saft.brands WITH(nolock)");
            }
        }

        public async Task<BrandViewModel> GetBrandByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                      @"SELECT id,
                               name
                        FROM   saft.brands 
                        WHERE Id = @id",
                        new { id }
                    );

                if (result.AsList().Count == 0)
                {
                    throw new KeyNotFoundException();
                }

                return MapBrank(result);
            }
        }

        private BrandViewModel MapBrank(dynamic result)
        {
            BrandViewModel _brand = new BrandViewModel
            {
                Id = result[0].id,
                Name = result[0].name
            };

            return _brand;
        }
    }
}
