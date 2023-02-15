import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HealthFund } from '../Models/health-fund';

@Injectable({
  providedIn: 'root'
})
export class HealthFundService {

  healthFunds: HealthFund[];

  baseRouteUrl = `${environment.baseUrl}/HealthFund`;

  constructor(public http: HttpClient) {
    this.getAll().subscribe({
      next: (suc) => { this.healthFunds = suc; },
      error: (er) => { console.log(er); }
    });
  }

  getAll() {
    return this.http.get<HealthFund[]>(this.baseRouteUrl);
  }
}

