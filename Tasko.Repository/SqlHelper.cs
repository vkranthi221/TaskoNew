using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Tasko.Repository
{
    public static class SqlHelper
    {
        public static DataTable GetDataTable(string storedProcedureName, object[] parameters)
        {
            DataSet ds = GetDataSet(storedProcedureName, parameters);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        public static DataTable GetDataTable(string storedProcedureName)
        {
            return GetDataTable(storedProcedureName, null);
        }

        public static DataSet GetDataSet(string storedProcedureName, object[] parameters)
        {
            try
            {
                DataSet ds = new DataSet();
                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand command = db.GetStoredProcCommand(storedProcedureName))
                {
                    if (parameters != null && parameters.Length > 0)
                        command.Parameters.AddRange(parameters);
                    ds = db.ExecuteDataSet(command);
                }
                return ds;
            }
            catch (Exception ex)
            {
                //bool rethrow = DataAccessExceptionHandler.HandleException(ref ex);
                //if (rethrow)
                throw ex;
            }
            //return null;
        }

        public static DataSet GetDataSet(string storedProcedureName)
        {
            return GetDataSet(storedProcedureName, null);
        }

        public static IDataReader GetDataReader(string storedProcedureName, object[] parameters)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand command = db.GetStoredProcCommand(storedProcedureName);
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);
                return db.ExecuteReader(command); 
            }
            catch (Exception ex)
            {
                //bool rethrow = DataAccessExceptionHandler.HandleException(ref ex);
                //if (rethrow)
                throw ex;
            }
            //return null;
        }

        

        public static IDataReader GetDataReader(string storedProcedureName)
        {
            return GetDataReader(storedProcedureName, null);
        }

        public static void ExecuteNonQuery(string storedProcedureName, object[] parameters, out int returnVal)
        {
            returnVal = 0;
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand command = db.GetStoredProcCommand(storedProcedureName))
                {
                    if (parameters != null && parameters.Length > 0)
                        command.Parameters.AddRange(parameters);

                    db.AddParameter(command, "@returnValue", DbType.Int32, ParameterDirection.ReturnValue, null, DataRowVersion.Default, null);
                    db.ExecuteNonQuery(command);

                    returnVal = (db.GetParameterValue(command, "@returnValue") == DBNull.Value ? 0 : (int)db.GetParameterValue(command, "@returnValue"));
                }
            }
            catch (Exception ex)
            {
                //bool rethrow = DataAccessExceptionHandler.HandleException(ref ex);
                //if (rethrow)
                throw ex;
            }
        }

        public static void ExecuteNonQuery(string storedProcedureName, object[] parameters)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand command = db.GetStoredProcCommand(storedProcedureName))
                {
                    if (parameters != null && parameters.Length > 0)
                        command.Parameters.AddRange(parameters);

                    db.ExecuteNonQuery(command);
                }
            }
            catch (Exception ex)
            {
                //bool rethrow = DataAccessExceptionHandler.HandleException(ref ex);
                //if (rethrow)
                throw ex;
            }
        }

        public static void ExecuteNonQuery(string storedProcedureName)
        {
            ExecuteNonQuery(storedProcedureName, null);
        }

        public static object ExecuteScalar(string storedProcedureName, object[] parameters, out int returnValue)
        {
            object result = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand command = db.GetStoredProcCommand(storedProcedureName))
                {
                    if (parameters != null && parameters.Length > 0)
                        command.Parameters.AddRange(parameters);

                    db.AddParameter(command, "@returnValue", DbType.Int32, ParameterDirection.ReturnValue, null, DataRowVersion.Default, null);

                    result = db.ExecuteScalar(command);
                    returnValue = (db.GetParameterValue(command, "@returnValue") == DBNull.Value ? 0 : (int)db.GetParameterValue(command, "@returnValue"));
                }
            }
            catch (Exception ex)
            {
                returnValue = 0;
                //bool rethrow = DataAccessExceptionHandler.HandleException(ref ex);
                //if (rethrow)
                throw ex;
            }

            return result;
        }

        public static object ExecuteScalar(string storedProcedureName, object[] parameters)
        {
            object returnValue = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                using (DbCommand command = db.GetStoredProcCommand(storedProcedureName))
                {
                    if (parameters != null && parameters.Length > 0)
                        command.Parameters.AddRange(parameters);

                    returnValue = db.ExecuteScalar(command);
                }
            }
            catch (Exception ex)
            {
                //bool rethrow = DataAccessExceptionHandler.HandleException(ref ex);
                //if (rethrow)
                throw ex;
            }

            return returnValue;
        }

        public static object ExecuteScalar(string storedProcedureName)
        {
            return ExecuteScalar(storedProcedureName, null);
        }

        public static SqlParameter CreateParameter(string name, DbType type, object value)
        {
            SqlParameter param = new SqlParameter(name, type);
            param.Value = value;
            return param;
        }

    }
}
