using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IDepartamentosService
    {
        Task<IEnumerable<DepartamentosEntity>> Get();
        Task<DepartamentosEntity> GetById(DepartamentosEntity entity);
    }

    public class DepartamentosService : IDepartamentosService
    {
        private readonly IDataAccess sql;

        public DepartamentosService(IDataAccess _sql)
        {
            sql = _sql;
        }

        //1. metodo para obtener una lista
        public async Task<IEnumerable<DepartamentosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<DepartamentosEntity>("DepartamentosObtener");
                return await result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        //2. metodo para obtener por id
        public async Task<DepartamentosEntity> GetById(DepartamentosEntity entity)
        {

            try
            {
                var result = sql.QueryFirstAsync<DepartamentosEntity>("DepartamentosObtener", new
                {
                    entity.Id_Departamento
                }
                );
                return await result;

            }
            catch (Exception)
            {
                throw;
            }

        }

        //3. metodo para crear / insertar datos en la tabla
        public async Task<DBEntity> Create(DepartamentosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("DepartamentosInsertar", new
                {
                    entity.Descripcion,
                    entity.Ubicacion,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //4. metodo para actualizar datos en la tabla
        public async Task<DBEntity> Update(DepartamentosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("DepartamentosActualizar", new
                {
                    entity.Id_Departamento,
                    entity.Descripcion,
                    entity.Ubicacion,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //5. metodo para eliminar datos en la tabla
        public async Task<DBEntity> Delete(DepartamentosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("DepartamentosEliminar", new
                {
                    entity.Id_Departamento
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
