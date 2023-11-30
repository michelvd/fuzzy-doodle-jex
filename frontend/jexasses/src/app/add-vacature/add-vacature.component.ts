import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DataService } from '../services/data-service';

@Component({
  selector: 'app-add-vacature',
  templateUrl: './add-vacature.component.html',
  styleUrls: ['./add-vacature.component.sass']
})
export class AddVacatureComponent {
  companyid: string | null = null;
  constructor(private route: ActivatedRoute, private router: Router, private formbuilder: FormBuilder, private dataService: DataService) {
    this.companyid = this.route.snapshot.paramMap.get('companyid') || null;
    if (this.companyid == null) {
      this.router.navigateByUrl('/bedrijven')
    }

  }

  vacancyForm = this.formbuilder.group({
    title: ['', Validators.required],
    description: [''],

  });

  onSubmit() {
    // TODO: Use EventEmitter with form value
    if  (this.vacancyForm.valid) {
      this.dataService.addVacancy(this.companyid, this.vacancyForm.value.title, this.vacancyForm.value.description).subscribe((data: any) => {
        this.router.navigateByUrl('/bedrijven');
      });
    }
  }
}
