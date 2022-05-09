using InterviewProject.Application.UserFeature;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace InterviewProject.UnitTests.UserFeatureTest
{
    
    public class LoginQueryTest
    {

        [Fact]
        public async void UserLogin_Succeed()
        {
            //Mock<IMediator> mediatrMock = new Mock<IMediator>();
            //var moqResult = "FooTest";

            //mediatrMock.Setup(x => x.)
            //mediatrMock.Setup(m =>
            //    m.Send(It.IsAny<LoginQuery>(),
            //        It.IsAny<CancellationToken>())).Returns(new );


            //var sut = new HomeController(mediatrMock.Object);
            //var ret = await sut.TestFoo();
            //Assert.Equal(moqResult, ret.Value);

            //mediatrMock.Verify(x => x.Send(It.IsAny<Foo.Query>(),
            //    It.IsAny<CancellationToken>()));
        }
    }
}
