import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TravelService } from '../../services/travel.service';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router'

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements OnInit {

  author: any = {};
  authors: any[] = [];
  books: any[] = [];
  loading: boolean;
  allAuthors: boolean;
  token: string | undefined;
  constructor(private activatedRouter: ActivatedRoute, private travel: TravelService, private modalService: NgbModal, private router: Router) { 
    this.loading = true;
    this.allAuthors = false;
    this.token =  localStorage.getItem('token')?.toString();
    this.activatedRouter.params.subscribe(params => {
      this.getAuthor(params['id']);
      this.getBooksAuthor(params['id']);
    });
  }

  ngOnInit(): void {
  }
  getAuthor(id: string | undefined){
    this.loading = true;
    if(id !== undefined) {
      this.allAuthors = false;
      this.travel.getAuthor(id).subscribe((data: any) => {
        console.log(data);
        this.author = data.body.data;
        this.loading = false;
      });
    }
    else{
      this.allAuthors = true;
      this.travel.getAuthors().subscribe((data: any) => {
        console.log(data);
        this.authors = data.body.data;
        this.loading = false;
      });
    }
  }

  getBooksAuthor(id: string)
  {
    this.loading = true;
    this.travel.getBooksAuthorById(id).subscribe((data: any) => {
      this.books = data.body.data;
      this.loading = false;
  });
  }

  open(ModalCreateAuthor: any) {
		this.modalService.open(ModalCreateAuthor);
	}

  postAuthor(name: string, surname: string){
    this.loading = true;
    this.travel.postAuthor(name, surname).subscribe((data: any) => {
      alert(data.body.message);
      this.loading = false;
    });
    this.getAuthor(undefined);
  }

  getAuthors(item: any){
    let authors_id;
    authors_id = item.id;

    this.router.navigate(['/authors/', authors_id]);
  }

}
