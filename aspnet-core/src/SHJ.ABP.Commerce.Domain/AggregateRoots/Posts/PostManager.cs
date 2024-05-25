using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp;

namespace SHJ.ABP.Commerce.AggregateRoots.Posts;

public class PostManager : DomainService
{
    private IPostRepository _postRepository;

    public PostManager(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }


    public virtual async Task<Post> NewAsync(string title, string description, Guid? documentId, string? link = "", string? metaDescription = "", string? metaTags = "", string? titleSeo = "", string? canonicalTag = "", string? altImage = "")
    {
        Check.NotNullOrEmpty(title, nameof(title));
        Check.NotNullOrEmpty(description, nameof(description));
        string code = await _postRepository.GenerateCodeAsync();

        return new Post(title, code, description, link, metaDescription, metaTags,
                        titleSeo, canonicalTag, altImage, documentId);
    }



}
