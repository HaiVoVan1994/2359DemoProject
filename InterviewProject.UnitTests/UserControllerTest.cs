namespace InterviewProject.UnitTests
{
    using InterviewProject.Api.Controllers;
    using InterviewProject.Application.UserFeature;
    using InterviewProject.Common;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Threading;
    using Xunit;
    public class UserControllerTest
    {
        private Mock<IMediator> _mediator;
        public UserControllerTest()
        {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async void UserLogin_Success()
        {
            var loginWithAdminQuery = new LoginQuery{ Username = "admin", Password = "admin"};
            _mediator.Setup(x => x.Send(It.IsAny<LoginQuery>(), new CancellationToken())).
                ReturnsAsync(new SuccessResult<LoginResult>(new LoginResult { Id = 1 }));

            var userController = new UserController(_mediator.Object, null);
            var result = userController.Login(loginWithAdminQuery);
            Assert.IsType<OkObjectResult>(result.Result);
        }


        [Fact]
        public async void UserLogin_Fail()
        {
            var loginWithAdminQuery = new LoginQuery { Username = "admin", Password = "admin1" };
            _mediator.Setup(x => x.Send(It.IsAny<LoginQuery>(), new CancellationToken())).
                ReturnsAsync(new FailResult<LoginResult>("Wrong password"));

            var userController = new UserController(_mediator.Object, null);
            var result = userController.Login(loginWithAdminQuery).Result as ObjectResult;
            var actualResult = result.Value as FailResult<LoginResult>;

            Assert.True(!actualResult.IsSuccess);
        }
    }
}
