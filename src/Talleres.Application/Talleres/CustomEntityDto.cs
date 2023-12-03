using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using Talleres.Users.Dto;

namespace Talleres
{
    public abstract class CustomEntityDto : TalleresEntityDto
    {
        [Required]
        public string Name { get; set; }
        public long CreatorUserId { get; set; }
        public UserDto UserAssigned { get; set; }
        public DateTime CreationTime { get; set; }

    }

    public abstract class TalleresEntityDto<TPrimaryKey> : EntityDto<TPrimaryKey>
    {
        public bool IsDeleted { get; set; }
    }

    public abstract class TalleresEntityDto : TalleresEntityDto<int>
    {

    }
}
