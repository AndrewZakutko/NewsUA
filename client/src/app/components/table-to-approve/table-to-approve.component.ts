import { Component, OnInit } from '@angular/core';
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

  constructor(private newsService: NewsService) {}
  
  ngOnInit(): void {
    this.isLoading = true;

    setTimeout(() => {
      this.getInProcessNews();
      this.isLoading = false;
    }, 1500)
  }

  approveNews(id: any){
    this.newsService.setToApprovedStatus(id).subscribe();
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
      this.isLoading = false;
    }, 1500)
  }
}
