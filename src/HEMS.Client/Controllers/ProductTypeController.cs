using AutoMapper;
using HEMS.Application.Services.Contracts;
using HEMS.Client.Models;
using HEMS.Client.Models.ProductType;
using HEMS.Shared.Requests.Category;
using HEMS.Shared.Requests.ProductType;
using Microsoft.AspNetCore.Mvc;

namespace HEMS.Client.Controllers
{
    public class ProductTypeController : BaseController
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IMapper _mapper;

        public ProductTypeController(IProductTypeService productTypeService, IMapper mapper)
        {
            _productTypeService = productTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
            {
                return RedirectToError();
            }

            var request = new ProductTypeReadRequest(id);
            var response = await _productTypeService.Get(request);
            if (response.IsSucceeded)
            {
                return View(_mapper.Map<ProductTypeEditModel>(response.Item));
            }

            return RedirectToError();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductTypeEditModel model)
        {
            if (ModelState.IsValid)
            {
                var request = _mapper.Map<ProductTypeEditRequest>(model);
                var response = await _productTypeService.Edit(request);
                if (response.IsSucceeded)
                {
                    return RedirectToAction(nameof(List));
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create([FromServices]ICategoryService categoryService)
        {
            var request = new CategoryReadListRequest();
            var response = await categoryService.List(request);
            var model = new ProductTypeCreateModel();
            model.CategoryCodes = response.Items.Select(x => x.Code).ToList();

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductTypeCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var request = _mapper.Map<ProductTypeCreateRequest>(model);
                var response = await _productTypeService.Create(request);

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
            var request = new ProductTypeReadListRequest();
            var response = await _productTypeService.List(request);

            if (response.IsSucceeded)
            {
                return View(_mapper.Map<List<ProductTypeReadModel>>(response.Items));

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

            var request = new ProductTypeDeleteRequest(id);
            var response = await _productTypeService.Delete(request);
            if (response.IsSucceeded)
            {
                return Json(result);
            }
            return Json(new { messages = response.ErrorMessages[0] });
        }

        [HttpGet]
        public async Task<IActionResult> GetByCategory(string id)
        {
            var result = new { options = new List<SelectListModel>() };

            if (string.IsNullOrEmpty(id))
            {
                return Json(result);
            }

            var request = new ProductTypeReadListRequest();
            request.Code = id;

            var response = await _productTypeService.GetByCategory(request);

            if (response.IsSucceeded)
            {
                for (int i = 0; i < response.Items.Count; i++)
                {
                    var item = response.Items[i];
                    result.options.Add(new SelectListModel() { Value = item.Code, Text = item.Code });
                }
            }

            return Json(result);
        }
    }
}
