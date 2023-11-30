import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { BedrijvenComponent } from './bedrijven/bedrijven.component';
import { AddVacatureComponent } from './add-vacature/add-vacature.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'bedrijven', component: BedrijvenComponent },
  { path: 'add-vacature/:companyid', component: AddVacatureComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
