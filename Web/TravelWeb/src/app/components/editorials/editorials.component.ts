import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TravelService } from 'src/app/services/travel.service';

@Component({
  selector: 'app-editorials',
  templateUrl: './editorials.component.html',
  styleUrls: ['./editorials.component.css']
})
export class EditorialsComponent implements OnInit {

  editorial: any = {};
  editorials: any[] = [];
  books: any[] = [];
  loading: boolean;
  allEditorials: boolean;
  token: string = "";
  constructor(private activatedRouter: ActivatedRoute, private travel: TravelService, private modalService: NgbModal, private router: Router) {
    this.loading = true;
    this.allEditorials = false;
    if (this.token == "") {
      this.login();
    }
    this.activatedRouter.params.subscribe(params => {
      this.getEditorial(params['id']);
      this.getBooksEditorial(params['id']);
    });
  }

  ngOnInit(): void {
  }
  getEditorial(id: string | undefined){
    this.loading = true;
    if(id !== undefined) {
      this.allEditorials = false;
      this.travel.getEditorial(id).subscribe((data: any) => {
        console.log(data);
        this.editorial = data.data;
        this.loading = false;
      });
    }
    else{
      this.allEditorials = true;
      this.travel.getEditorials().subscribe((data: any) => {
        console.log(data);
        this.editorials = data.data;
        this.loading = false;
      });
    }
  }

  open(ModalCreateEditorials: any) {
		this.modalService.open(ModalCreateEditorials);
	}

  postEditorial(name: string, campus: string){
    this.loading = true;
    this.travel.postEditorial(name, campus).subscribe((data: any) => {
      alert(data.message);
      this.loading = false;
    });
    this.getEditorial(undefined);
  }
  getEditorialById(item: any){
    let authors_id;
    authors_id = item.id;

    this.router.navigate(['/editorial/', authors_id]);
  }

  getBooksEditorial(id: string)
  {
    this.loading = true;
    this.travel.getBooksEditorialById(id).subscribe((data: any) => {
      this.books = data.data;
      this.loading = false;
  });
  }

  login() {
    this.travel.postAuthenticate().subscribe((data: any) => {
      this.token = data.body.token;
        console.log('tokenAAAAAlogin ' + this.token);
  });
  }
}
