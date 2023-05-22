import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EditNewsModel, News } from 'src/app/models/news';
import { NewsService } from 'src/app/services/news.service';
import { DeleteNewsDialogComponent } from './delete-news-dialog/delete-news-dialog.component';
import { FormControl, FormGroup } from '@angular/forms';
import { EditNewsDialogComponent } from './edit-news-dialog/edit-news-dialog.component';

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
    title: new FormControl(''),
    subTitle: new FormControl(''),
    authorName: new FormControl(''),
    information: new FormControl(''),
    status: new FormControl(''),
    isHot: new FormControl(false),
    type: new FormControl('')
  });

  constructor(private newsService: NewsService, public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.isLoading = true;

    setTimeout(() => {
      this.getApproveOrEdittedNews();
      this.isLoading = false;
    }, 1500)
  }

  getApproveOrEdittedNews(){
    this.newsService.getApprovedOrEdittedNews().subscribe(
      (data: News[]) => {
        this.news = data;
      }
    )
  }

  deleteNewsById(id: number){
    this.newsService.deleteNewsById(id).subscribe();

    this.isLoading = true;

    setTimeout(() => {
      this.getApproveOrEdittedNews();
      this.isLoading = false;

      this.openDeleteDialog();
    }, 1500)
  }

  openDeleteDialog() {
    const dialogRef = this.dialog.open(DeleteNewsDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  goToEditMode(news: EditNewsModel){
    this.newsToEdit = news;
    
    this.isEditMode = true;
  }

  unsetEditMode() {
    this.isEditMode = false;
  }

  onSubmit(){
    this.newsService.edit(this.newsToEdit).subscribe();
    this.isEditMode = false;
    this.openEditDialog();
  }

  openEditDialog() {
    const dialogRef = this.dialog.open(EditNewsDialogComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}