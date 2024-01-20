import { Component, OnInit } from '@angular/core';
import { Tournament } from '../tournament';
import { ActivatedRoute, Router } from '@angular/router';
import { TournamentService } from '../tournament.service';
import { UserService } from '../../user.service';
import { User } from '../../user';
import { Observable, forkJoin, switchMap } from 'rxjs';

@Component({
  selector: 'app-tournament-view',
  templateUrl: './tournament-view.component.html',
  styleUrls: ['./tournament-view.component.scss']
})
export class TournamentViewComponent implements OnInit {
  tournament?: Tournament;
  currentUser?: User;
  userIsRegistered?: Boolean;
  id?: number;
  title?: string;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private tournamentService: TournamentService,
    private userService: UserService) {
  }

    ngOnInit(): void {
      this.loadData();
    }


  loadData() {

    // retrieve the ID from the 'id' parameter
    var idParam = this.activatedRoute.snapshot.paramMap.get('id');
    this.id = idParam ? +idParam : 0;
    
    forkJoin([
      this.tournamentService.get(this.id),
      this.userService.currentUser()
    ])
      .pipe(
        switchMap(([tournamentResult, currentUserResult]) => {
          this.tournament = tournamentResult;
          this.title = this.tournament.name;
          this.currentUser = currentUserResult;

          // Now that the first two functions are completed, call the third one
          return this.tournamentService.userIsRegistered(this.currentUser.id, this.tournament.id);
        })
      )
      .subscribe(
        result => {
          this.userIsRegistered = result;
        },
        error => console.error(error)
      );
  }

  join() {
    if (this.currentUser == undefined || this.tournament == undefined) {
      return;
    }
    console.log(this.currentUser, this.tournament);
    if (this.userIsRegistered) {
      this.tournamentService.unregisterUser(this.currentUser.id, this.tournament.id).subscribe(res => {
        console.log(res);
      });
    }
    else {
      this.tournamentService.registerUser(this.currentUser.id, this.tournament.id).subscribe(res => {
        console.log(res);
      });
    }
    window.location.reload();
  }

}
