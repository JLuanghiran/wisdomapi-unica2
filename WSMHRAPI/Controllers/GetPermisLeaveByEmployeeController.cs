﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WSMHRAPI.Controllers
{
    public class GetPermisLeaveByEmployeeController : ApiController
    {
        // GET: api/GetPermisLeaveByEmployee
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetPermisLeaveByEmployee/5
        public IHttpActionResult Get(string id, int CmpId)
        {

            DataTable dt = new System.Data.DataTable();
            string _cmd;
            _cmd = "Select  *  from dbo.fn_GetPermisLeaveByEmployee('" + id + "')";
            WSM.Conn.SQLConn qLConn = new WSM.Conn.SQLConn();
            dt = qLConn.GetDataTable(_cmd, WSM.Conn.DB.DataBaseName.DB_HR);
            return Ok(dt);

        }


        // POST: api/GetPermisLeaveByEmployee
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetPermisLeaveByEmployee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetPermisLeaveByEmployee/5
        public void Delete(int id)
        {
        }
    }
}
