using AutoMapper;
using HEMS.Application.Services.Contracts;
using HEMS.Client.Models.Product;
using HEMS.Shared.Requests.Category;
using HEMS.Shared.Requests.Product;
using Microsoft.AspNetCore.Mvc;

namespace HEMS.Client.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
            {
                return RedirectToError();
            }

            var request = new ProductReadRequest(id);
            var response = await _productService.Get(request);
            if (response.IsSucceeded)
            {
                return View(_mapper.Map<ProductEditModel>(response.Item));
            }

            return RedirectToError();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditModel model)
        {
            if (ModelState.IsValid)
            {
                var request = _mapper.Map<ProductEditRequest>(model);
                var response = await _productService.Edit(request);
                if (response.IsSucceeded)
                {
                    return RedirectToAction(nameof(List));
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create([FromServices] ICategoryService categoryService)
        {
            var request = new CategoryReadListRequest();
            var response = await categoryService.List(request);
            var model = new ProductCreateModel();
            model.CategoryCodes = response.Items.Select(x => x.Code).ToList();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var request = _mapper.Map<ProductCreateRequest>(model);
                var response = await _productService.Create(request);

                if (response.IsSucceeded)
                {
                    return RedirectToAction(nameof(List));
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var request = new ProductReadListRequest();
            var response = await _productService.List(request);

            if (response.IsSucceeded)
            {
                return View(_mapper.Map<List<ProductReadModel>>(response.Items));

            }

            return RedirectToError();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var result = new { messages = string.Empty };
            if (string.IsNullOrWhiteSpace(id))
            {
                return Json(result);
            }

            var request = new ProductDeleteRequest(id);
            var response = await _productService.Delete(request);
            if (response.IsSucceeded)
            {
                return Json(result);
            }
            return Json(new { messages = response.ErrorMessages[0] });
        }
    }
}
