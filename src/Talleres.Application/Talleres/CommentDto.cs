using Abp.Application.Services.Dto;
using System;

namespace Talleres
{
    public class CommentDto : EntityDto
    {
        public Guid? OriginId { get; set; }
        public string Description { get; set; }        
        public string CreatorUser { get; set; }
        public virtual long? CreatorUserId { get; set; }
        public virtual DateTime CreationTime { get; set; }
    }
}
