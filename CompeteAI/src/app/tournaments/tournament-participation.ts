export interface TournamentParticipation {
  userId: number;
  tournamentId: number;
  resultId: number;
  username: string;
  rounds: number;
  wins: number;
}
