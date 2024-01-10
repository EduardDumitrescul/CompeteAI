import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService, ApiResult } from '../base.service';
import { Observable } from 'rxjs';

import { Tournament } from './tournament';

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

  put(item: Tournament): Observable<Tournament> {
    var url = this.getUrl("api/Tournament/" + item.id);
    return this.http.put<Tournament>(url, item);
  }

  post(item: Tournament): Observable<Tournament> {
    var url = this.getUrl("api/Tournament");
    return this.http.post<Tournament>(url, item);
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
