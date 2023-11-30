import { Vacancy } from "./vacancy";

export class Bedrijf {
  name: string;
  address: string;
  vacancies: Array<Vacancy>;

  constructor(name: string, address: string, vacancies: Array<Vacancy>) {
    this.name = name;
    this.address = address;
    this.vacancies = vacancies;
  }
}
