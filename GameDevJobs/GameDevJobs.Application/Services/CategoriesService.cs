using AutoMapper;
using GameDevJobs.Application.Dto.Categories;
using GameDevJobs.Application.Exceptions;
using GameDevJobs.Application.Interfaces;
using GameDevJobs.Domain.Entities;
using GameDevJobs.Domain.Interfaces;

namespace GameDevJobs.Application.Services;

public class CategoriesService : ICategoriesService
{
    private const string NOT_FOUND_MESSAGE = "Category with this id does not exist";
    private const string CONFLICT_MESSAGE = "Category with this name already exist";

    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IMapper _mapper;

    public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper)
    {
        _categoriesRepository = categoriesRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
    {
        var categories = await _categoriesRepository.GetCategoriesAsync();

        return _mapper.Map<ICollection<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetCategoryAsync(int categoryId)
    {
        var category = await _categoriesRepository.GetCategoryAsync(categoryId);

        //todo Should I handle this case or just throw null and don't care?
        if (category == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> GetCategoryAsync(string name)
    {
        var category = await _categoriesRepository.GetCategoryAsync(name);

        if (category == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> CreateCategoryAsync(RequestCategoryDto newCategoryDto)
    {
        if (await _categoriesRepository.GetCategoryAsync(newCategoryDto.Name) != null)
            throw new ConflictException(CONFLICT_MESSAGE);

        var newCategory = _mapper.Map<Category>(newCategoryDto);
        newCategory = await _categoriesRepository.CreateCategoryAsync(newCategory);

        return _mapper.Map<CategoryDto>(newCategory);
    }

    public async Task UpdateCategoryAsync(int categoryId, RequestCategoryDto updatedCategoryDto)
    {
        var categoryToUpdate = await _categoriesRepository.GetCategoryAsync(categoryId);

        if (categoryToUpdate == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        categoryToUpdate = _mapper.Map<Category>(updatedCategoryDto);

        await _categoriesRepository.UpdateCategoryAsync(categoryId, categoryToUpdate);
    }

    public async Task DeleteCategoryAsync(int categoryId)
    {
        var categoryToDelete = await _categoriesRepository.GetCategoryAsync(categoryId);

        if (categoryToDelete == null)
            throw new NotFoundException(NOT_FOUND_MESSAGE);

        await _categoriesRepository.DeleteCategoryAsync(categoryId);
    }
}
