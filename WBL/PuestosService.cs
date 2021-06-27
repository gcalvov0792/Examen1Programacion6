using BD;
using Entity.dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public class PuestosService
    {
        private readonly IDataAccess sql;

        public PuestosService(IDataAccess _sql)
        {
            sql = _sql;
        }

        //metodo para obtener la informacion
        public async Task<IEnumerable<PuestosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<PuestosEntity>("PuestosObtener");
                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //metodo para obtener por id
        public async Task<PuestosEntity> GetById(PuestosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<PuestosEntity>("PuestosObtener", new
                {
                    entity.Id_Puesto
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
