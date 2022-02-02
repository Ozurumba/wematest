using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemcoBank.Data;
using WemcoBank.Helper;
using WemcoBank.IRepository;
using WemcoBank.Model;

namespace WemcoBank.Repository
{
    public class OnBoardingRepository: IOnBoardingRepository
    {
        private readonly WemcoDBContext _context;
        public OnBoardingRepository(WemcoDBContext context) 
        {
            _context = context;
        }

        public async Task<ApiResponse> OnBoard(OnBoardModel model)
        {
            ApiResponse resp = new ApiResponse();
            var reg = new OnBoarding()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber =model.PhoneNumber,
                Email = model.Email,
                State = model.State,
                Lga = model.Lga,
                age = model.age,
                BusinessName = model.BusinessName,
                BusinessRegNumber = model.BusinessRegNumber,
                Directors = model.Directors,
                BusinessEmail = model.BusinessEmail,
                BusinessAddress = model.BusinessAddress,
                Picture = model.Picture,
                Signature = model.Signature,
                DateCreated = DateTime.Now,
                Status = "Active",
            };

            _context.OnBoarding.Add(reg);
            bool save = await _context.SaveChangesAsync() > 0 ? true : false;

            if(save)
            {
                resp.ResponseCode = 0;
                resp.ResponseMessage = "Registration Successful";
            }
            else
            {
                resp.ResponseCode = 404;
                resp.ResponseMessage = "Error 404: Internal error occurred, Registration is not Successful. Please try again";
            }

            return resp;
        }

        public async Task<List<admState>> ListOfState()
        {
            var state = await _context.admState.Where(p => p.Status == "Active").ToListAsync();
            return state;
        }

        public async Task<List<admLGA>> ListOfLGA(string StateCode)
        {
            var lga = await _context.admLGA.Where(p => p.Status == "Active" && p.StateCode == StateCode).ToListAsync();
            return lga;
        }

        public async Task<List<Transaction>> PostedTransaction()
        {
            List<Transaction> trans = new List<Transaction> 
            {
                new Transaction { Id = 1, Reference = "1234QW", Date = Convert.ToDateTime("2022-01-29 12:25:02.9108905"),  Amount = 540, Status = "Active" },
                new Transaction { Id = 2, Reference = "12674MB", Date = Convert.ToDateTime("2022-01-29 12:25:02.9108905"),  Amount = 40, Status = "Active" },
                new Transaction { Id = 3, Reference = "78014GV", Date = Convert.ToDateTime("2022-01-29 12:25:02.9108905"),  Amount = 1040, Status = "Active" },
                new Transaction { Id = 3, Reference = "89018KL", Date = Convert.ToDateTime("2022-01-29 12:25:02.9108905"),  Amount = 300, Status = "Active" },
                new Transaction { Id = 4, Reference = "18039DF", Date = Convert.ToDateTime("2022-01-29 12:25:02.9108905"),  Amount = 91, Status = "Active" },
                new Transaction { Id = 5, Reference = "29000SL", Date = Convert.ToDateTime("2022-01-29 12:25:02.9108905"),  Amount = 1300, Status = "Active" },

            };

            return trans;
        }
    }
}
