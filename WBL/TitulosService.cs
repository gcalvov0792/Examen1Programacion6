using BD;
using Entity.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public class TitulosService
    {
        private readonly IDataAccess sql;

        public TitulosService(IDataAccess _sql)
        {
            sql = _sql;
        }

        //metodo para obtener la informacion
        public async Task<IEnumerable<TitulosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<TitulosEntity>("TitulosObtener");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //metodo para obtener por id
        public async Task<TitulosEntity> GetById(TitulosEntity entity)
        {

            try
            {
                var result = sql.QueryFirstAsync<TitulosEntity>("TitulosObtener", new
                {
                    entity.Id_Titulo
                }
                );
                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
