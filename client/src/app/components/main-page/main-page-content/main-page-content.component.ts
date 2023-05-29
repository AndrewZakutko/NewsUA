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
  hotNews: News[] = [];
  loading: boolean = false;

  constructor(private newsService: NewsService) {}

  ngOnInit(): void {
    this.loading = true;

    setTimeout(() => {
      this.getAllNews();
      this.getHotNews();
      this.loading = false;
    }, 1500);
  }

  getAllNews(){
    this.newsService.getAllNews().subscribe(
      (data: News[]) => {
        this.news = data;
      }
    )
  }

  getHotNews() {
    this.newsService.getHotNews().subscribe(
      (data: News[]) => {
        this.hotNews = data;
      }
    )
  }
}
