using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCore.Entities;
using NetCore.Models;
using NetCore.Services;

namespace NetCore.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly IFamilyBudgetRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionsController(IFamilyBudgetRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{transactionId}", Name = "GetTransaction")]
        public IActionResult GetTransaction(Guid transactionId)
        {
            var incomeTransactionFromRepo = _transactionRepository.GetIncomeTransaction(transactionId);
            var outcomeTransactionFromRepo = _transactionRepository.GetOutcomeTransaction(transactionId);

            if (incomeTransactionFromRepo == null && outcomeTransactionFromRepo == null)
            {
                return NotFound();
            }

            return Ok(incomeTransactionFromRepo == null ? _mapper.Map<TransactionDto>(outcomeTransactionFromRepo)
                : _mapper.Map<TransactionDto>(incomeTransactionFromRepo));
        }

        [HttpGet("income")]
        public ActionResult<IEnumerable<TransactionDto>> GetIncomeTransactions()
        {
            var transactionsFromRepo = _transactionRepository.GetIncomeTransactions();
            if (transactionsFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<TransactionDto>>(transactionsFromRepo));
        }

        [HttpGet("outcome")]
        public ActionResult<IEnumerable<TransactionDto>> GetOutcomeTransactions()
        {
            var transactionsFromRepo = _transactionRepository.GetOutcomeTransactions();
            if (transactionsFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<TransactionDto>>(transactionsFromRepo));
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransactionDto>> GetAllTransactions()
        {
            var outcomeTransactionsFromRepo = _transactionRepository.GetOutcomeTransactions();

            var incomeTransactionsFromRepo = _transactionRepository.GetIncomeTransactions();

            var combinedTransactions = incomeTransactionsFromRepo?.Concat(outcomeTransactionsFromRepo)
                .OrderBy(s => s.DateTime);

            if (combinedTransactions == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<TransactionDto>>(combinedTransactions));
        }

        [HttpPost("income")]
        public ActionResult<TransactionDto> CreateIncomeTransaction(TransactionForCreationDto transaction)
        {
            var transactionEntity = _mapper.Map<Entities.IncomeTransaction>(transaction);
            _transactionRepository.AddIncomeTransaction(transactionEntity);
            _transactionRepository.Save();

            var transactionToReturn = _mapper.Map<TransactionDto>(transactionEntity);
            return CreatedAtRoute("GetTransaction", new { transactionId = transactionToReturn.Id }, transactionToReturn);
        }

        [HttpPost("outcome")]
        public ActionResult<TransactionDto> CreateOutcomeTransaction(TransactionForCreationDto transaction)
        {
            var transactionEntity = _mapper.Map<Entities.OutcomeTransaction>(transaction);
            _transactionRepository.AddOutcomeTransaction(transactionEntity);
            _transactionRepository.Save();

            var transactionToReturn = _mapper.Map<TransactionDto>(transactionEntity);
            return CreatedAtRoute("GetTransaction", new { transactionId = transactionToReturn.Id }, transactionToReturn);
        }

        [HttpPut("{transactionId}")]
        public IActionResult UpdateTransaction(Guid transactionId, TransactionForUpdateDto transaction)
        {
            if (!_transactionRepository.IncomeTransactionExists(transactionId) && !_transactionRepository.OutcomeTransactionExists(transactionId))
            {
                return NotFound();
            }

            var incomeTransactionFromRepo = _transactionRepository.GetIncomeTransaction(transactionId);
            var outcomeTransactionFromRepo = _transactionRepository.GetOutcomeTransaction(transactionId);

            if (incomeTransactionFromRepo != null)
                _mapper.Map(transaction, incomeTransactionFromRepo);

            if (outcomeTransactionFromRepo != null)
                _mapper.Map(transaction, outcomeTransactionFromRepo);

            _transactionRepository.Save();
            return NoContent();
        }

        [HttpDelete("{transactionId}")]
        public ActionResult DeleteTransaction(Guid transactionId)
        {

            var incomeTransactionFromRepo = _transactionRepository.GetIncomeTransaction(transactionId);
            var outcomeTransactionFromRepo = _transactionRepository.GetOutcomeTransaction(transactionId);

            if (incomeTransactionFromRepo == null && outcomeTransactionFromRepo == null)
            {
                return NotFound();
            }

            if (incomeTransactionFromRepo != null)
                _transactionRepository.DeleteIncomeTransaction(incomeTransactionFromRepo);
            if (outcomeTransactionFromRepo != null)
                _transactionRepository.DeleteOutcomeTransaction(outcomeTransactionFromRepo);

            _transactionRepository.Save();
            return NoContent();
        }

        [HttpGet("today")]
        public ActionResult<IEnumerable<TransactionDto>> GetTodayTransactions()
        {
            var outcomeTransactionsFromRepo = _transactionRepository.GetOutcomeTransactions();

            var incomeTransactionsFromRepo = _transactionRepository.GetIncomeTransactions();

            var combinedTransactions = incomeTransactionsFromRepo?.Concat(outcomeTransactionsFromRepo)
                .Where(s => s.DateTime.Date.Equals(DateTime.Today));

            if (combinedTransactions == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<TransactionDto>>(combinedTransactions));
        }

        [HttpGet("monthly")]
        public ActionResult<IEnumerable<TransactionDto>> GetMonthlyTransactions()
        {
            var outcomeTransactionsFromRepo = _transactionRepository.GetOutcomeTransactions();

            var incomeTransactionsFromRepo = _transactionRepository.GetIncomeTransactions();

            var combinedTransactions = incomeTransactionsFromRepo?.Concat(outcomeTransactionsFromRepo)
                .Where(s => s.DateTime.Month.Equals(DateTime.Today.Month));

            if (combinedTransactions == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<TransactionDto>>(combinedTransactions));
        }
    }


}
