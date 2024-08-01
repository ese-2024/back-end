using CTFServerSide.Data;
using CTFServerSide.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CTFServerSide.Services
{
    public class ChallengeService
    {
        private readonly CTFContext _context;

        public ChallengeService(CTFContext context)
        {
            _context = context;
        }

        public IEnumerable<ChallengeDTO> GetChallenges()
        {
            return _context
                .Challenges
                .Include(c => c.NecessaryKnowledges)
                .Include(c => c.Materials)
                .Include(c => c.Quests)
                    .ThenInclude(q => q.Steps)
                .Select(c => new ChallengeDTO
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    Level = c.Level,
                    NecessaryKnowledges = c.NecessaryKnowledges.Select(nk => new NecessaryKnowledgeDTO
                    {
                        Id = nk.Id,
                        Knowledge = nk.Knowledge
                    }).ToList(),
                    Materials = c.Materials.Select(m => new MaterialDTO
                    {
                        Id = m.Id,
                        Title = m.Title,
                        Link = m.Link,
                    }).ToList(),
                    Quests = c.Quests.Select(q => new QuestDTO
                    {
                        Id = q.Id,
                        Title = q.Title,
                        Description = q.Description,
                        IsCompleted = q.IsCompleted,
                        Order = q.Order,
                        Steps = q.Steps.Select(s => new StepDTO
                        {
                            Id = s.Id,
                            Description = s.Description,
                            ExpectedAnswer = s.ExpectedAnswer,
                            Command = s.Command,
                            IsCompleted = s.IsCompleted,
                            Order = s.Order,
                        }).ToList()
                    }).ToList()
                })
                .ToList();
        }
    }
}
