﻿using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.InsertProject
{
    public class InsertProjectHandler : IRequestHandler<InsertProjectCommand, ResultViewModel<int>>
    {
        //private readonly DevFreelaDbContext _context;
        //private readonly IMediator _mediator;
        private readonly IProjectRepository _repository;

        //public InsertProjectHandler(DevFreelaDbContext context, IMediator mediator)
        //{
        //    _context = context;
        //    _mediator = mediator;
        //}

        public InsertProjectHandler(IProjectRepository repository)
        {            
            _repository = repository;
        }

        //public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
        //{
        //    var project = request.ToEntity();

        //    await _context.Projects.AddAsync(project);
        //    await _context.SaveChangesAsync();

        //    var projectCreated = new ProjectCreatedNotification(project.Id, project.Title, project.TotalCost);
        //    //await _mediator.Publish(projectCreated);
        //    return ResultViewModel<int>.Success(project.Id);
        //}

        public async Task<ResultViewModel<int>> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
        {
            var project = request.ToEntity();

            await _repository.Add(project);
            
            return ResultViewModel<int>.Success(project.Id);
        }
    }
}
