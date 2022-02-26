using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TodoApp.Core.DTOs;
using TodoApp.Core.Model;
using TodoApp.Core.Repositories;
using TodoApp.Core.Services;
using TodoApp.Core.UnitOfWorks;
using TodoApp.Service.Mapping;

namespace TodoApp.Service.Services
{
    public class WorkService:ServiceGeneric<Work,WorkDto>,IWorkService
    {
        private IWorkRepository _workRepository;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        public WorkService(IUnitOfWork unitOfWork, IGenericRepository<Work> genericRepository, IWorkRepository workRepository, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, genericRepository)
        {
            _unitOfWork = unitOfWork;
            _workRepository = workRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<Work>> AddWorksWithUniqueId(WorkAddDto workAddDto)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            workAddDto.UserId = userId;

            var newEntity = ObjectMapper.Mapper.Map<Work>(workAddDto);

            await _workRepository.AddWorkByUniqueId(newEntity);

            await _unitOfWork.CommitAsync();

            return Response<Work>.Success(newEntity, 200);

        }

        public async Task<Response<NoDataDto>> UpdateWorkWithUniqueId(WorkUpdateDto entity, int id)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            entity.UserId = userId;

            var isExistEntity = await _workRepository.GetByIdUniqueAsync(id);

            if (isExistEntity.UserId != userId)
            {
                return Response<NoDataDto>.Fail("UnAuthorized", 401, true);
            }

            if (isExistEntity == null)
            {
                return Response<NoDataDto>.Fail("Id not found", 404, true);
            }

            var updatedEntity = ObjectMapper.Mapper.Map<Work>(entity);

            _workRepository.UpdateByUniqueId(updatedEntity);

            await _unitOfWork.CommitAsync();

            return Response<NoDataDto>.Success(204);

        }

        public async Task<Response<List<WorkClientDto>>> GetWorksWithUniqueId()
        {
            var newEntity = ObjectMapper.Mapper.Map<List<WorkClientDto>>(await _workRepository.GetWorkByUniqueId());

            return Response<List<WorkClientDto>>.Success(newEntity, 200);
        }
    }
}
