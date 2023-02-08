import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { LoadingComponent } from './components/shared/loading/loading.component';
import { HomeComponent } from './components/home/home.component';
import { BooksComponent } from './components/books/books.component';
import { AuthorsComponent } from './components/authors/authors.component';
import { EditorialsComponent } from './components/editorials/editorials.component';

import { ROUTES } from './app.routes';

import { TravelService } from './services/travel.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { LibraryComponent } from './components/library/library.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoadingComponent,
    HomeComponent,
    BooksComponent,
    AuthorsComponent,
    EditorialsComponent,
    LibraryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot(ROUTES, {useHash: true} ),
    NgbModule
  ],
  providers: [
    TravelService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
