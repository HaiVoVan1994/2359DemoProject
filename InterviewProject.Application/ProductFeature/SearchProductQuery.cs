namespace InterviewProject.Application.ProductFeature
{
    using InterviewProject.Common;
    using InterviewProject.Common.Enum;
    using InterviewProject.Common.Services;
    using InterviewProject.Infrastructure;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class SearchProductQuery: IRequest<RequestResult<SearchProductResult>>
    {
        public string? ProductName { get; set; }
        public int CategoryId { get; set; }
        public int? ProductStatus { get; set; }
    }

    public class SearchProductResult
    {
        public List<SearchProductResultModel> Products { get; set; }
    }

    public class SearchProductResultModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int UnitOfMeasureId { get; set; }
        public string UnitOfMeasureName { get; set; }
        public decimal PricePerUnit { get; set; }
        public ProductStatusEnum Status { get; set; }
        public string StatusDescription { get; set; }
        public List<ProductImageModel> Images { get; set; }
    }

    public class ProductImageModel
    {
        public int Id { get; set; }
        public string ImageBase64 { get; set; }
    }

    public class SearchProductHandler : IRequestHandler<SearchProductQuery, RequestResult<SearchProductResult>>
    {
        private readonly DataContext _db;
        private readonly ILogger<SearchProductHandler> _logger;
        private readonly IUserService _userService;
        public SearchProductHandler(DataContext db, ILogger<SearchProductHandler> logger, IUserService userService)
        {
            _db = db;
            _logger = logger;
            _userService = userService;
        }

        public async Task<RequestResult<SearchProductResult>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            var result = new List<SearchProductResultModel>();
            try
            {
                result = _db.Product
                .Where(x => request.CategoryId == -1 || x.CategoryId == request.CategoryId)
                .Where(x => string.IsNullOrEmpty(request.ProductName) || x.ProductName.Equals(request.ProductName))
                .Where(x => request.ProductStatus == -1 || x.Status == (ProductStatusEnum)request.ProductStatus)
                .Select(x => new SearchProductResultModel
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    Description = x.Description,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.CategoryName,
                    UnitOfMeasureId = x.UnitOfMeasureId,
                    UnitOfMeasureName = x.UnitOfMeasure.UnitName,
                    PricePerUnit = x.PricePerUnit,
                    Status = x.Status,
                    StatusDescription = x.Status.ToString(),
                    Images = x.Images.Select(x => new ProductImageModel { Id = x.Id, ImageBase64 = Convert.ToBase64String(x.Binary) }).ToList()
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, _userService.GetUserName() +" search product error: "+ ex.Message);
                throw;
            }
            
            _logger.Log(LogLevel.Information, _userService.GetUserName() +": Search Product");
            return await Task.FromResult(new SuccessResult<SearchProductResult>(new SearchProductResult {
                 Products = result
            }));
        }
    }
}
