

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudyGuide.Api.Controllers
{
    using AutoMapper;
    using Common;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/test")]
    public class TestController : Controller
    {
        private readonly IUnitOfWork<studyguideContext> _unitOfWork;
        private readonly IResponseFactory _responseFactory;

        public TestController(IUnitOfWork<studyguideContext> unitOfWork, IResponseFactory responseFactory)
        {
            _unitOfWork = unitOfWork;
            _responseFactory = responseFactory;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Response<TestViewModel> Get(int id)
        {
            try
            {
                var testRepository = _unitOfWork.GetRepository<Test>();
                var cardRepository = _unitOfWork.GetRepository<Card>();

                var test = testRepository.Find(id);
                var cards = cardRepository.GetPagedList(c => c.TestId == id);
                test.Card = cards.Items;

                var testViewModel = Mapper.Map<Test, TestViewModel>(test);
             

                var result = _responseFactory.CreateSuccessResponse(testViewModel, null);
                return result;
            }
            catch (Exception e)
            {

                return _responseFactory.CreateErrorResponse(new TestViewModel(), e);
            }
        }

        // POST api/values
        [HttpPost]
        [Route("search")]
        public Response<List<TestViewModel>> GetPagedList([FromBody]PagedDataRequest request)
        {
            //return pagedTests;
            IPagedList<Test> pagedTests = null;

            try
            {
                var testRepository = _unitOfWork.GetRepository<Test>();
                var specification = new TestPagedDataSpecification(request);
                var whereClause = specification.GenerateWhereClause();
                var orderByClause = specification.GeneratedOrderByClause();

                pagedTests = testRepository.GetPagedList(whereClause, orderByClause, request.Pagination.Start, request.Pagination.Count, true, tests => tests.Include(t => t.Card));

                var test =  Mapper.Map<List<Test>, List<TestViewModel>>(new List<Test>(pagedTests.Items));
                var pagination = new Pagination()
                {
                    Count = pagedTests.PageSize,
                    Start = pagedTests.PageIndex,
                    TotalResults = pagedTests.TotalCount
                };

                var result =  _responseFactory.CreateSuccessResponse(test, pagination);
                return result;
            }
            catch (Exception e)
            {
                
                return _responseFactory.CreateErrorResponse(new List<TestViewModel>(), e);
            }
        }

        // POST api/values
        [HttpPost]
        public Response<TestViewModel> Post([FromBody]TestViewModel value)
        {
            try
            {
                var now = DateTime.Now;

                var testRepository = _unitOfWork.GetRepository<Test>();

                var test = Mapper.Map<TestViewModel, Test>(value);

                test.CreateDate = now;
                testRepository.Insert(test);
                _unitOfWork.SaveChanges();

                var returnViewModel = Mapper.Map<Test, TestViewModel>(test);

                var result = _responseFactory.CreateSuccessResponse(returnViewModel, null);
                return result;
            }
            catch (Exception e)
            {

                return _responseFactory.CreateErrorResponse(new TestViewModel(), e);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public Response<TestViewModel> Put([FromBody]TestViewModel value)
        {
            try
            {
                var testRepository = _unitOfWork.GetRepository<Test>();
              
                var test = Mapper.Map<TestViewModel, Test>(value);
                //var cards = Mapper.Map<List<CardViewModel>, List<Card>>(value.Card.ToList());
                testRepository.Update(test);
                //cardRepository.Update(cards);
                _unitOfWork.SaveChanges();


                var returnViewModel = Mapper.Map<Test, TestViewModel>(test);

                var result = _responseFactory.CreateSuccessResponse(returnViewModel, null);
                return result;
            }
            catch (Exception e)
            {

                return _responseFactory.CreateErrorResponse(new TestViewModel(), e);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                var testRepository = _unitOfWork.GetRepository<Test>();

                testRepository.Delete(id);
              
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
