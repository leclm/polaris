import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'dateGerente'
})
export class DateGerentePipe implements PipeTransform {

  transform(value: string): string {
    // Check if the value is a valid date string
    if (!value || !value.match(/^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}$/)) {
      return value;
    }

    const date = new Date(value);
    const day = date.getDate();
    const month = date.getMonth() + 1; // Months are zero-based
    const year = date.getFullYear();

    // Format the date string as "dd/mm/yyyy"
    const formattedDate = `${day.toString().padStart(2, '0')}/${month.toString().padStart(2, '0')}/${year}`;

    return formattedDate;
  }

}
