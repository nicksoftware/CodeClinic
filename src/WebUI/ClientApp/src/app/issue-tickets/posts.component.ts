import { Component, OnInit } from '@angular/core';
import { IssueTicketsClient, IIssueTicketDto, IIssueTicketDetailVm } from '../CodeClinic-api';

@Component({
  selector: 'posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  images = [
    '3765114/pexels-photo-3765114.jpeg',
    '3779448/pexels-photo-3779448.jpeg',
    '415829/pexels-photo-415829.jpeg']; 
  tickets: IIssueTicketDto[];
  selectedTicket: IIssueTicketDetailVm;
  constructor(private client :IssueTicketsClient) { }

  ngOnInit(): void {

    this.client.getAll().subscribe(result => {
      this.tickets = result.issues;
    });
  }
  displayDetails(id: number) {

  }
}


enum Status{
  NotAnswered = 0,
  InDiscussion = 1,
  Answered = 2
}