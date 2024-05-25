using SHJ.ABP.Commerce.AggregateRoots.Pages;
using SHJ.ABP.Commerce.Contracts.Pages;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SHJ.ABP.Commerce.Services.Pages;

public class PagesAppService_Test : CommerceApplicationTestBase
{
    private readonly CommerceTestData _data;
    private readonly IPageAdminAppService _sut;
    private readonly PageManager _manager;
    private readonly IPageRepository _pageRepository;
    public PagesAppService_Test()
    {
        _data = GetRequiredService<CommerceTestData>();
        _sut = GetRequiredService<IPageAdminAppService>();
        _manager = GetRequiredService<PageManager>();
        _pageRepository = GetRequiredService<IPageRepository>();
    }

    [Fact]
    public async Task ShouldGetAsync()
    {
        //arrange
        var page= await CreatePageWith();

        //act
        var actual = await _sut.GetAsync(page.Id);

        //assert
        actual.Title.ShouldBe(page.Title);
    }

    [Fact]
    public async Task ShouldGetListAsync()
    {
        //arrange
        var input = new GetPagesInputDto();

        //act
        var pages = await _sut.GetListAsync(input);

        //assert
        pages.TotalCount.ShouldBe(2);
        pages.Items.Count.ShouldBe(2);
        pages.Items.Any(_ => _.Title == _data.Page_1_Title).ShouldBeTrue();
        pages.Items.Any(_ => _.Title == _data.Page_2_Title).ShouldBeTrue();
    }

    [Fact]
    public async Task ShouldCreateAsync()
    {
        //arrange
        var dto = new CreatePageInputDto
        {
            Title = "test",
            Content = "test*content"
        };


        //act && assert
        await Should.NotThrowAsync(async () => await _sut.CreateAsync(dto));
    }

    [Fact]
    public async Task ShouldUpdatePageAsync()
    {

        //arrange
        var page = await CreatePageWith();
        var dto = new UpdatePageInputDto
        {
            Title = _data.Page_1_Title + "edit".ToLower(),
            Content = "changed"
        };

        //act
        await _sut.UpdateAsync(page.Id, dto);

        //assert
        var updatedPage = await _pageRepository.GetAsync(page.Id);

        updatedPage.Title.ShouldNotBe(_data.Page_1_Title);
        updatedPage.Title.ShouldBe(dto.Title);
        updatedPage.Content.ShouldNotBe(_data.Content_1);
        updatedPage.Content.ShouldBe(dto.Content);
    }

    [Fact]
    public async Task ShouldDeleteAsync()
    {
        //arrange
        var page = await CreatePageWith();


        //act
        await _sut.DeleteAsync(page.Id);

        //assert
        
    }

    [Fact]
    public async Task ShouldSetAsHomePageAsync()
    {
        //arrange
        var page = await CreatePageWith();


        //act
        await _sut.SetAsHomePageAsync(page.Id);

        //assert
        var expected = await _sut.GetAsync(page.Id);
        expected.IsHomePage.ShouldBeTrue();

    }


    #region Exract Methods

    #endregion
    private async Task<PageDto> CreatePageWith()
    {
        var dto = new CreatePageInputDto
        {
            Title = "test",
            Content = "test*content"
        };

        return await _sut.CreateAsync(dto);


    }
}
