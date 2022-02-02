using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WemcoBank.Data;
using WemcoBank.Helper;
using WemcoBank.Model;

namespace WemcoBank.IRepository
{
    public interface IOnBoardingRepository
    {
        Task<ApiResponse> OnBoard(OnBoardModel model);
        Task<List<admState>> ListOfState();
        Task<List<admLGA>> ListOfLGA(string StateCode);
        Task<List<Transaction>> PostedTransaction();
    }
}
