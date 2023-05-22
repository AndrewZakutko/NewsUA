import { Component, OnInit } from '@angular/core';
import { News } from 'src/app/models/news';
import { NewsService } from 'src/app/services/news.service';

@Component({
  selector: 'app-main-page-content',
  templateUrl: './main-page-content.component.html',
  styleUrls: ['./main-page-content.component.scss']
})
export class MainPageContentComponent implements OnInit {
  news: News[] = [];
  loading: boolean = false;

  constructor(private newsService: NewsService) {}

  ngOnInit(): void {
    this.loading = true;

    setTimeout(() => {
      this.getApproveOrEdittedNews();
      this.loading = false;
    }, 1500);
  }
  
  getNewsFromMenu(type: string | null) {
    this.loading = true;

    setTimeout(() => {
      if(type == null) {
        this.getApproveOrEdittedNews();
        this.loading = false;
      }
      else
      {
        this.getNewsByType(type);
        this.loading = false;
      }
    }, 1500);
  }

  getApproveOrEdittedNews(){
    this.newsService.getApprovedOrEdittedNews().subscribe(
      (data: News[]) => {
        this.news = data;
      }
    )
  }

  getNewsByType(type: string){
    this.newsService.getNewsByType(type).subscribe(
      (data: News[]) => {
        this.news = data;
      }
    )
  }
}
