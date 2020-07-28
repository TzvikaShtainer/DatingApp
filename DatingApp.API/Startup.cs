using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatingApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) // הסדר של הדברים בפעולה לא חשובים
        {
            services.AddDbContext<DataContext>(x => x.UseSqlite
                (Configuration.GetConnectionString("DefaultConnection"))); // הוספה של הדאטא שבנינו והחיבור שלו לדאטאבייס שנבנה
            services.AddControllers();
            services.AddCors();// מוסיף את הקורס שגורם לאתר שלי לזהות את האנגור והקור כעובדים משותפים
            services.AddScoped<IAuthRepository, AuthRepository>(); //הסרבר נוצר פעם אחת פר בקשה
            // שורה למעלה - עושה אינג'קט לאי רפוזטורי כדי שנשתמש בפעולות שלו ואחרי הפסיק שמים את הרפוזטורי שבו יש מימוש של הפעולת

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // מגדירים את הקורס פוליסי כלומר מה אנחנו מרשים שיהיה
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
