namespace MCExercise.Models.DTOs
{
    public class UniversityCategorySummarizationDTO
    {
        public int CategoryCount { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Guid UniversityId { get; set; }

        public UniversityCategorySummarizationDTO(int _CategoryCount, string _Email, string _Name, Guid _UniversityId)
        {
            CategoryCount = _CategoryCount;
            Email = _Email;
            Name = _Name;
            UniversityId = _UniversityId;
        }
    }
}
