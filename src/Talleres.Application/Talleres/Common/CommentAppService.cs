using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Talleres.Talleres.Common
{
    public class CommentAppService : ApplicationService
    {
        private readonly IRepository<Comment> repository;

        public CommentAppService(IRepository<Comment> repository)
        {
            this.repository = repository;
        }

        public async Task<ListResultDto<CommentDto>> Get(Guid id)
        {
            var comments = await repository.GetAllIncluding(m => m.CreatorUser)
                                           .Where(m => m.OriginId == id)
                                           .ToListAsync();

            return await Task.FromResult(new ListResultDto<CommentDto>(
                 ObjectMapper.Map<List<CommentDto>>(comments)
             ));
        }

        public async Task<ListResultDto<CommentDto>> GetById(Guid id)
        {
            var comments = await repository.GetAllIncluding(m => m.CreatorUser).Where(m => m.OriginId == id).ToListAsync();

            return await Task.FromResult(new ListResultDto<CommentDto>(
                 ObjectMapper.Map<List<CommentDto>>(comments)
             ));
        }

        public Task Create(CommentDto commentDto)
        {
            return repository.InsertAsync(ObjectMapper.Map<Comment>(commentDto));
        }
    }
}
