using System.Data;

using Dapper;
using AutoMapper;

using HEMS.Domain;
using HEMS.Domain.Entities;
using HEMS.Shared.Dtos.Product;
using HEMS.Shared.Requests.Product;
using HEMS.Shared.Response.Product;
using HEMS.Application.Common.Interfaces;
using HEMS.Application.Services.Contracts;

namespace HEMS.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryAsync _repository;
        private readonly IMapper _factory;

        public ProductService(IRepositoryAsync repository, IMapper factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<ProductCreateResponse> Create(ProductCreateRequest request)
        {
            ProductCreateResponse response = new();

            var entity = _factory.Map<Product>(request);

            var param = new DynamicParameters();

            param.Add(nameof(entity.CategoryCode), entity.CategoryCode, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.ProductTypeCode), entity.ProductTypeCode, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.Code), entity.Code, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.Name), entity.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.Description), entity.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.Status), entity.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.CreatedAt), entity.CreatedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add(nameof(entity.Id), 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            entity.Id = await _repository.CreateAsync<Product>(Procedures.Product.INSERT_OR_REVIEW, param);
            response.Item = _factory.Map<ProductDto>(entity);

            response.SetSuccess();
            return response;
        }

        public async Task<ProductDeleteResponse> Delete(ProductDeleteRequest request)
        {
            ProductDeleteResponse response = new();

            await _repository.RemoveByCodeAsync(Procedures.Product.DELETE, request.Code);

            response.SetSuccess();
            return response;
        }

        public async Task<ProductEditResponse> Edit(ProductEditRequest request)
        {
            ProductEditResponse response = new();

            var entity = _factory.Map<Product>(request);
            var param = new
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Status = entity.Status,
                UpdatedAt = DateTime.UtcNow
            };
            await _repository.UpdateAsync<Product>(Procedures.Product.UPDATE, param);

            response.Item = _factory.Map<ProductDto>(entity);

            response.SetSuccess();
            return response;
        }

        public async Task<ProductReadResponse> Get(ProductReadRequest request)
        {
            ProductReadResponse response = new();

            var Product = await _repository.GetByIdAsync<Product>(Procedures.Product.GET_BY_ID, request.Id);

            response.Item = _factory.Map<ProductDto>(Product);

            response.SetSuccess();
            return response;
        }
        public async Task<ProductExistsResponse> IsExists(ProductExistsRequest request)
        {
            ProductExistsResponse response = new();
            response.IsSucceeded = await _repository.IsExistsAsync(Procedures.Product.IS_EXIST, request.Code);

            return response;
        }

        public async Task<ProductReadListResponse> List(ProductReadListRequest request)
        {
            ProductReadListResponse response = new();

            var categories = await _repository.GetListAsync<Product>(Procedures.Product.GET_ALL);

            response.Items = _factory.Map<List<ProductDto>>(categories);

            response.SetSuccess();
            return response;
        }
    }
}
