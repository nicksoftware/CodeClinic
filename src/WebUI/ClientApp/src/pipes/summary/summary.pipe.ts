import { ProgressStatusDto } from './../../app/CodeClinic-api';
import { Pipe, PipeTransform } from '@angular/core';
import { ProgressStatus } from '../../app/CodeClinic-api';

@Pipe({
  name: 'summary'
})
export class SummaryPipe implements PipeTransform {

  transform(value: string, length?: number): string{
  
    
    return value.substr(0, length != null ? length : 50)+ "...";
  }

  

}
