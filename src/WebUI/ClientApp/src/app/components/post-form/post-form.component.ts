import { IssueTicketsClient } from './../../CodeClinic-api';
import { Component, OnInit } from '@angular/core';
import { IssueTicketDto, IIssueTicketDto, CategoriesClient, CategoryListVm, CategoryDto } from '../../CodeClinic-api';

@Component({
  selector: 'app-post-form',
  templateUrl: './post-form.component.html',
  styleUrls: ['./post-form.component.css']
})
export class PostFormComponent implements OnInit {

  IssueTicketDto : IIssueTicketDto;
  categories: CategoryDto[];
  constructor(private client: IssueTicketsClient, private categoriesclient : CategoriesClient) { }

  ngOnInit(): void {

    this.categoriesclient.getAll().subscribe(
      result => {
        this.categories = result.categories;
      }
    )
  }

}
