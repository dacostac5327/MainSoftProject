import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AuthorsComponent } from './components/authors/authors.component';
import { EditorialsComponent } from './components/editorials/editorials.component';
import { BooksComponent } from './components/books/books.component';
import { LibraryComponent } from './components/library/library.component';

export const ROUTES: Routes = [
    {path: 'home', component: HomeComponent },
    {path: 'author', component: AuthorsComponent},
    {path: 'authors/:id', component: AuthorsComponent},
    {path: 'authors', component: AuthorsComponent},
    {path: 'editorial', component: EditorialsComponent},
    {path: 'editorial/:id', component: EditorialsComponent},
    {path: 'library', component: LibraryComponent},
    {path: 'book', component: BooksComponent},
    {path: '', pathMatch: 'full', redirectTo: 'home'},
    {path: '**', pathMatch: 'full', redirectTo: 'home'}
];