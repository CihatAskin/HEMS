using AutoMapper;
using HEMS.Application.Services.Contracts;
using HEMS.Client.Models;
using HEMS.Client.Models.Category;
using HEMS.Client.Models.Home;
using HEMS.Client.Models.Product;
using HEMS.Client.Models.ProductType;
using HEMS.Shared.Requests.Category;
using HEMS.Shared.Requests.Product;
using HEMS.Shared.Requests.ProductType;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HEMS.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;
        private readonly IMapper _mapper;
      
        public HomeController(ICategoryService categoryService, 
                              IProductService productService, 
                              IProductTypeService productTypeService, 
                              IMapper mapper)
        {
            _categoryService = categoryService;
            _productService = productService;
            _productTypeService = productTypeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardReadListModel();
            await AddCategories(model);
            await AddProductTypes(model);
            await AddProducts(model);

            return View(model);
        }

        private  async Task AddCategories( DashboardReadListModel model) {
            var request = new CategoryReadListRequest();
            var response = await _categoryService.List(request);

            if (response.IsSucceeded)
            {
               model.Categories= _mapper.Map<List<CategoryReadModel>>(response.Items);
            }
        }
        private async Task AddProductTypes(DashboardReadListModel model) {
            var request = new ProductTypeReadListRequest();
            var response = await _productTypeService.List(request);

            if (response.IsSucceeded)
            {
                model.ProductTypes= _mapper.Map<List<ProductTypeReadModel>>(response.Items);

            }
        }

        private async Task AddProducts(DashboardReadListModel model) {
            var request = new ProductReadListRequest();
            var response = await _productService.List(request);

            if (response.IsSucceeded)
            {
                model.Products=_mapper.Map<List<ProductReadModel>>(response.Items);

            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}