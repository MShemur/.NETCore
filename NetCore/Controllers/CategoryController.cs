using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCore.Models;
using NetCore.Services;

namespace NetCore.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IFamilyBudgetRepository _transactionRepository;
        private readonly IMapper _mapper;

        public CategoryController(IFamilyBudgetRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var outcomeCategoriesFromRepo = _transactionRepository.GetOutcomeCategories();

            var incomeCategoriesFromRepo = _transactionRepository.GetIncomeCategories();

            var combinedCategories = incomeCategoriesFromRepo.Concat(outcomeCategoriesFromRepo);

            if (combinedCategories == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(combinedCategories));
        }

        [HttpGet("{categoryId}", Name = "GetCategory")]
        public IActionResult GetTransaction(Guid categoryId)
        {
            var incomeCategoryFromRepo = _transactionRepository.GetIncomeCategory(categoryId);
            var outcomeCategoryFromRepo = _transactionRepository.GetOutcomeCategory(categoryId);

            if (incomeCategoryFromRepo == null && outcomeCategoryFromRepo == null)
            {
                return NotFound();
            }

            return Ok(incomeCategoryFromRepo == null ? _mapper.Map<CategoryDto>(outcomeCategoryFromRepo)
                : _mapper.Map<CategoryDto>(incomeCategoryFromRepo));
        }

        [HttpGet("income")]
        public ActionResult<IEnumerable<CategoryDto>> GetIncomeCategories()
        {
            var incomeCategoryFromRepo = _transactionRepository.GetIncomeCategories();
            if (incomeCategoryFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(incomeCategoryFromRepo));
        }

        [HttpGet("outcome")]
        public ActionResult<IEnumerable<CategoryDto>> GetOutcomeCategories()
        {
            var outcomeCategoryFromRepo = _transactionRepository.GetOutcomeCategories();
            if (outcomeCategoryFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(outcomeCategoryFromRepo));
        }

        
        [HttpPost("income")]
        public ActionResult<CategoryDto> CreateIncomeCategory(CategoryForCreationDto category)
        {
            var categoryEntity = _mapper.Map<Entities.IncomeCategory>(category);
            _transactionRepository.AddIncomeCategory(categoryEntity);
            _transactionRepository.Save();

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);
            return CreatedAtRoute("GetCategory", new { categoryId = categoryToReturn.Id }, categoryToReturn);
        }

        [HttpPost("outcome")]
        public ActionResult<TransactionDto> CreateOutcomeCategory(CategoryForCreationDto category)
        {
            var categoryEntity = _mapper.Map<Entities.OutcomeCategory>(category);
            _transactionRepository.AddOutcomeCategory(categoryEntity);
            _transactionRepository.Save();

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);
            return CreatedAtRoute("GetCategory", new { categoryId = categoryToReturn.Id }, categoryToReturn);
        }

        [HttpPut("{categoryId}")]
        public IActionResult UpdateCategory(Guid categoryId, CategoryForUpdateDto category)
        {
            if (!_transactionRepository.IncomeCategoryExists(categoryId) && !_transactionRepository.OutcomeCategoryExists(categoryId))
            {
                return NotFound();
            }

            var incomeCategoryFromRepo = _transactionRepository.GetIncomeCategory(categoryId);
            var outcomeCategoryFromRepo = _transactionRepository.GetOutcomeCategory(categoryId);

            if (incomeCategoryFromRepo != null)
                _mapper.Map(category, incomeCategoryFromRepo);

            if (outcomeCategoryFromRepo != null)
                _mapper.Map(category, outcomeCategoryFromRepo);

            _transactionRepository.Save();
            return NoContent();
        }

        [HttpDelete("{categoryId}")]
        public ActionResult DeleteCategory(Guid categoryId)
        {

            var incomeCategoryFromRepo = _transactionRepository.GetIncomeCategory(categoryId);
            var outcomeCategoryFromRepo = _transactionRepository.GetOutcomeCategory(categoryId);

            if (incomeCategoryFromRepo == null && outcomeCategoryFromRepo == null)
            {
                return NotFound();
            }

            if (incomeCategoryFromRepo != null)
                _transactionRepository.DeleteIncomeCategory(incomeCategoryFromRepo);
            if (outcomeCategoryFromRepo != null)
                _transactionRepository.DeleteOutcomeCategory(outcomeCategoryFromRepo);

            _transactionRepository.Save();
            return NoContent();
        }

    }
}
