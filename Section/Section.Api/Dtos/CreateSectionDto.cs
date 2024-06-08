namespace Section.Api.Dtos
{
    public sealed class CreateSectionDto
    {
        public string Name { get; init; }
        public string? Description { get; init; }
        public bool IsSport { get; init; }
        public DayOfWeek Day { get; init; }
        public TimeOnly Time { get; init; }

        //z sesji
        public Guid TeacherId { get; init; }
        public int LimitOfPlaces { get; init; }
    }
}
