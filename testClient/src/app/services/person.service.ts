import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Person } from '../Models/person';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ChildService } from './child.service';
import { Child } from '../Models/child';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  currentUser = new BehaviorSubject<Person>(new Person(0, null, null, null, null, 0, 0));

  children = new BehaviorSubject<Child[]>([]);

  baseRouteUrl = `${environment.baseUrl}/Person`;

  constructor(public http: HttpClient, public childSer: ChildService) { }

  getAllPeople() {
    ~(`${this.baseRouteUrl}`);
    return this.http.get<Person[]>(this.baseRouteUrl);
  }

  public async addPerson(p: Person) {
    ~(`${this.baseRouteUrl}`);
    return this.http.post<Person>(this.baseRouteUrl, p);
  }

}
