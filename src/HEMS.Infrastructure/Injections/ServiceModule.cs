
using Autofac;
using Module = Autofac.Module;

using HEMS.Application.Services;
using HEMS.Infrastructure.Common;
using HEMS.Application.Common.Interfaces;
using HEMS.Application.Services.Contracts;

namespace HEMS.Infrastructure.Injections
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<ProductTypeService>().As<IProductTypeService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<RepositoryAsync>().As<IRepositoryAsync>();
            builder.RegisterType<ConnectionFactory>().As<IConnectionFactory>();
        }

    }
}
