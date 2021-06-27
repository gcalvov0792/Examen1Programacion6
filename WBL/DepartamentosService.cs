﻿using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public class DepartamentosService
    {
        private readonly IDataAccess sql;

        public DepartamentosService(IDataAccess _sql )
        {
            sql = _sql;
        }

        //metodo para obtener una lista
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

        //metodo para obtener por id
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

    }
}
