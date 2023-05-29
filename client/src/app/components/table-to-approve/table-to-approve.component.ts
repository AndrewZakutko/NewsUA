import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { News } from 'src/app/models/news';
import { NewsService } from 'src/app/services/news.service';

@Component({
  selector: 'app-table-to-approve',
  templateUrl: './table-to-approve.component.html',
  styleUrls: ['./table-to-approve.component.scss']
})
export class TableToApproveComponent implements OnInit {
  news: News[] = [];
  displayedColumns: string[] = ['title', 'authorName', 'subTitle', 'isHot', 'actions'];
  isLoading: boolean = false;

  constructor(private newsService: NewsService, private snackBar: MatSnackBar) {}
  
  ngOnInit(): void {
    this.isLoading = true;

    setTimeout(() => {
      this.getInProcessNews();
      this.isLoading = false;
    }, 1500)
  }

  approveNews(id: any){
    this.newsService.setToApprovedStatus(id).subscribe();

    this.isLoading = true;

    setTimeout(() => {
      this.getInProcessNews();
      this.openApproveSnackBar();
      this.isLoading = false;
    }, 1500)
  }

  getInProcessNews() {
    this.newsService.getInProcessNews().subscribe(
      (data: News[]) => {
        this.news = data;
      }
    );
  }

  deleteNewsById(id: any) {
    this.newsService.deleteNewsById(id).subscribe();

    this.isLoading = true;
    setTimeout(() => {
      this.getInProcessNews();
      this.openDeleteSnackBar();
      this.isLoading = false;
    }, 1500)
  }

  openApproveSnackBar() {
    this.snackBar.open('News has been approved', 'OK', {
      horizontalPosition: 'right',
      verticalPosition: 'bottom',
    });
  }

  openDeleteSnackBar() {
    this.snackBar.open('News has been deleted', 'OK', {
      horizontalPosition: 'right',
      verticalPosition: 'bottom',
    });
  }
}
