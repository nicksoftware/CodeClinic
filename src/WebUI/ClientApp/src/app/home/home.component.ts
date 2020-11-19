
import { Component, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { IIssueTicketDto, IssueTicketDto, IssueTicketListVm, IssueTicketsClient, ProgressStatus } from '../CodeClinic-api';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  modalRef : BsModalRef

  issueTicketsListvm: IssueTicketListVm;
  issuesTicketList: IIssueTicketDto[];

  constructor(private client: IssueTicketsClient, private modalService :BsModalService ) {
    
    this.client.getAll().subscribe(result => {
      this.issuesTicketList = result.issues;
     
    }, error => console.error(error));

  }


}

