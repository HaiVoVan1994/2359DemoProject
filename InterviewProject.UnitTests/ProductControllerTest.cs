namespace InterviewProject.UnitTests
{
    using InterviewProject.Api.Controllers;
    using InterviewProject.Application.ProductFeature;
    using InterviewProject.Common;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Xunit;
    public class ProductControllerTest
    {
        private Mock<IMediator> _mediator;
        public ProductControllerTest()
        {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async void SearchProduct_Success()
        {
            var searchProductQuery = new SearchProductQuery { CategoryId = 1 };
            _mediator.Setup(x => x.Send(It.IsAny<SearchProductQuery>(), new CancellationToken())).
                ReturnsAsync(new SuccessResult<SearchProductResult>(new SearchProductResult
                {
                    Products = new List<SearchProductResultModel> 
                        {
                             new SearchProductResultModel { Id = 1, CategoryId = 1 }
                        }
                }));

            var productController = new ProductController(_mediator.Object, null);
            var result = productController.SearchProduct(searchProductQuery).Result as ObjectResult;
            var actualResult = result.Value as SuccessResult<SearchProductResult>;

            Assert.True(actualResult.Payload.Products.Any(x => x.CategoryId == 1));
        }
    }
}
