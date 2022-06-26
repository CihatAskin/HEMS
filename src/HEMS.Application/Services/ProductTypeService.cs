using System.Data;

using Dapper;
using AutoMapper;

using HEMS.Domain;
using HEMS.Domain.Entities;
using HEMS.Shared.Dtos.ProductType;
using HEMS.Shared.Requests.ProductType;
using HEMS.Shared.Response.ProductType;
using HEMS.Application.Common.Interfaces;
using HEMS.Application.Services.Contracts;

namespace HEMS.Application.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IRepositoryAsync _repository;
        private readonly IMapper _factory;

        public ProductTypeService(IRepositoryAsync repository, IMapper factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<ProductTypeCreateResponse> Create(ProductTypeCreateRequest request)
        {
            ProductTypeCreateResponse response = new();

            var entity = _factory.Map<ProductType>(request);

            var param = new DynamicParameters();

            param.Add(nameof(entity.CategoryCode), entity.CategoryCode, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.Code), entity.Code, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.Name), entity.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.Description), entity.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.Status), entity.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.CreatedAt), entity.CreatedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add(nameof(entity.Id), 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            entity.Id = await _repository.CreateAsync<ProductType>(Procedures.ProductType.INSERT_OR_REVIEW, param);
            response.Item = _factory.Map<ProductTypeDto>(entity);

            response.SetSuccess();
            return response;
        }

        public async Task<ProductTypeDeleteResponse> Delete(ProductTypeDeleteRequest request)
        {
            ProductTypeDeleteResponse response = new();

            var param = new { ProductTypeCode = request.Code };
            var products = await _repository.GetListAsync<Product>(Procedures.Product.GET_BY_TYPE, param);
            if (products.Count > 0)
            {
                response.ErrorMessages.Add("First, you must delete the linked product");
                return response;
            }

            await _repository.RemoveByCodeAsync(Procedures.ProductType.DELETE, request.Code);

            response.SetSuccess();
            return response;
        }

        public async Task<ProductTypeEditResponse> Edit(ProductTypeEditRequest request)
        {
            ProductTypeEditResponse response = new();

            var entity = _factory.Map<ProductType>(request);
            var param = new
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Status = entity.Status,
                UpdatedAt = DateTime.UtcNow
            };
            await _repository.UpdateAsync<ProductType>(Procedures.ProductType.UPDATE, param);

            response.Item = _factory.Map<ProductTypeDto>(entity);

            response.SetSuccess();
            return response;
        }

        public async Task<ProductTypeReadResponse> Get(ProductTypeReadRequest request)
        {
            ProductTypeReadResponse response = new();

            var ProductType = await _repository.GetByIdAsync<ProductType>(Procedures.ProductType.GET_BY_ID, request.Id);

            response.Item = _factory.Map<ProductTypeDto>(ProductType);

            response.SetSuccess();
            return response;
        }

        public async Task<ProductTypeReadListResponse> GetByCategory(ProductTypeReadListRequest request)
        {
            ProductTypeReadListResponse response = new();
            var param = new { CategoryCode = request.Code };
            var productTypes = await _repository.GetListAsync<ProductType>(Procedures.ProductType.GET_BY_CATEGORY, param);

            response.Items = _factory.Map<List<ProductTypeDto>>(productTypes);

            response.SetSuccess();
            return response;
        }

        public async Task<ProductTypeExistsResponse> IsExists(ProductTypeExistsRequest request)
        {
            ProductTypeExistsResponse response = new();
            response.IsSucceeded = await _repository.IsExistsAsync(Procedures.ProductType.IS_EXIST, request.Code);

            return response;
        }

        public async Task<ProductTypeReadListResponse> List(ProductTypeReadListRequest request)
        {
            ProductTypeReadListResponse response = new();

            var categories = await _repository.GetListAsync<ProductType>(Procedures.ProductType.GET_ALL);

            response.Items = _factory.Map<List<ProductTypeDto>>(categories);

            response.SetSuccess();
            return response;
        }
    }
}
