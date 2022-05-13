using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.Models;
using Server.MySQL;
using System.Diagnostics;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DumpController : ControllerBase
    {
        private static string _result = "";
        private static bool isBusy = false;
        private Backuper _bk = Backuper.GetInstance();
        [HttpGet("Save/{pass}")]
        public ActionResult<string> TrySave(string pass)
        {
            if (pass == Param.Settings.password)
            {
                try
                {
                    if (isBusy)
                    {
                        return StatusCode(StatusCodes.Status502BadGateway);
                    }
                    else
                    {
                        if (_result != "")
                        {
                            var buff = _result;
                            _result = "";
                            return CreatedAtAction(null, buff);
                        }
                        else
                        {
                            Task.Run(() => { Save(); });
                            return StatusCode(StatusCodes.Status502BadGateway);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("НЕВЕРНЫЙ пароль");
            }
        }

        private void Save()
        {
            
            isBusy = true;
            _result = _bk.Export();
            isBusy = false;
        }
        [HttpPost("Load/{pass}")]
        public ActionResult<string> TryLoad(string[] path, string pass)
        {
            if (pass == Param.Settings.password)
            {
                try
                {
                    if (isBusy)
                    {
                        return StatusCode(StatusCodes.Status502BadGateway);
                    }
                    else
                    {
                        if (_result != "")
                        {
                            var buff = _result;
                            _result = "";
                            return CreatedAtAction(null, buff);
                        }
                        else
                        {
                            Task.Run(() => { Load(path[0]); });
                            return StatusCode(StatusCodes.Status502BadGateway);
                        }
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("НЕВЕРНЫЙ пароль");
            }
        }
        private async void Load(string path)
        {
            isBusy = true;
            _bk.Import(path);
            _result = "1";
            isBusy = false;            
        }
    }
}
