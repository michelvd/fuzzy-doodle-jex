import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Bedrijf } from '../models/bedrijf';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {


  constructor(private readonly http: HttpClient) { }

  private apiUrlRoot = 'http://localhost:5062/companies';

  public getBedrijven(): Observable<Array<Bedrijf>> {
      const apiUrl = `${this.apiUrlRoot}?onlyWithVacancies=true`;
      return this.http.get<Array<Bedrijf>>(`${apiUrl}`);
  }

  public addVacancy(companyid: string | null, title: string | null | undefined, description: string | null | undefined) {
    const apiUrl = `${this.apiUrlRoot}/${companyid}/vacancies`;

      const headers = { 'Content-type': 'application/json; charset=UTF-8'};
      const body = {
        title: title,
        description: description
      };
        return this.http.post<any>(apiUrl, body, { headers });
    };


}
