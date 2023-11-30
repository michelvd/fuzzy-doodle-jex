import { Vacancy } from "./vacancy";

export class Bedrijf {
  name: string;
  id: number;
  address: string;
  vacancies: Array<Vacancy>;

  constructor(id: number, name: string, address: string, vacancies: Array<Vacancy>) {
    this.id = id;
    this.name = name;
    this.address = address;
    this.vacancies = vacancies;
  }
}
