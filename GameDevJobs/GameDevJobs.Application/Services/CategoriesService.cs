using AutoMapper;
using GameDevJobs.Application.Dto.Categories;
using GameDevJobs.Application.Exceptions;
using GameDevJobs.Application.Interfaces;
using GameDevJobs.Domain.Entities;
using GameDevJobs.Domain.Interfaces;

namespace GameDevJobs.Application.Services;

public class CategoriesService : ICategoriesService
{
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IMapper _mapper;

    public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper)
    {
        _categoriesRepository = categoriesRepository;
        _mapper = mapper;
    }

    public async Task<List<CategoryDto>> GetCategories()
    {
        var categories = await _categoriesRepository.GetCategories();

        return _mapper.Map<List<CategoryDto>>(categories);
    }
     
    public async Task<CategoryDto> GetCategory(int categoryId)
    {
        var category = await _categoriesRepository.GetCategory(categoryId);

        //todo Should I handle this case or just throw null and don't care?
        if (category == null) 
            throw new NotFoundException("Category with this id does not exist."); 

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> CreateCategory(RequestCategoryDto newCategoryDto)
    {
        //todo Prevent duplicates
        var newCategory = _mapper.Map<Category>(newCategoryDto);

        await _categoriesRepository.CreateCategory(newCategory);

        return _mapper.Map<CategoryDto>(newCategory);
    }

    public async Task UpdateCategory(int categoryId, RequestCategoryDto updatedCategoryDto)
    {
        var categoryToUpdate = await _categoriesRepository.GetCategory(categoryId);

        if (categoryToUpdate == null)
            throw new NotFoundException("Category with this id does not exist.");

        categoryToUpdate = _mapper.Map<Category>(updatedCategoryDto);

        await _categoriesRepository.UpdateCategory(categoryId, categoryToUpdate);
    }

    public async Task DeleteCategory(int categoryId)
    {
        var categoryToDelete = await _categoriesRepository.GetCategory(categoryId);

        if (categoryToDelete == null)
            throw new NotFoundException("Category with this id does not exist.");

        await _categoriesRepository.DeleteCategory(categoryId);
    }
}
