import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BedrijvenComponent } from './bedrijven/bedrijven.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'bedrijven', component: BedrijvenComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
