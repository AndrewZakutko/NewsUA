import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewsType } from '../models/newsTypes';

@Injectable({
  providedIn: 'root'
})
export class NewsTypesService {
  apiPath = 'https://localhost:5000/'

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<NewsType[]>(this.apiPath + "NewsTypes");
  }
}
