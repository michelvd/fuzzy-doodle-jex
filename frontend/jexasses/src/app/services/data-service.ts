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
      const apiUrl = `${this.apiUrlRoot}/`;
      return this.http.get<Array<Bedrijf>>(`${apiUrl}`);
  }


}
