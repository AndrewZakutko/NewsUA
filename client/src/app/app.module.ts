import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatCardModule} from '@angular/material/card';
import { NavComponent } from './components/nav/nav.component';
import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatDividerModule} from '@angular/material/divider';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import { RouterModule } from '@angular/router';
import { NewsHotListComponent } from './components/main-page/news-hot-list/news-hot-list.component';
import { HttpClientModule } from '@angular/common/http';
import { NewsListComponent } from './components/main-page/news-list/news-list.component';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatMenuModule} from '@angular/material/menu';
import { MainPageContentComponent } from './components/main-page/main-page-content/main-page-content.component';
import { EditDeleteNewsComponent } from './components/edit-delete-news/edit-delete-news.component';
import {MatTableModule} from '@angular/material/table';
import {MatDialogModule} from '@angular/material/dialog';
import { CreateNewsComponent } from './components/create-news/create-news.component';
import { ReactiveFormsModule } from '@angular/forms';
import {MatSelectModule} from '@angular/material/select';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { CreateNewsDialogComponent } from './components/create-news/create-news-dialog/create-news-dialog.component';
import { DeleteNewsDialogComponent } from './components/edit-delete-news/delete-news-dialog/delete-news-dialog.component';
import { NewsMenuComponent } from './components/main-page/news-menu/news-menu.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { EditNewsDialogComponent } from './components/edit-delete-news/edit-news-dialog/edit-news-dialog.component';
import { TableToApproveComponent } from './components/table-to-approve/table-to-approve.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    NewsHotListComponent,
    NewsListComponent,
    MainPageContentComponent,
    EditDeleteNewsComponent,
    CreateNewsComponent,
    CreateNewsDialogComponent,
    DeleteNewsDialogComponent,
    NewsMenuComponent,
    EditNewsDialogComponent,
    TableToApproveComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatSlideToggleModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatDividerModule,
    MatProgressBarModule,
    RouterModule,
    HttpClientModule,
    MatGridListModule,
    MatExpansionModule,
    MatMenuModule,
    MatTableModule,
    MatDialogModule,
    ReactiveFormsModule, 
    MatSelectModule,
    MatCheckboxModule,
    MatProgressSpinnerModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
