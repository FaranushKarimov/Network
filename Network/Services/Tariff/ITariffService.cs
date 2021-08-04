using Network.DTO.Tariff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Services.Tariff
{
    public interface ITariffService
    {
        Task<Domain.Models.Tariff> Create(CreateTariffViewModel tariff);
        Task Delete(int tariffid);
        Task EditTariff(UpdateTariffViewModel tariff);
        Task<List<TariffViewModel>> GetAllTariffs();
        Task<UpdateTariffViewModel> GetByTariffId(int id);
        Task Update(UpdateTariffViewModel model);
    }
}
