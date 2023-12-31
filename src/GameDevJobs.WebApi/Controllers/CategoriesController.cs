﻿using Backend.Application.Dto.Categories;
using Backend.Application.Interfaces.Services;
using Backend.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Backend.WebApi.Controllers;
[ApiController]
[GlobalExceptionFilter]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesService _categoriesService;

    public CategoriesController(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoriesService.GetCategoriesAsync();

        return Ok(categories);
    }

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetCategory(int categoryId)
    {
        var category = await _categoriesService.GetCategoryAsync(categoryId);

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] RequestCategoryDto requestCategoryDto)
    {
        var newCategory = await _categoriesService.CreateCategoryAsync(requestCategoryDto);

        return Created($"api/categories/{newCategory.Id}", newCategory); //todo Find out what does it mean and how it works
    }

    [HttpPut("{categoryId}")]
    public async Task<IActionResult> UpdateCategory([FromRoute] int categoryId, [FromBody] RequestCategoryDto updatedCategoryDto)
    {
        await _categoriesService.UpdateCategoryAsync(categoryId, updatedCategoryDto);

        return NoContent(); //todo Is this response ok?
    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        await _categoriesService.DeleteCategoryAsync(categoryId);

        return Ok(); //todo Is this response ok?
    }
}