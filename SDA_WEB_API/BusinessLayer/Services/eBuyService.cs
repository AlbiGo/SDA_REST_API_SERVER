using Microsoft.EntityFrameworkCore;
using SDA_WEB_API.BusinessLayer.Interfaces;
using SDA_WEB_API.DataLayer;
using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.BusinessLayer.Services
{
    public class eBuyService : IeBuyService
    {
        private readonly OnlineBuyDBContext _onlineBuyDBContext;

        public eBuyService(OnlineBuyDBContext onlineBuyDBContext)
        {
            _onlineBuyDBContext = onlineBuyDBContext;
        }

        public async Task AddToCart(Fatura fatura, int userID)
        {
            try
            {
                //Check if its first time that a product is added
                var fatureDaljeDB = _onlineBuyDBContext.FaturaDaljes
                    .Where(p => p.UserID == userID &&
                                p.Completed == false)
                    .FirstOrDefault();

                if (fatureDaljeDB == null)
                {
                    var fatureDalje = new FaturaDaljes()
                    {
                        Completed= false,
                        Totali = 0,
                        UserID = userID,
                        TVSH = 13
                    };
                    await _onlineBuyDBContext.FaturaDaljes.AddAsync(fatureDalje);
                    await _onlineBuyDBContext.SaveChangesAsync();
                    fatura.FaturaDaljesID = fatureDalje.ID;
                }
                else
                    fatura.FaturaDaljesID = fatureDaljeDB.ID;

                await _onlineBuyDBContext.Faturat.AddAsync(fatura);
                await _onlineBuyDBContext.SaveChangesAsync();

                //ReKalkulo Totalin
                await ReKalkuloTotalin(fatura.FaturaDaljesID);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task ReKalkuloTotalin(int fatureDaljeID)
        {
            var fatureDaljeDB = await _onlineBuyDBContext.FaturaDaljes
                .Where(p => p.ID == fatureDaljeID)
                .FirstOrDefaultAsync();

            var faturat = await _onlineBuyDBContext.Faturat
                .Where(p => p.FaturaDaljesID == fatureDaljeID)
                .Include(p => p.Artikull)
                .ToListAsync();

            decimal totali = 0;

            foreach (var f in faturat)
            {
                var totalPerfature = f.Artikull.Cmimi * f.Sasia;
                totali = totali + totalPerfature;
            }
            fatureDaljeDB.Totali = totali;

            _onlineBuyDBContext.FaturaDaljes.Update(fatureDaljeDB);
            await _onlineBuyDBContext.SaveChangesAsync();
        }
    }
}
