using HospitalServerHub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//added2.
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapHub<AppointmentHub>("/appointmentHub");

app.MapHub<SupplierContact>("/inventory");

app.MapHub<ChatHub>("/chathub");

app.MapHub<PatientERSignal>("/patientER");

app.MapHub<CodeRedAlert>("/codeRedAlert");

app.Run();
