import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { DataService } from '../services/data-service';
import { Bedrijf } from '../models/bedrijf';

@Component({
  selector: 'app-bedrijven',
  templateUrl: './bedrijven.component.html',
  styleUrls: ['./bedrijven.component.sass']
})
export class BedrijvenComponent implements OnInit {
  bedrijven$: Observable<Bedrijf[] | null> = of(null);

  constructor(private dataService: DataService) {} // Add the constructor to inject the DataService

  ngOnInit(): void {
    this.bedrijven$ = this.dataService.getBedrijven();
  }

}
