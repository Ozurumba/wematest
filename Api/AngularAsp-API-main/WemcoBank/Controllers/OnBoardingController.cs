using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemcoBank.IRepository;
using WemcoBank.Model;

namespace WemcoBank.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OnBoardingController : Controller
    {
        private readonly IOnBoardingRepository _board;
        public OnBoardingController(IOnBoardingRepository board)
        {
            _board = board;
        }
        [HttpPost(template: "Onboarding")]
        public async Task<IActionResult> Create(OnBoardModel model)
        {
            var resp = await _board.OnBoard(model);
            return Ok(resp);
        }

        [HttpGet(template: "Transaction")]
        public async Task<IActionResult> ListOfTransaction ()
        {
            var resp = await _board.PostedTransaction();
            return Ok(resp);
        }

        [HttpGet(template: "State")]
        public async Task<IActionResult> State()
        {
            var resp = await _board.ListOfState();
            return Ok(resp);
        }

        [HttpGet(template: "LGA")]
        public async Task<IActionResult> LGA(string StateCode)
        {
            var resp = await _board.ListOfLGA(StateCode);
            return Ok(resp);
        }
    }
}
