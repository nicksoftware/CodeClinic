import { Template } from '@angular/compiler/src/render3/r3_ast';
import { Component, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { IIssueTicketDto, IssueTicketDto, IssueTicketListVm, IssueTicketsClient } from '../CodeClinic-api';

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

  onIssueTicketClick(modalTemplate: TemplateRef<any>, issueTicket :IssueTicketDto) {
    this.modalRef = this.modalService
      .show(modalTemplate,
        Object.assign({ issueTicket},{ class: 'gray modal-lg' }));
  }
}

