import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router'

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  @Input() items: any[] = [];

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  getAuthors(item: any){
    let authors_id;
    console.log("getAuthors");
    console.log(item);
    authors_id = item.authors_id;

    this.router.navigate(['/authors/', authors_id])
  }
}
