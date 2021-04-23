using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using twillio_netcore.Services;

namespace twillio_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwillioController : ControllerBase
    {
        private readonly ISendSmsService _sendSmsService;

        public TwillioController(ISendSmsService sendSmsService)
        {
            _sendSmsService = sendSmsService;
        }

        [HttpGet("SendSMS")]
        public async Task<IActionResult> SendSMS(string MessageTo, string MessageText)
        {
            try
            {
                return Ok(await _sendSmsService.SendSMS(MessageTo, MessageText));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "error occured.");
            }
        }

        [HttpGet("WhatsApp")]
        public async Task<IActionResult> WhatsApp(string MessageTo, string MessageText)
        {
            try
            {
                return Ok(await _sendSmsService.WhatsApp(MessageTo, MessageText));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "error occured.");
            }
        }
    }
}
