using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasko.Common;
using Tasko.Model;

namespace Tasko.Repository
{
    /// <summary>
    /// AdminData Repository class
    /// </summary>
    public static class AdminData
    {
        /// <summary>
        /// Adds the service.
        /// </summary>
        /// <param name="service">The service.</param>        
        public static void AddService(Service service)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pName", DbType.String, service.Name));
            objParameters.Add(SqlHelper.CreateParameter("@pImageUrl", DbType.String, service.ImageURL));
            if (string.IsNullOrWhiteSpace(service.ParentServiceId))
            {
                objParameters.Add(SqlHelper.CreateParameter("@pParentServiceId", DbType.Binary, DBNull.Value));
            }
            else
            {
                objParameters.Add(SqlHelper.CreateParameter("@pParentServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(service.ParentServiceId)));
            }

            objParameters.Add(SqlHelper.CreateParameter("@pStatus", DbType.Int16, service.Status));
            SqlHelper.ExecuteNonQuery("dbo.usp_AddService", objParameters.ToArray());            
        }

        /// <summary>
        /// Updates the service.
        /// </summary>
        /// <param name="service">The service.</param>
        public static void UpdateService(Service service)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(service.Id)));
            objParameters.Add(SqlHelper.CreateParameter("@pName", DbType.String, service.Name));
            objParameters.Add(SqlHelper.CreateParameter("@pImageUrl", DbType.String, service.ImageURL));
            objParameters.Add(SqlHelper.CreateParameter("@pStatus", DbType.Int16, service.Status));
            SqlHelper.ExecuteNonQuery("dbo.usp_UpdateService", objParameters.ToArray());              
        }

        /// <summary>
        /// Disables the service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="status">The status.</param>
        public static void DisableService(string serviceId, short status)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(serviceId)));
            objParameters.Add(SqlHelper.CreateParameter("@pStatus", DbType.Int16, status));
            SqlHelper.ExecuteNonQuery("dbo.usp_DisableService", objParameters.ToArray()); 
        }

        /// <summary>
        /// Deletes the service.
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        public static void DeleteService(string serviceId)
        {
            List<SqlParameter> objParameters = new List<SqlParameter>();
            objParameters.Add(SqlHelper.CreateParameter("@pServiceId", DbType.Binary, BinaryConverter.ConvertStringToByte(serviceId)));
            SqlHelper.ExecuteNonQuery("dbo.usp_DeleteService", objParameters.ToArray()); 
        }

        /// <summary>
        /// Gets all services.
        /// </summary>
        /// <returns>list of services</returns>
        public static List<Service> GetAllServices()
        {
            List<Service> services = new List<Service>();

            List<SqlParameter> objParameters = new List<SqlParameter>();
            DataTable datatable = SqlHelper.GetDataTable("dbo.usp_GetAllServices", objParameters.ToArray());
            if (datatable != null && datatable.Rows.Count > 0)
            {
                foreach (DataRow row in datatable.Rows)
                {
                    Service service = new Service();
                    service.Id = BinaryConverter.ConvertByteToString((byte[])row["SERVICE_ID"]);
                    service.Name = row["NAME"].ToString();
                    if (!(row["PARENT_SERVICE_ID"] is System.DBNull))
                    {
                        service.ParentServiceId = BinaryConverter.ConvertByteToString((byte[])row["PARENT_SERVICE_ID"]);
                    }

                    service.Status = Convert.ToInt16(row["STATUS"]);
                    service.ImageURL = row["IMAGE_URL"].ToString();
                    services.Add(service);
                }
            }

            return services;            
        }
    }
}
