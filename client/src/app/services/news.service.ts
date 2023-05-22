import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { News } from '../models/news';

@Injectable({
  providedIn: 'root'
})
export class NewsService {
  apiPath = 'https://localhost:5000/'

  constructor(private http: HttpClient) { }

  getAllNews(){
    return this.http.get<News[]>(this.apiPath + 'news');
  }

  getHotNews(){
    return this.http.get<News[]>(this.apiPath + 'news/hot');
  }

  getNewsByType(type: string){
    return this.http.get<News[]>(this.apiPath + 'news/type=' + type);
  }

  deleteNewsById(id: number){
    return this.http.delete(this.apiPath + "news/delete/" + id);
  }

  create(news: {}){
    return this.http.post(this.apiPath + "news/create", news);
  }

  edit(news: {}){
    return this.http.put(this.apiPath + 'news/edit', news);
  }

  getApprovedOrEdittedNews(){
    return this.http.get<News[]>(this.apiPath + 'news/ApprovedOrEditted');
  }

  getInProcessNews() {
    return this.http.get<News[]>(this.apiPath + 'news/InProcess')
  }

  setToApprovedStatus(id: number) {
    return this.http.get(this.apiPath + `news/SetToApproved/${id}`);
  } 
}
