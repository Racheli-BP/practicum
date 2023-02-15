import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Child } from '../Models/child';
import { PersonService } from './person.service';

@Injectable({
  providedIn: 'root'
})
export class ChildService {

  baseRouteUrl = `${environment.baseUrl}/Child`;

  constructor(public http: HttpClient) { }

  public getAllChildren() {
    return this.http.get<Child[]>(this.baseRouteUrl);
  }

  public addChild(c: Child) {
    ~(`${this.baseRouteUrl}`);
    return this.http.post<Child>(this.baseRouteUrl, c).subscribe({
      next: (suc) => { console.log("succ child"); },
      error: (er) => { console.log(er.error); }
    });
  }

  public addChildren(arr: Child[], parentId: number) {
    arr.forEach(c => { c.parentId = parentId; this.addChild(c); });
  }
}
