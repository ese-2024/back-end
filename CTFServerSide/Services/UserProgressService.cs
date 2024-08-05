using CTFServerSide.Data;
using CTFServerSide.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class UserProgressService
{
    private readonly CTFContext _context;

    public UserProgressService(CTFContext context)
    {
        _context = context;
    }

    public IEnumerable<ChallengeDTO> GetCompletedChallenges(int userId)
    {
        return _context.UserChallenges
            .Where(uc => uc.UserId == userId && uc.IsCompleted)
            .Include(uc => uc.Challenge)
                .ThenInclude(c => c.Quests)
                    .ThenInclude(q => q.Steps)
            .Select(uc => new ChallengeDTO
            {
                Id = uc.ChallengeId,
                Title = uc.Challenge.Title,
                Description = uc.Challenge.Description,
                Quests = uc.Challenge.Quests.Select(q => new QuestDTO
                {
                    Id = q.Id,
                    Title = q.Title,
                    Steps = q.Steps.Select(s => new StepDTO
                    {
                        Id = s.Id,
                        Description = s.Description,
                        ExpectedAnswer = s.ExpectedAnswer,
                        Command = s.Command,
                        IsCompleted = s.IsCompleted,
                        Order = s.Order
                    }).ToList()
                }).ToList()
            }).ToList();
    }

    public IEnumerable<QuestDTO> GetCompletedQuests(int userId)
    {
        return _context.UserQuests
            .Where(uq => uq.UserId == userId && uq.IsCompleted)
            .Include(uq => uq.Quest)
                .ThenInclude(q => q.Steps)
            .Select(uq => new QuestDTO
            {
                Id = uq.QuestId,
                Title = uq.Quest.Title,
                IsCompleted = uq.IsCompleted,
                Steps = uq.Quest.Steps.Select(s => new StepDTO
                {
                    Id = s.Id,
                    Description = s.Description,
                    ExpectedAnswer = s.ExpectedAnswer,
                    Command = s.Command,
                    IsCompleted = s.IsCompleted,
                    Order = s.Order,
                }).ToList()
            }).ToList();
    }
}
