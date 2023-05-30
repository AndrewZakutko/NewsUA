import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { News } from '../models/news';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  constructor(private http: HttpClient) { }

  getHotNews(){
    return this.http.get<News[]>('news/hot');
  }

  deleteNewsById(id: number){
    return this.http.delete("news/delete/" + id);
  }

  create(news: {}){
    return this.http.post("news/create", news);
  }

  edit(news: {}){
    return this.http.put('news/edit', news);
  }

  getAllNews(){
    return this.http.get<News[]>('news/ApprovedOrEditted');
  }

  getInProcessNews() {
    return this.http.get<News[]>('news/InProcess')
  }

  setToApprovedStatus(id: number) {
    return this.http.get(`news/SetToApproved/${id}`);
  } 

  getPaginationListNews(pageNumber: number, pageSize: number) {
    return this.http.get<News[]>(`news/pageNumber=${pageNumber}&pageSize=${pageSize}`)
  }
}
