import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TravelService } from 'src/app/services/travel.service';
@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.css']
})
export class LibraryComponent implements OnInit {
  book: any = {};
  books: any[] = [];
  editorials: any[] = [];
  authors: any[] = [];
  loading: boolean;
  allBooks: boolean;
  bookId: number;
  token: string = "";
  constructor(private activatedRouter: ActivatedRoute, private travel: TravelService, private modalService: NgbModal, private router: Router) {
    this.loading = true;
    this.allBooks = false;
    this.bookId = 0;
    this.getEditorials();
    this.getAuthors();
    this.activatedRouter.params.subscribe(params => {
      this.getBook(params['id']);
    });
    if (this.token == "") {
      this.login();
    }
  }

  ngOnInit(): void {
  }
  
  open(ModalCreateBooks: any) {
		this.modalService.open(ModalCreateBooks);
	}

  openId(ModalBooksAuthors: any, id: string) {
    this.bookId = parseInt(id);
		this.modalService.open(ModalBooksAuthors);
	}

  getBook(id: string | undefined){
    this.loading = true;
    if(id !== undefined) {
      this.allBooks = false;
      this.travel.getBook(id).subscribe((data: any) => {
        console.log(data);
        this.book = data.data;
        this.bookId = parseInt(id);
        this.loading = false;
      });
    }
    else{
      this.allBooks = true;
      this.travel.getBooks().subscribe((data: any) => {
        console.log(data);
        this.books = data.data;
        this.loading = false;
      });
    }
  }

  getEditorials() {
    this.loading = true;
    this.travel.getEditorials().subscribe((data: any) => {
      this.editorials = data.data;
      this.loading = false;
    });
  }

  postBook(isbn: string, editorials_id: string, title: string, synopsis: string, n_pages: string){
    this.loading = true;
    this.travel.postBook(parseInt(isbn),parseInt(editorials_id), title, synopsis, n_pages).subscribe((data: any) => {
      alert(data.message);
      this.loading = false;
    });
    this.getBook(undefined);
  }
  
  getAuthors() {
    this.loading = true;
    this.travel.getAuthors().subscribe((data: any) => {
      this.authors = data.data;
      this.loading = false;
    });
  }

  postAuthorBook(authorId: string){
    this.loading = true;
    this.travel.postAuthorBook(parseInt(authorId), this.bookId).subscribe((data: any) => {
      alert(data.message);
      this.loading = false;
    });
    this.getBook(undefined);
  }

  login() {
    this.travel.postAuthenticate().subscribe((data: any) => {
      this.token = data.body.token;
        console.log('tokenAAAAAlogin ' + this.token);
  });
  }
}
