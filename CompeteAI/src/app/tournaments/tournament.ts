import { User } from "../user";

export interface Tournament {
  id: number;
  name: string;
  game: string;
  startDate: Date;
  description: string;
  hostId: number;
  host: User;
}
