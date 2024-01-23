export interface TournamentParticipation {
  userId: number;
  tournamentId: number;
  resultId: number;
  username: string;
  roundsPlayed: number;
  wins: number;
}
