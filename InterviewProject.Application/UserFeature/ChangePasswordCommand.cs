namespace InterviewProject.Application.UserFeature
{
    using InterviewProject.Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ChangePasswordCommand : IRequest<RequestResult<ChangePasswordResult>>
    {
    }

    public class ChangePasswordResult
    {

    }

    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, RequestResult<ChangePasswordResult>>
    {
        public Task<RequestResult<ChangePasswordResult>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
