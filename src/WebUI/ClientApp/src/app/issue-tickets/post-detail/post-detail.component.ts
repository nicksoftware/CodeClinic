import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IssueTicketsClient, IssueTicketDetailVm } from '../../CodeClinic-api';

@Component({
  selector: 'post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.css']
})
export class PostDetailComponent implements OnInit {

  id: number;
  issueTicket: IssueTicketDetailVm;
  constructor(private route: ActivatedRoute, private client : IssueTicketsClient) {
    
   }

  ngOnInit(): void {
    
    this.route.paramMap.subscribe(params => {
      this.id = +params.get('issueTicketId');
    }),
      this.client.getIssueTicketById(this.id).subscribe(
        result => {
          this.issueTicket = result;
        });
        this.scrollToTop();
  }


  scrollToTop() {
    var currentScroll = document.documentElement.scrollTop || document.body.scrollTop;
    if (currentScroll > 0) {
       
        window.scrollTo(0, currentScroll - (currentScroll / 8));
    }
  }
}
