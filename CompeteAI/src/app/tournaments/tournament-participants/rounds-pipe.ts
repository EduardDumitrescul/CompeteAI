import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'rounds'
})
export class RoundsPipe implements PipeTransform {
  transform(value: number): string {
    return value.toString() + " rounds";
  }
}
