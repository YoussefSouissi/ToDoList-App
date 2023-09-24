using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ToDoList_App.Data;

namespace ToDoList_App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        //Create DataBase
       DBContext dbContext = new DBContext();
		dbContext.Database.EnsureCreated();

		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
