namespace CTFServerSide.DTOs
{
    public class ChallengeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public List<NecessaryKnowledgeDTO> NecessaryKnowledges { get; set; }
        public List<MaterialDTO> Materials { get; set; }
        public List<QuestDTO> Quests { get; set; }
    }

}
