namespace CompeteAiAPI.Data.DTO
{
    public class ParticipationDTO
    {
        public int? UserId {  get; set; }

        public int? TournamentId {  get; set; }

        public int? ResultId {  get; set; }

        public string Username { get; set; } = "username";

        public int RoundsPlayed { get; set; } = 0;

        public int Wins { get; set; } = 0; 
    }
}
