import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService, ApiResult } from './base.service';
import { Observable } from 'rxjs';

import { User } from './user';

@Injectable({
  providedIn: 'root',
})
export class UserService
  extends BaseService<User> {
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
  ): Observable<ApiResult<User>> {
    var url = this.getUrl("api/Users");
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

    return this.http.get<ApiResult<User>>(url, { params });
  }

  get(id: number): Observable<User> {
    var url = this.getUrl("api/Users/" + id);
    return this.http.get<User>(url);
  }

  put(item: User): Observable<User> {
    var url = this.getUrl("api/Users/" + item.id);
    return this.http.put<User>(url, item);
  }

  post(item: User): Observable<User> {
    var url = this.getUrl("api/Users");
    return this.http.post<User>(url, item);
  }

  currentUser(): Observable<User> {
    var url = this.getUrl("api/Users/CurrentUser");
    return this.http.get<User>(url);
  }

  currentUserIsAdmin(): Observable<boolean> {
    var url = this.getUrl("api/Users/CurrentUserIsAdmin");
    return this.http.get<boolean>(url);
  }

}
