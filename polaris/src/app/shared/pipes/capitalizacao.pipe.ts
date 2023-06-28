import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'capitalizacao'
})
export class CapitalizacaoPipe implements PipeTransform {

  transform(value: string | undefined): string {
    if (value) {
      // Convert the string to lowercase
      const lowerCaseValue = value.toLowerCase();
    
      // Split the string into words using space as delimiter
      const words = lowerCaseValue.split(' ');
      
      // Capitalize the first letter of each word
      const capitalizedWords = words.map(word => {
        return word.charAt(0).toUpperCase() + word.slice(1);
      });
      
      // Join the capitalized words back into a sentence
      const capitalizedValue = capitalizedWords.join(' ');

      return capitalizedValue;
    } else {
      return "";
    }
  }

}
