import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Gender } from '../Models/gender';

@Injectable({
  providedIn: 'root'
})
export class GenderService {

  genders: Gender[];
  currentGender: Gender[];

  baseRouteUrl = `${environment.baseUrl}/Gender`;

  constructor(public http: HttpClient) {
    this.getAll().subscribe({
      next: (suc) => { this.genders = suc; },
      error: (er) => { console.log(er); }
    });
  }

  getAll() {
    return this.http.get<Gender[]>(this.baseRouteUrl);
  }
}

