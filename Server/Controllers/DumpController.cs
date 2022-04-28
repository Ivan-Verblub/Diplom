using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.Models;
using System.Diagnostics;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DumpController : ControllerBase
    {
        private static string _result = "";
        private static bool isBusy = false;
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
            Console.WriteLine("Engage");
            var info = new ProcessStartInfo(Param.Dump.Path+"mysqldump.exe");
            info.Arguments = $"-u{Param.Settings.user} " +
                $"-h{Param.Settings.host} " +
                $"-p{Param.Settings.password} " +
                $"gos";
            Console.WriteLine("Running");
            info.RedirectStandardOutput = true;
            info.StandardOutputEncoding = System.Text.Encoding.UTF8;
            var p = new Process();
            p.StartInfo = info;
            Console.WriteLine("Start");
            p.Start();
            _result = p.StandardOutput.ReadToEnd();
            isBusy = false;
            Console.WriteLine("End");
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
            var info = new ProcessStartInfo(Param.Dump.Path+"mysql.exe");
            info.Arguments = $"-u{Param.Settings.user} " +
                $"-h{Param.Settings.host} " +
                $"-p{Param.Settings.password} " +
                $"gos";
            info.RedirectStandardInput = true;
            info.StandardInputEncoding = System.Text.Encoding.UTF8;
            var p = new Process();
            p.StartInfo = info;
            p.Start();
            p.StandardInput.Write(path);
            _result = "1";
            isBusy = false;            
        }
    }
}
