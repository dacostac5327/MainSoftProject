import { Component, OnInit } from '@angular/core';
import { TravelService } from 'src/app/services/travel.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  loading: boolean;
  error: boolean;
  message: string;
  authorsBooks: any[] = [];
  token: string = "";

  constructor(private travel: TravelService) {
    this.loading = true;
    this.error = false;
    this.message = "";
    if (this.token == "") {
      this.login();
    }
   }

  ngOnInit(): void {
  }

  login() {
    this.travel.postAuthenticate().subscribe((data: any) => {
      this.token = data.body.token;
      localStorage.setItem('token', this.token);
        this.travel.getAuthorsBooks()
        .subscribe( (data: any) => {
          this.authorsBooks = data.body.data;
          this.loading = false;
        }, (errorService) => {
          this.loading = false;
          this.error = true;
          this.message = errorService.message;
        });
  });
  }
}
