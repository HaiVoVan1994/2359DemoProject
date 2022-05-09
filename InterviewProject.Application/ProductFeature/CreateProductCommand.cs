namespace InterviewProject.Application.ProductFeature
{
    using InterviewProject.Common;
using InterviewProject.Common.Services;
    using InterviewProject.Domains;
    using InterviewProject.Infrastructure;
    using MediatR;
    using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using static System.Net.Mime.MediaTypeNames;

    public class CreateProductCommand : IRequest<RequestResult<CreateProductResult>>
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int UnitOfMeasureId { get; set; }
        public decimal PricePerUnit { get; set; }
        //.Net core requires name files
        public List<IFormFile>? files { get; set; }
    }

    public class CreateProductResult
    {
       
    }

    public class CreateProductHandler : IRequestHandler<CreateProductCommand, RequestResult<CreateProductResult>>
    {
        private readonly DataContext _db;
        private readonly ILogger<CreateProductHandler> _logger;
        private readonly IUserService _userService;

        public CreateProductHandler(DataContext db, ILogger<CreateProductHandler> logger, IUserService userService)
        {
            _db = db;
            _logger = logger;
            _userService = userService;
        }
        public async Task<RequestResult<CreateProductResult>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (_db.Product.Any(x => x.ProductName.Equals(request.ProductName)))
                {
                    return await Task.FromResult(new FailResult<CreateProductResult>("Product has already existed"));
                }

                var files = request.files;
                var imageFiles = new List<ProductImage>();
                foreach (var file in files)
                {
                    imageFiles.Add(new ProductImage { Binary = ImageToByteArray(file) });
                }

                var newProduct = new Product
                {
                    ProductName = request.ProductName,
                    CategoryId = request.CategoryId,
                    Description = request.Description,
                    UnitOfMeasureId = request.UnitOfMeasureId,
                    PricePerUnit = request.PricePerUnit,
                    Images = imageFiles,
                    Status = Common.Enum.ProductStatusEnum.Available
                };

                _db.Add(newProduct);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, _userService.GetUserName() + " create product error: " + ex.Message);
                throw;
            }
            
            _logger.Log(LogLevel.Information, _userService.GetUserName() +": Search Product");
            return await Task.FromResult(new SuccessResult<CreateProductResult>(new CreateProductResult {}));
        }

        public byte[] ImageToByteArray(IFormFile imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
