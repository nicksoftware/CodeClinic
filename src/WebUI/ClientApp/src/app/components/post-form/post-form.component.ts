import { CreateIssueTicketCommand, IssueTicketsClient } from './../../CodeClinic-api';
import { Component, OnInit, Output } from '@angular/core';
import { IssueTicketDto, IIssueTicketDto, CategoriesClient, CategoryListVm, CategoryDto } from '../../CodeClinic-api';
import { NgForm } from '@angular/forms';
import { EventEmitter } from 'events';

@Component({
  selector: 'app-post-form',
  templateUrl: './post-form.component.html',
  styleUrls: ['./post-form.component.css']
})
export class PostFormComponent implements OnInit {

  IssueTicketDto : IIssueTicketDto;
  categories: CategoryDto[];
  @Output("submitted") submitted = new  EventEmitter();

  constructor(private client: IssueTicketsClient, private categoriesclient: CategoriesClient) { }

  publish(form : NgForm) {
    console.log(form);
    
    let post = new IssueTicketDto();
    post.title = form.value.title;
    post.body = form.value.body;
    post.categoryId = form.value.categoryId;

    this.client.create(post).subscribe(
      response => {
        console.log(response);

      }, (error: Response) => {
        if (error.status === 401) {
          alert("Failed to publish because your session has expired,quick remedy logout and login again")
        } else if (error.status === 500) {
          alert("falied to publish. due to internal server error");
        }
        alert("An unexpected error occured");
        console.log(error);
      }
    );
  }
  ngOnInit(): void {

    this.categoriesclient.getAll().subscribe(
      result => {
        this.categories = result.categories;
      }
    )
  }

}
