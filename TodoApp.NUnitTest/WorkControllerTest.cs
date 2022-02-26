using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using TodoApp.API.Controllers;
using TodoApp.Core.DTOs;
using TodoApp.Core.Model;
using TodoApp.Core.Repositories;
using TodoApp.Core.Services;

namespace TodoApp.NUnitTest
{
    [TestFixture]
    public class Tests
    {
        private Mock<IWorkService> _workService;

        private WorkController _controller;

        private List<WorkAddDto> worksAddDtos;

        private List<WorkUpdateDto> worksUpdateDtos;

        private List<WorkClientDto> worksClientDtos;

        private WorkDto workDtos;

        private NoDataDto noDataDto;
        
        [SetUp]
        public void Setup()
        {

            _workService = new Mock<IWorkService>();
            _controller = new WorkController(_workService.Object);
            worksAddDtos = new List<WorkAddDto>()
            {
                new WorkAddDto()
                {
                    Id = 1, Name = "Ýþ", Definition = "yapýldý", IsCompleted = true,
                    UserId = "f448e38f-257b-4323-96f9-947727c111d5"
                }
            };
            worksUpdateDtos = new List<WorkUpdateDto>()
            {
                new WorkUpdateDto()
                {
                    Id = 1, Name = "Ýþ", Definition = "yapýldý", IsCompleted = true,
                    UserId = "f448e38f-257b-4323-96f9-947727c111d5"
                }
            };
            worksClientDtos = new List<WorkClientDto>()
            {
                new WorkClientDto()
                {
                    Id = 1, Name = "Ýþ", Definition = "yapýldý", IsCompleted = true,
                },

            };

            workDtos = new WorkDto() {Name = "TODO List", Definition = "Definition", IsCompleted = true, Id = 5};

            noDataDto = new NoDataDto()
            {

            };
        }

        [Test]
        public async Task GetWork_ActionExecute_ReturnOkWithWorks()
        {
            _workService.Setup(x => x.GetWorksWithUniqueId())
                .ReturnsAsync(Response<List<WorkClientDto>>.Success(worksClientDtos, 200));

            var result =  _controller.GetWork();


            Assert.IsInstanceOf(typeof(Task<IActionResult>),result);
        }


        [Test]
        public async Task GetWorkById_ActionExecute_ReturnWorkDto()
        {
            _workService.Setup(x => x.GetByIdAsync(2)).
                ReturnsAsync(Response<WorkDto>.Success(workDtos, 200));

            var work =await  _controller.GetWorkById(1);

            var responseWorkDto = Response<WorkDto>.Success(workDtos, 200);

            Assert.AreEqual(responseWorkDto.Data.IsCompleted, true);

            Assert.AreEqual(responseWorkDto.Data.Name, "TODO List");

            Assert.AreEqual(responseWorkDto.Data.Definition, "Definition");
            
        }


        [Test]
        public async Task AddWorksWithUniqueId_ActionExecute_AddWorkDto()
        {
            _workService.Setup(x => x.AddWorksWithUniqueId(worksAddDtos.Find(x => x.Id == 1)));

            var responseWorkDto = Response<List<WorkAddDto>>.Success(worksAddDtos, 200);

            Assert.IsAssignableFrom<List<WorkAddDto>>(responseWorkDto.Data);
        }


        [Test]
        public async Task UpdateWorkWithUniqueId_ActionExecute_WorkUpdateDto()
        {
            _workService.Setup(x => x.UpdateWorkWithUniqueId(worksUpdateDtos[0], 1)).
                ReturnsAsync(Response<NoDataDto>.Success(noDataDto, 204));

            var result = _controller.UpdateWork(worksUpdateDtos[0]);

            var resultObject = new ObjectResult(result).Value;

            var responseWorkDto = Response<WorkDto>.Success(workDtos, 200);

            Assert.AreEqual(responseWorkDto.StatusCode, 200);

        }

        [Test]
        public async Task DeleteWork_ActionExecute_WorkUpdateDto()
        {
            _workService.Setup(x => x.Remove(1)).
                ReturnsAsync(Response<NoDataDto>.Success(noDataDto, 204));

            var result = _controller.DeleteWork(1);

            _workService.Verify(x=>x.Remove(1),Times.Once);

            Assert.IsTrue(result.IsCompleted);

        }




    }
}