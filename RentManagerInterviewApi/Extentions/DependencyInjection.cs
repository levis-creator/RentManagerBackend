using RentManagerInterviewApi.Repositories.Interfaces;
using RentManagerInterviewApi.Repositories;

namespace RentManagerInterviewApi.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContracts(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPropertyOwnerRepository, PropertyOwnerRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<ILeaseAgreementRepository, LeaseAgreementRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentTransferRepository, PaymentTransferRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            return services;
        }
    }
}
