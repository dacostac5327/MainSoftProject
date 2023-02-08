import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';

import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TravelService {
    private headers = new HttpHeaders();
    constructor(private http: HttpClient) { 
      
  }

  getQuery(query: string) {
    const url = `https://localhost:44392/api/${ query }`;
    this.headers = new HttpHeaders();
    this.headers = this.headers.set("Content-Type", "application/json");
    this.headers = this.headers.set("Accept", "application/json, application/hal+json;charset=UTF8");
    let httpHeaders = this.headers;
    httpHeaders = httpHeaders.append('Authorization', `Bearer ${ localStorage.getItem('token') }`);
          let options: {} = {
    headers: httpHeaders,
    observe: 'response'
  };
    return this.http.get(url, options);
  }

  postQuery(query: string, body: any){
    const url = `https://localhost:44392/api/${ query }`;
    this.headers = new HttpHeaders();
    this.headers = this.headers.set("Content-Type", "application/json");
    this.headers = this.headers.set("Accept", "application/json, application/hal+json;charset=UTF8");
    let httpHeaders = this.headers;
    httpHeaders = httpHeaders.append('Authorization', `Bearer ${ localStorage.getItem('token') }`);
          let options: {} = {
    headers: httpHeaders,
    observe: 'response'
  };
    return this.http.post(url, body, options);
  }

  postQueryLogin(query: string, body: any){
    const url = `https://localhost:44392/api/${ query }`;

    let httpHeaders = this.headers;
    let options: {} = {
      headers: httpHeaders,
      observe: 'response'
    };
        console.log('optionsPostLogin ' + JSON.stringify(options));
        return this.http.post(url, body, options);
  }

  getAuthorsBooks() {
    return this.getQuery('AuthorsBooks/Authors_has_Books');
  }
  
  getAuthor(id: string){
    return this.getQuery(`Authors/GetAuthorById/?id=${id}`);
  }

  getAuthors() {
    return this.getQuery('Authors');
  }

  getBooksAuthorById(id: string){
    return this.getQuery(`AuthorsBooks/Authors_has_BooksByAuthorId/?id=${id}`);
  }

  getBooksEditorialById(id: string){
    return this.getQuery(`AuthorsBooks/Authors_has_BooksByEditorialId/?id=${id}`);
  }
  
  postAuthor(name: string, surname: string){
    let author = {
      name: name,
      surnames: surname
    }
    return this.postQuery('Authors', author);
  }

  getEditorial(id: string){
    return this.getQuery(`Editorials/GetEditorialByIdAsync?id=${id}`);
  }

  getEditorials() {
    return this.getQuery('Editorials');
  }
  getBook(id: string){
    return this.getQuery(`Books/BookById/?id=${id}`);
  }

  getBooks() {
    return this.getQuery('Books');
  }
  postEditorial(name: string, campus: string){
    let editorial = {
      name: name,
      campus: campus
    }
    return this.postQuery('Editorials', editorial);
  }

  postBook(isbn: number, editorials_id: number, title: string, synopsis: string, n_pages: string){
    let book = {
      isbn: isbn,
      editorials_id: editorials_id,
      title: title,
      synopsis: synopsis,
      n_pages: n_pages
    }
    return this.postQuery('Books', book);
  }
  
  postAuthorBook(authorId: number, books_ISBN: number){
    let authorBook = {
      authors_id: authorId,
      books_ISBN: books_ISBN
    }
    return this.postQuery('AuthorsBooks', authorBook);
  }
  
  postAuthenticate() {
      let user = {
      name: 'PruebaU2',
      password: '1234Qwe'
    }
    return this.postQueryLogin('Users/authenticate', user);
  }
}
