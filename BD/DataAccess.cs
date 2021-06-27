using Dapper;
using Dapper.Mapper;
using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration config;

        //constructor clase
        public DataAccess(IConfiguration _Config)
        {
            //propiedad de config o constructor
            config = _Config;
        }

        //metodo para la guardar el string o variable de conexion
        public SqlConnection DbConnection => new SqlConnection(
            new SqlConnectionStringBuilder(config.GetConnectionString("Conn")).ConnectionString

            );
        //metodo1 asincronico (facilita la conexion multiple a la base de datos y que la BD no se "pegue")
        //para hacer la representacion de datos de la entidad
        //cuando se crean metodos siempre se usa el try / catch

        public async Task<IEnumerable<T>> QueryAsync<T>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);
                    return await result;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //metodo dinamico, para hacer consultas directas para traer las propiedades que necesito sin necesidad de una entidad
        public async Task<IEnumerable<dynamic>> QueryAsync(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        //metodo2 asincronico para hacer la representacion de datos de la entidad
        public async Task<IEnumerable<T>> QueryAsync<T, B>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T, B>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);
                    return await result;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //metodo3 asincronico para hacer la representacion de datos de la entidad
        public async Task<IEnumerable<T>> QueryAsync<T, B, C>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T, B, C>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);
                    return await result;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        //metodo4 asincronico para hacer la representacion de datos de la entidad
        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T, B, C, D>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);
                    return await result;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //metodo5 asincronico para hacer la representacion de datos de la entidad
        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T, B, C, D, E>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);
                    return await result;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //metodo6 asincronico para hacer la representacion de datos de la entidad
        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E, F>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T, B, C, D, E, F>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //metodo7 asincronico para hacer la representacion de datos de la entidad
        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E, F, G>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T, B, C, D, E, F, G>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Necesario para acciones CRUD
        //metodo 8. 
        public async Task<T> QueryFirstAsync<T>(string sp, object Param = null, int? Timeout = null)
        {

            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryFirstOrDefaultAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //metodo 9 
        public async Task<DBEntity> ExecuteAsync(string sp, object Param = null, int? Timeout = null)
        {

            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = await exec.ExecuteReaderAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure
                        , commandTimeout: Timeout);

                    await result.ReadAsync();

                    return new ()
                    {
                        CodeError = result.GetInt32(0),
                        MsgError = result.GetString(1)

                    };


                }
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
