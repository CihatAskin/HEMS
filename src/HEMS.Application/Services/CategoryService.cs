using System.Data;

using Dapper;
using AutoMapper;

using HEMS.Domain;
using HEMS.Domain.Entities;
using HEMS.Shared.Dtos.Category;
using HEMS.Shared.Requests.Category;
using HEMS.Shared.Response.Category;
using HEMS.Application.Common.Interfaces;
using HEMS.Application.Services.Contracts;

namespace HEMS.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryAsync _repository;
        private readonly IMapper _factory;

        public CategoryService(IRepositoryAsync repository, IMapper factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<CategoryCreateResponse> Create(CategoryCreateRequest request)
        {
            CategoryCreateResponse response = new();

            var entity = _factory.Map<Category>(request);

            var param = new DynamicParameters();

            param.Add(nameof(entity.Code), entity.Code, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.Name), entity.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.Description), entity.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.Status), entity.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(nameof(entity.CreatedAt), entity.CreatedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            param.Add(nameof(entity.Id), 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            entity.Id = await _repository.CreateAsync<Category>(Procedures.Category.INSERT_OR_REVIEW, param);
            response.Item = _factory.Map<CategoryDto>(entity);

            response.SetSuccess();
            return response;
        }

        public async Task<CategoryDeleteResponse> Delete(CategoryDeleteRequest request)
        {
            CategoryDeleteResponse response = new();

            var param = new { CategoryCode = request.Code };
            var productTypes = await _repository.GetListAsync<ProductType>(Procedures.ProductType.GET_BY_CATEGORY, param);
            if (productTypes.Count > 0)
            {
                response.ErrorMessages.Add("First, you must delete the linked product type");
                return response;
            }

            await _repository.RemoveByCodeAsync(Procedures.Category.DELETE, request.Code);

            response.SetSuccess();
            return response;
        }

        public async Task<CategoryEditResponse> Edit(CategoryEditRequest request)
        {
            CategoryEditResponse response = new();

            var entity = _factory.Map<Category>(request);
            var param = new
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Status = entity.Status,
                UpdatedAt = DateTime.UtcNow
            };
            await _repository.UpdateAsync<Category>(Procedures.Category.UPDATE, param);

            response.Item = _factory.Map<CategoryDto>(entity);

            response.SetSuccess();
            return response;
        }

        public async Task<CategoryReadResponse> Get(CategoryReadRequest request)
        {
            CategoryReadResponse response = new();

            var category = await _repository.GetByIdAsync<Category>(Procedures.Category.GET_BY_ID, request.Id);

            response.Item = _factory.Map<CategoryDto>(category);

            response.SetSuccess();
            return response;
        }

        public async Task<CategoryExistsResponse> IsExists(CategoryExistsRequest request)
        {
            CategoryExistsResponse response = new();
            response.IsSucceeded = await _repository.IsExistsAsync(Procedures.Category.IS_EXIST, request.Code);

            return response;
        }

        public async Task<CategoryReadListResponse> List(CategoryReadListRequest request)
        {
            CategoryReadListResponse response = new();

            var categories = await _repository.GetListAsync<Category>(Procedures.Category.GET_ALL);

            response.Items = _factory.Map<List<CategoryDto>>(categories);

            response.SetSuccess();
            return response;
        }
    }
}
