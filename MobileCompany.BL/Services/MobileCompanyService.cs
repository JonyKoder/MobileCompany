using System.Data;
using AutoMapper;
using Dapper;
using MobileCompany.BL.Interfaces;
using MobileCompany.Models.Models;
using MobileCompany.ViewModels.Dto;

namespace MobileCompany.BL.Services;

public class MobileCompanyService : IMobileCompanyService
{
    private readonly IDbConnection _connection;
    private readonly IMapper _mapper;
    public MobileCompanyService(IDbConnection connection, IMapper mapper)
    {
        _connection = connection;
        _mapper = mapper;
    }

    public List<AbonentDto> GetAbonentByLastName(string searchLastName)
    {
        var query = @"
        SELECT
            a.*
        FROM
            public.""Abonents"" a
        WHERE
            LOWER(a.""LastName"") LIKE '%' || LOWER(@SearchLastName) || '%';";

        var abonents = _connection.Query<Abonent>(query, new { SearchLastName = searchLastName.ToLower() }).ToList();
        var dtos = _mapper.Map<List<Abonent>, List<AbonentDto>>(abonents);

        return dtos;
    }




    public List<AbonentDto> GetAllAbonents()
    {
        var query = @"
        SELECT
            *
        FROM
            public.""Abonents"" a
        LEFT JOIN
            public.""PhoneNumbers"" pn ON a.""PhoneNumberId"" = pn.""Id""
        LEFT JOIN
            public.""Addresses"" ad ON a.""AddressId"" = ad.""Id""";

        var abonents = _connection.Query<Abonent, PhoneNumber, Address, Abonent>(query, (abonent, phone, address) =>
        {
            abonent.PhoneNumber = phone;
            abonent.Address = address;
            return abonent;
        }).ToList();

        var dtos = _mapper.Map<List<Abonent>, List<AbonentDto>>(abonents);

        return dtos;
     
    }

    
}