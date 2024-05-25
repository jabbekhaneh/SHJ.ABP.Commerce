using SHJ.Commerce.MVC;

var builder = WebApplication.CreateBuilder(args);


builder.ConfigureServices().Build()
       .ConfigurePipeline().Run();




