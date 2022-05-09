using InterviewProject.Common;
using InterviewProject.Common.Enum;
using MediatR;

namespace InterviewProject.Application.ProductFeature
{
    public class EditProductCommand : IRequest<RequestResult<EditProductResult>>
    {
        public ProductModel NewProduct { get; set; }
    }

    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int UnitOfMeasureId { get; set; }
        public decimal PricePerUnit { get; set; }
        public List<string> ImagesPath { get; set; }
    }

    public class EditProductResult
    {
       
    }

    public class EditProductHandler : IRequestHandler<EditProductCommand, RequestResult<EditProductResult>>
    {
        public async Task<RequestResult<EditProductResult>> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {

            return await Task.FromResult(new SuccessResult<EditProductResult>(new EditProductResult
            {

            }));
        }
    }
}
