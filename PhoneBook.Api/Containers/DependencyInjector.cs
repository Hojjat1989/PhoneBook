using System;
using PhoneBook.Application.Interfaces;
using PhoneBook.Application.Services;
using PhoneBook.Domain.Repositories;
using PhoneBook.Infrastructure;

namespace PhoneBook.Api.Containers;

public static class DependencyInjector
{
    public static void Register(this IServiceCollection services)
    {
        services.AddScoped(typeof(IContactRepository), typeof(MemContactRepository));

        services.AddScoped(typeof(IContactService), typeof(ContactService));
    }
}
