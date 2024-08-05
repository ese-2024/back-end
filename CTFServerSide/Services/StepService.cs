using CTFServerSide.Data;
using CTFServerSide.DTOs;
using CTFServerSide.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class StepService
{
    private readonly CTFContext _context;

    public StepService(CTFContext context)
    {
        _context = context;
    }

    public bool SubmitStepAnswer(StepSubmissionDTO stepSubmission, int userId)
    {
        var step = _context.Steps.SingleOrDefault(s => s.Id == stepSubmission.StepId);
        if (step == null)
        {
            return false; // Step not found
        }

        // Check if the submitted answer is correct
        if (step.ExpectedAnswer == stepSubmission.SubmittedAnswer)
        {
            step.IsCompleted = true;
            _context.SaveChanges();

            // Check if all steps for the quest are completed
            var quest = _context.Quests
                .Include(q => q.Steps)
                .SingleOrDefault(q => q.Id == step.QuestId);

            if (quest != null && quest.Steps.All(s => s.IsCompleted))
            {
                quest.IsCompleted = true;
                _context.SaveChanges();

                // Mark the user quest as completed
                var userQuest = _context.UserQuests.SingleOrDefault(uq => uq.UserId == userId && uq.QuestId == quest.Id);
                if (userQuest == null)
                {
                    userQuest = new UserQuest
                    {
                        UserId = userId,
                        QuestId = quest.Id,
                        IsCompleted = true
                    };
                    _context.UserQuests.Add(userQuest);
                }
                else
                {
                    userQuest.IsCompleted = true;
                }
                _context.SaveChanges();

                // Check if all quests for the challenge are completed
                var challenge = _context.Challenges
                    .Include(c => c.Quests)
                    .SingleOrDefault(c => c.Id == quest.ChallengeId);

                if (challenge != null && challenge.Quests.All(q => q.IsCompleted))
                {
                    // Mark the user challenge as completed
                    var userChallenge = _context.UserChallenges.SingleOrDefault(uc => uc.UserId == userId && uc.ChallengeId == challenge.Id);
                    if (userChallenge == null)
                    {
                        userChallenge = new UserChallenge
                        {
                            UserId = userId,
                            ChallengeId = challenge.Id,
                            IsCompleted = true
                        };
                        _context.UserChallenges.Add(userChallenge);
                    }
                    else
                    {
                        userChallenge.IsCompleted = true;
                    }

                    _context.SaveChanges();
                }

                // Update user's score based on the challenge level
                var user = _context.Users.SingleOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.Score += challenge.Level * 100;
                }
                _context.SaveChanges();
            }

            return true; // Answer is correct and step is completed
        }

        return false; // Answer is incorrect
    }
}
