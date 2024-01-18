import { Component, OnInit } from '@angular/core';
import { Tournament } from '../tournament';
import { ActivatedRoute, Router } from '@angular/router';
import { TournamentService } from '../tournament.service';
import { UserService } from '../../user.service';
import { User } from '../../user';

@Component({
  selector: 'app-tournament-view',
  templateUrl: './tournament-view.component.html',
  styleUrls: ['./tournament-view.component.scss']
})
export class TournamentViewComponent implements OnInit {
  tournament?: Tournament;
  currentUser?: User;
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
    

      this.tournamentService.get(this.id).subscribe(result => {
        this.tournament = result;
        this.title = this.tournament.name;
      }, error => console.error(error));

    this.userService.currentUser().subscribe(result => {
      this.currentUser = result;
    }, error => console.error(error));
    
  }
}
