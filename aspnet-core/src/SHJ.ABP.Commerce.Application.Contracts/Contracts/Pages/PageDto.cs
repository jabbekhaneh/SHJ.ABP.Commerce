using System;
using Volo.Abp.Application.Dtos;

namespace SHJ.ABP.Commerce.Contracts.Pages;

public class PageDto : EntityDto<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Script { get; set; } = string.Empty;
    public string Style { get; set; } = string.Empty;
    public bool IsHomePage { get; set; }
    public DateTime? CreationTime { get; set; }
    public Guid? CreatorId { get; set; }
    public DateTime? LastModificationTime { get; set; }
    public Guid LastModifierId { get; set; }

}

