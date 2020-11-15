import { Component } from '@angular/core';
import { IssueListVm, IssuesClient } from '../CodeClinic-api';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  issuesListvm: IssueListVm;

  constructor(private client: IssuesClient ) {
    this.client.getAll().subscribe(result => {
      this.issuesListvm = result;
    }, error => console.error(error));
  }
}

