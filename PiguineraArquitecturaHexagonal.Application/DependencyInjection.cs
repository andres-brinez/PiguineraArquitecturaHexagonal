﻿using Microsoft.Extensions.DependencyInjection;
using PiguineraArquitecturaHexagonal.Application.Generic;
using PiguineraArquitecturaHexagonal.Application.UseCases.Manage.Book;
using PiguineraArquitecturaHexagonal.Application.UseCases.Manage.Budget;
using PiguineraArquitecturaHexagonal.Application.UseCases.Manage.Purchese;
using PiguineraArquitecturaHexagonal.Application.UseCases.Manage.Quote;
using PiguineraArquitecturaHexagonal.Application.UseCases.Supplier;
using PiguineraArquitecturaHexagonal.Domain.Model.Manage.Commands;
using PiguineraArquitecturaHexagonal.Domain.Model.Supplier.Commands;


namespace PiguineraArquitecturaHexagonal.Application
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IInitialCommandUseCase<CreateSupplierCommnad>, CreateSupplierUseCase>();
            services.AddScoped<IInitialCommandUseCase<CreateBookCommand>, CreateBookUseCase>();
            services.AddScoped<IInitialCommandUseCase<CalculatePaymentCommand>, CalculatePaymentUseCase>();
            services.AddScoped<IInitialCommandUseCase<CalculateBudgetCommand>, CalculateBudgetUseCase>();
            services.AddScoped<IInitialCommandUseCase<CalculateQuoteCommand>, GenerateQuoteUseCase>();


            //services.AddTransient<ICommandUseCase<AddDiseaseCubeCommand, CytyId>, AddDiseaseCubeUseCase>();
            return services;
        }
    }
}