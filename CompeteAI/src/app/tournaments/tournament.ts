import { User } from "../leaderboard/user";

export interface Tournament {
  id: number;
  name: string;
  game: string;
  startDate: Date;
  description: string;
  hostId: string;
  host: User;
}
