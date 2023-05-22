import { Component, OnInit } from '@angular/core';
import { News } from 'src/app/models/news';
import { NewsService } from 'src/app/services/news.service';

@Component({
  selector: 'app-news-hot-list',
  templateUrl: './news-hot-list.component.html',
  styleUrls: ['./news-hot-list.component.scss']
})
export class NewsHotListComponent implements OnInit {
  news: News[] | undefined = undefined;

  constructor(private newsService: NewsService) {}

  ngOnInit(): void {
    this.newsService.getHotNews().subscribe(
      (data : News[]) => {
        this.news = data;
      }
    );
  }
}
