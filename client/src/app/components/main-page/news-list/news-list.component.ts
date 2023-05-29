import { Component, Input, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { News } from 'src/app/models/news';
import { NewsService } from 'src/app/services/news.service';

@Component({
  selector: 'app-news-list',
  templateUrl: './news-list.component.html',
  styleUrls: ['./news-list.component.scss']
})
export class NewsListComponent implements OnInit {
  @Input() newsCount: number = 0;
  news: News[] = [];
  pageNumber: number = 0;
  pageSize: number = 10;

  constructor(private newsService: NewsService) {}

  ngOnInit(): void {
    this.getPaginationNews(this.pageNumber, this.pageSize);
  }
    
  getPaginationNews(pageNumber: number, pageSize: number) {
    this.newsService.getPaginationListNews(pageNumber, pageSize).subscribe(
      (data: News[]) => {
        this.news = data;
      }
    )
  }

  getPaginationData(event: PageEvent) {
    this.getPaginationNews(event.pageIndex, event.pageSize);
  }
}
