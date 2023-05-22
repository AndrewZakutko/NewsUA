import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-news-menu',
  templateUrl: './news-menu.component.html',
  styleUrls: ['./news-menu.component.scss']
})
export class NewsMenuComponent implements OnInit {
  @Output() clickTypedNews = new EventEmitter();

  getNewsByType(type: string | null){
    this.clickTypedNews.emit(type);
  }

  constructor() {}

  ngOnInit(): void {
    
  }
}
