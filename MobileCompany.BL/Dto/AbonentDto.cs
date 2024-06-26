﻿namespace MobileCompany.ViewModels.Dto;

public class AbonentDto
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public int SubscribersCount { get; set; } = 2;
}