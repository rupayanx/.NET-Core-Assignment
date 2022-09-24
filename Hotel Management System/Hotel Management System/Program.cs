using Hotel_Management_System.Data_Access_Layer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RoomDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("HotelConnectionString")));
builder.Services.AddDbContext<EmployeeDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HotelConnectionString")));
builder.Services.AddDbContext<RoomReservationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HotelConnectionString")));
builder.Services.AddDbContext<GuestDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HotelConnectionString")));
builder.Services.AddDbContext<BillDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HotelConnectionString")));
builder.Services.AddDbContext<PaymentDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HotelConnectionString")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
