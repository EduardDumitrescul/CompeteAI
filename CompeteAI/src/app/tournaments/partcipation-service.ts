import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService, ApiResult } from '../base.service';
import { Observable } from 'rxjs';

import { Tournament } from './tournament';
import { User } from '../user';
import { TournamentParticipation } from './tournament-participants/tournament-participation';

@Injectable({
  providedIn: 'root',
})
export class ParticipationService
  extends BaseService<TournamentParticipation> {
  override get(id: number): Observable<TournamentParticipation> {
      throw new Error('Method not implemented.');
  }
  override put(item: TournamentParticipation): Observable<TournamentParticipation> {
      throw new Error('Method not implemented.');
  }
  override post(item: TournamentParticipation): Observable<TournamentParticipation> {
      throw new Error('Method not implemented.');
  }
  constructor(
    http: HttpClient) {
    super(http);
  }

  getData(
    pageIndex: number,
    pageSize: number,
    sortColumn: string,
    sortOrder: string,
    filterColumn: string | null,
    filterQuery: string | null
  ): Observable<ApiResult<TournamentParticipation>> {
    var url = this.getUrl("api/Participation");
    var params = new HttpParams()
      .set("pageIndex", pageIndex.toString())
      .set("pageSize", pageSize.toString())
      .set("sortColumn", sortColumn)
      .set("sortOrder", sortOrder);

    if (filterColumn && filterQuery) {
      params = params
        .set("filterColumn", filterColumn)
        .set("filterQuery", filterQuery);
    }

    return this.http.get<ApiResult<TournamentParticipation>>(url, { params });
  }


  getTournamentParticipations(
    tournamentId: number,
    pageIndex: number,
    pageSize: number,
    sortColumn: string,
    sortOrder: string,
    filterColumn: string | null,
    filterQuery: string | null
  ): Observable<ApiResult<TournamentParticipation>> {
    var url = this.getUrl("api/Participation/tournament");
    var params = new HttpParams()
      .set("tournamentId", tournamentId)
      .set("pageIndex", pageIndex.toString())
      .set("pageSize", pageSize.toString())
      .set("sortColumn", sortColumn)
      .set("sortOrder", sortOrder);

    if (filterColumn && filterQuery) {
      params = params
        .set("filterColumn", filterColumn)
        .set("filterQuery", filterQuery);
    }

    return this.http.get<ApiResult<TournamentParticipation>>(url, { params });
  }

 
}
