﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http;
using WSMHRAPI.HRFunction;
using WSMHRAPI.Models;
using WSMHRAPI.MasterFunction;

namespace WSMHRAPI.Controllers
{
    public class MasterSectDeleteController : ApiController
    {
        // GET: api/MasterDivisionUpdate
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/MasterDivisionUpdate/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MasterDivisionUpdate
        public IHttpActionResult Post(MasterSectModel M)
        {
            try
            {
                if (M.FTSectCode != "")
                {
                    string _table = "TCNMSect";
                    //TCNMCLevel
                    //TCNMCmp
                    //TCNMDivision
                    //TCNMDepartment
                    //TCNMSect
                    //TCNMUnitSect
                    //TCNMPosition
                    //


                    string PK = "FNHSysSectId";
                    int _sysCmpId = 0;  //FNHSysCmpId
                    int fnhsysmasterId = 0;

                    string msgCode = "";
                    string msgDesc = "";
                    ActionMasterModel a = new ActionMasterModel();

                    if (M.FTSectCode.ToString() != "" && M.FNHSysSectId.ToString() != "")
                    {

                        //VerrifyData  
                        if (MasterClass.VerrifyUsing(_table, PK, M.FTSectCode, M.FNHSysCmpId, M.FNHSysSectId))
                        {
                            //verify Use

                            //update
                            if (MasterClass.DeleteMaster(_table, M.FTSectCode, M.FNHSysCmpId, PK, M.FTSectNameTH, M.FTSectNameEN, M.FTRemark, M.username, M.FNHSysSectId, ref msgDesc))
                            {
                                a.Status = true;
                                a.StatusCode = 200;
                                a.Messege = msgDesc;
                                a.FNHSysMasterID = fnhsysmasterId;

                            }
                            else
                            {
                                a.Status = false;
                                a.StatusCode = int.Parse(msgCode);
                                a.Messege = msgDesc;
                                a.FNHSysMasterID = 0;
                            }
                        }
                        else
                        {
                            a.Status = false;
                            a.StatusCode = int.Parse(msgCode);
                            a.Messege = "Already used. Can not delete.";
                            a.FNHSysMasterID = 0;
                        }
                    }
                    else
                    {
                        a.Status = false;
                        a.StatusCode = int.Parse(msgCode);
                        a.Messege = "Not found data.";
                        a.FNHSysMasterID = 0;
                    }

                   

                    return Ok(a);
                }
                else
                {
                    return Ok(404);
                }
            }
            catch(Exception ex)
            {
                 Request.CreateResponse(HttpStatusCode.NotFound);
                return Ok(404);
            }                    

        }


        // PUT: api/MasterDivisionUpdate/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MasterDivisionUpdate/5
        public void Delete(int id)
        {
        }
    }
}