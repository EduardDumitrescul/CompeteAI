import { Component, OnInit, OnDestroy } from '@angular/core';
// import { HttpClient, HttpParams } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators, AbstractControl, AsyncValidatorFn } from '@angular/forms';
import { Observable, Subject } from 'rxjs';
import { map, takeUntil } from 'rxjs/operators';

import { Tournament } from '.././tournament';
import { BaseFormComponent } from '../../base-form.component';
import { TournamentService } from '.././tournament.service';
import { ApiResult } from '../../base.service';

@Component({
  selector: 'app-tournament-edit',
  templateUrl: './tournament-edit.component.html',
  styleUrls: ['./tournament-edit.component.scss']
})
export class TournamentEditComponent
  extends BaseFormComponent implements OnInit, OnDestroy {

  // the view title
  title?: string;

  // the city object to edit or create
  tournament?: Tournament;

  // the city object id, as fetched from the active route:
  // It's NULL when we're adding a new city,
  // and not NULL when we're editing an existing one.
  id?: number;

  // Activity Log (for debugging purposes)
  activityLog: string = '';

  private destroySubject = new Subject();


  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private tournamentService: TournamentService) {
    super();
  }

  ngOnInit() {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      game: new FormControl('', Validators.required),
      startDate: new FormControl('', Validators.required),
      description: new FormControl('', Validators.required),
    }, null);

    // react to form changes
    this.form.valueChanges
      .pipe(takeUntil(this.destroySubject))
      .subscribe(() => {
        if (!this.form.dirty) {
          this.log("Form Model has been loaded.");
        }
        else {
          this.log("Form was updated by the user.");
        }
      });

    // react to changes in the form.name control
    this.form.get("game")!.valueChanges
      .pipe(takeUntil(this.destroySubject))
      .subscribe(() => {
        if (!this.form.dirty) {
          this.log("Game has been loaded with initial values.");
        }
        else {
          this.log("Game was updated by the user.");
        }
      });

    this.form.get("startDate")!.valueChanges
      .pipe(takeUntil(this.destroySubject))
      .subscribe(() => {
        if (!this.form.dirty) {
          this.log("StartDate has been loaded with initial values.");
        }
        else {
          this.log("StartDate was updated by the user.");
        }
      });

    this.form.get("description")!.valueChanges
      .pipe(takeUntil(this.destroySubject))
      .subscribe(() => {
        if (!this.form.dirty) {
          this.log("Description has been loaded with initial values.");
        }
        else {
          this.log("Description was updated by the user.");
        }
      });

    this.form.get("name")!.valueChanges
      .pipe(takeUntil(this.destroySubject))
      .subscribe(() => {
        if (!this.form.dirty) {
          this.log("Name has been loaded with initial values.");
        }
        else {
          this.log("Name was updated by the user.");
        }
      });

    this.loadData();
  }

  log(str: string) {
    this.activityLog += "["
      + new Date().toLocaleString()
      + "] " + str + "<br />";
  }

  loadData() {

    // retrieve the ID from the 'id' parameter
    var idParam = this.activatedRoute.snapshot.paramMap.get('id');
    this.id = idParam ? +idParam : 0;
    if (this.id) {
      // EDIT MODE

      // fetch the city from the server
      this.tournamentService.get(this.id).subscribe(result => {
        this.tournament = result;
        this.title = "Edit Tournament - " + this.tournament.name;

        // update the form with the city value
        this.form.patchValue(this.tournament);
      }, error => console.error(error));
    }
    else {
      // ADD NEW MODE

      this.title = "Create a new Tournament";
    }
  }

  onSubmit() {
    var tournament = (this.id) ? this.tournament : <Tournament>{};
    if (tournament) {
      tournament.name = this.form.controls['name'].value;
      tournament.game = this.form.controls['game'].value;
      tournament.startDate = this.form.controls['startDate'].value;
      tournament.description = this.form.controls['description'].value;


      if (this.id) {
        // EDIT mode
        this.tournamentService
          .put(tournament)
          .subscribe(result => {

            console.log("Tournament " + tournament!.id + " has been updated.");

            this.router.navigate(['/tournaments']);
          }, error => console.error(error));
      }
      else {
        // ADD NEW mode
        this.tournamentService
          .post(tournament)
          .subscribe(result => {

            console.log("Tournament " + result.id + " has been created.");

            // go back to cities view
            this.router.navigate(['/tournaments']);
          }, error => console.error(error));
      }
    }
  }

  //isDupeCity(): AsyncValidatorFn {
  //  return (control: AbstractControl): Observable<{ [key: string]: any } | null> => {

  //    var city = <City>{};
  //    city.id = (this.id) ? this.id : 0;
  //    city.name = this.form.controls['name'].value;
  //    city.lat = +this.form.controls['lat'].value;
  //    city.lon = +this.form.controls['lon'].value;
  //    city.countryId = +this.form.controls['countryId'].value;

  //    return this.cityService.isDupeCity(city).pipe(map(result => {

  //      return (result ? { isDupeCity: true } : null);
  //    }));
  //  }
  //}

  ngOnDestroy() {
    // emit a value with the takeUntil notifier
    this.destroySubject.next(true);
    // complete the subject
    this.destroySubject.complete();
  }
}

