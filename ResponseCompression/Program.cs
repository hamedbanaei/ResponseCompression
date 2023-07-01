// ********** ********** ********** ********** **********
// **********    Basic Response Compression    **********
// ********** ********** ********** ********** **********
//var builder = WebApplication.CreateBuilder(args);

//// AddResponseCompression() => using Microsoft.AspNetCore.ResponseCompression;
//builder.Services.AddResponseCompression(options =>
//{
//	options.EnableForHttps = true;
//});

//var app = builder.Build();

//app.UseResponseCompression();

//app.MapGet("/", () => "This response will be compressed!");

//app.Run();
// ********** ********** ********** ********** **********
// **********    Basic Response Compression    **********
// ********** ********** ********** ********** **********






// ********** ********** ********** ********** **********
// **********   Adding Compression Providers   **********
// ********** ********** ********** ********** **********
//using Microsoft.AspNetCore.ResponseCompression;

//var builder = WebApplication.CreateBuilder(args);

//// AddResponseCompression() => using Microsoft.AspNetCore.ResponseCompression;
//builder.Services.AddResponseCompression(options =>
//{
//	options.EnableForHttps = true;
//	options.Providers.Add<BrotliCompressionProvider>();
//	options.Providers.Add<GzipCompressionProvider>();
//	options.MimeTypes = ResponseCompressionDefaults.MimeTypes;
//});

//var app = builder.Build();

//app.UseResponseCompression();

//app.MapGet("/", () => "This response will be compressed!");

//app.Run();
// ********** ********** ********** ********** **********
// **********   Adding Compression Providers   **********
// ********** ********** ********** ********** **********






// ********** ********** ********** ********** **********
// **********     Adding Compression Level     **********
// ********** ********** ********** ********** **********
//using Microsoft.AspNetCore.ResponseCompression;

//var builder = WebApplication.CreateBuilder(args);

//// AddResponseCompression() => using Microsoft.AspNetCore.ResponseCompression;
//builder.Services.AddResponseCompression(options =>
//{
//	options.EnableForHttps = true;
//	options.Providers.Add<BrotliCompressionProvider>();
//	options.Providers.Add<GzipCompressionProvider>();
//	options.MimeTypes = ResponseCompressionDefaults.MimeTypes;
//});

//builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
//{
//	options.Level = System.IO.Compression.CompressionLevel.Optimal;
//});

//builder.Services.Configure<GzipCompressionProviderOptions>(options =>
//{
//	options.Level = System.IO.Compression.CompressionLevel.SmallestSize;
//});

//var app = builder.Build();

//app.UseResponseCompression();

//app.MapGet("/", () => "This response will be compressed!");

//app.Run();
// ********** ********** ********** ********** **********
// **********     Adding Compression Level     **********
// ********** ********** ********** ********** **********






// ********** ********** ********** ********** **********
// **********     Comparing Brotli & GZip      **********
// ********** ********** ********** ********** **********
using Microsoft.AspNetCore.ResponseCompression;
using ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// AddResponseCompression() => using Microsoft.AspNetCore.ResponseCompression;
builder.Services.AddResponseCompression(options =>
{
	options.EnableForHttps = true;
	options.Providers.Add<BrotliCompressionProvider>();
	//options.Providers.Add<GzipCompressionProvider>();
	options.MimeTypes = ResponseCompressionDefaults.MimeTypes;
});

builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
	options.Level = System.IO.Compression.CompressionLevel.Optimal;
});

//builder.Services.Configure<GzipCompressionProviderOptions>(options =>
//{
//	options.Level = System.IO.Compression.CompressionLevel.SmallestSize;
//});

var app = builder.Build();

app.UseResponseCompression();

app.MapGet("/", () => Results.Ok(
	Enumerable
		.Range(1, 100)
		.Select(num => new Message
		{
			Id = num,
			Content = $"This is the message #{num}",
		})));

app.Run();
// ********** ********** ********** ********** **********
// **********     Comparing Brotli & GZip      **********
// ********** ********** ********** ********** **********