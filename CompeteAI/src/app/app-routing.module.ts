import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login.component';
import { RegisterComponent } from './auth/register.component';
import { LeaderboardComponent } from './leaderboard/leaderboard.component';
import { TournamentsComponent } from './tournaments/tournaments.component';
import { TournamentEditComponent } from './tournaments/tournament-edit/tournament-edit.component';
import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  {path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent },
  { path: 'leaderboard', component: LeaderboardComponent },
  { path: 'tournaments', component: TournamentsComponent },
  { path: 'tournament/:id', component: TournamentEditComponent, canActivate: [AuthGuard] },
  { path: 'tournament', component: TournamentEditComponent, canActivate: [AuthGuard] },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
