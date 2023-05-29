import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EditNewsModel, News } from 'src/app/models/news';
import { NewsService } from 'src/app/services/news.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NewsType } from 'src/app/models/newsTypes';
import { NewsTypesService } from 'src/app/services/news-types.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-edit-delete-news',
  templateUrl: './edit-delete-news.component.html',
  styleUrls: ['./edit-delete-news.component.scss']
})
export class EditDeleteNewsComponent implements OnInit {
  news: News[] = [];
  newsToEdit: EditNewsModel = {
    id: 0,
    title: '',
    subTitle: '',
    authorName: '',
    information: '',
    status: '',
    isHot: false,
    type: ''
  };
  displayedColumns: string[] = ['title', 'authorName', 'subTitle', 'isHot', 'actions'];
  isEditMode = false;
  isLoading = false;
  newsForm = new FormGroup({
    id: new FormControl(0),
    title: new FormControl('', [Validators.required]),
    subTitle: new FormControl('', [Validators.required]),
    authorName: new FormControl('', [Validators.required]),
    information: new FormControl('', [Validators.required]),
    isHot: new FormControl(false, [Validators.required]),
    type: new FormControl('', [Validators.required]),
  });
  newsTypes: NewsType[] = [];

  constructor(private newsService: NewsService, private newsTypesService: NewsTypesService, private snackBar: MatSnackBar) {
  }

  ngOnInit(): void {
    this.getNewsTypes();
    this.isLoading = true;

    setTimeout(() => {
      this.getAllNews();
      this.isLoading = false;
    }, 1500)
  }

  getAllNews(){
    this.newsService.getAllNews().subscribe(
      (data: News[]) => {
        this.news = data;
      }
    )
  }

  deleteNewsById(id: number){
    this.newsService.deleteNewsById(id).subscribe();

    this.isLoading = true;

    setTimeout(() => {
      this.getAllNews();
      this.isLoading = false;

      this.openDeletedNewsSnackBar();
    }, 1500)
  }

  openDeletedNewsSnackBar() {
    this.snackBar.open('News has been deleted', 'OK', {
      horizontalPosition: 'right',
      verticalPosition: 'bottom',
    });
  }

  goToEditMode(news: EditNewsModel){
    this.newsToEdit = news;
    
    this.isEditMode = true;
  }

  unsetEditMode() {
    this.isEditMode = false;
    
    this.isLoading = true;

    setTimeout(() => {
      this.getAllNews();
      this.isLoading = false;
    }, 1500)
  }

  onSubmit(){
    if(this.newsForm.valid) {
      this.newsService.edit(this.newsToEdit).subscribe();
      this.isEditMode = false;

      this.isLoading = true;

      setTimeout(() => {
        this.getAllNews();
        this.isLoading = false;
      }, 1500)

      this.openEditNewsSnackBar();
    }
  }

  openEditNewsSnackBar() {
    this.snackBar.open('News has been updated', 'OK', {
      horizontalPosition: 'right',
      verticalPosition: 'bottom',
    });
  }

  getNewsTypes() {
    this.newsTypesService.getAll().subscribe(
      (data: NewsType[]) => {
        this.newsTypes = data;
      }
    )
  }
}