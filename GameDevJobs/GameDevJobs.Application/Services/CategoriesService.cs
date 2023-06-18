using AutoMapper;
using GameDevJobs.Application.Dto.Categories;
using GameDevJobs.Application.Interfaces;
using GameDevJobs.Domain.Interfaces;
using GameDevJobs.Application.Exceptions;

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

    public Task<CategoryDto> CreateCategory(RequestCategoryDto newCategoryDto)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CategoryDto>> GetCategories()
    {
        var categories = await _categoriesRepository.GetCategories();

        return _mapper.Map<List<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetCategory(int categoryId)
    {
        var category = await _categoriesRepository.GetCategory(categoryId);

        if (category == null)
            throw new NotFoundException("Category with this id does not exist.");

        return _mapper.Map<CategoryDto>(category);
    }

    public Task UpdateCategory(int categoryId, RequestCategoryDto updatedCategoryDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategory(int categoryId)
    {
        throw new NotImplementedException();
    }
}
