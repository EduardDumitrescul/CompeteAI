import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService, ApiResult } from '../base.service';
import { Observable } from 'rxjs';

import { Tournament } from './tournament';
import { User } from '../user';
import { Result } from './result';

@Injectable({
  providedIn: 'root',
})
export class TournamentService
  extends BaseService<Tournament> {
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
  ): Observable<ApiResult<Tournament>> {
    var url = this.getUrl("api/Tournament");
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

    return this.http.get<ApiResult<Tournament>>(url, { params });
  }

  get(id: number): Observable<Tournament> {
    var url = this.getUrl("api/Tournament/" + id);
    return this.http.get<Tournament>(url);
  }

  getCurrentUser(): Observable<User> {
    var url = this.getUrl("api/Users/CurrentUser");
    return this.http.get<User>(url);
  }

  put(item: Tournament): Observable<Tournament> {
    var url = this.getUrl("api/Tournament/" + item.id);
    return this.http.put<Tournament>(url, item);
  }

  post(item: Tournament): Observable<Tournament> {
    var url = this.getUrl("api/Tournament");
    return this.http.post<Tournament>(url, item);
  }

  registerUser(userId: number, tournamentId: number): Observable<string>  {
    var url = this.getUrl("api/Participation/RegisterUser");
    var params = new HttpParams()
      .set("userId", userId)
      .set("tournamentId", tournamentId);

    return this.http.put<string>(url, null, { params });
  }

  unregisterUser(userId: number, tournamentId: number): Observable<string> {
    var url = this.getUrl("api/Participation/UnregisterUser");
    var params = new HttpParams()
      .set("userId", userId)
      .set("tournamentId", tournamentId);

    return this.http.put<string>(url, null, { params });
  }

  addWin(userId: number, tournamentId: number): Observable<Result> {
    var url = this.getUrl("api/Result/AddWin");
    var params = new HttpParams()
      .set("userId", userId)
      .set("tournamentId", tournamentId);

    return this.http.put<Result>(url, null, { params });
  }

  addLoss(userId: number, tournamentId: number): Observable<Result> {
    var url = this.getUrl("api/Result/AddLoss");
    var params = new HttpParams()
      .set("userId", userId)
      .set("tournamentId", tournamentId);

    return this.http.put<Result>(url, null, { params });
  }

  userIsRegistered(userId: number, tournamentId: number): Observable<Boolean> {
    var url = this.getUrl("api/Participation/IsUserRegistered");
    var params = new HttpParams()
      .set("userId", userId)
      .set("tournamentId", tournamentId);
    return this.http.get<boolean>(url, { params });
  }

  getTournaments(
    pageIndex: number,
    pageSize: number,
    sortColumn: string,
    sortOrder: string,
    filterColumn: string | null,
    filterQuery: string | null
  ): Observable<ApiResult<Tournament>> {
    var url = this.getUrl("api/Tournament");
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

    return this.http.get<ApiResult<Tournament>>(url, { params });
  }
}
