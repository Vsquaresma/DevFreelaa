using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsHandler : IRequestHandler<GetAllSkillsQuery, ResultViewModel<List<UserSkillsInputModel>>>
    {
        public Task<ResultViewModel<List<UserSkillsInputModel>>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
