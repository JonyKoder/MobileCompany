using MobileCompany.ViewModels.Dto;

namespace MobileCompany.BL.Interfaces;

public interface IMobileCompanyService
{
    List<AbonentDto> GetAbonentByLastName(string searchLastName);
    List<AbonentDto> GetAllAbonents();
}