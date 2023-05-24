import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TelegramSetting } from '../models/telegramSetting';

@Injectable({
  providedIn: 'root'
})
export class TelegramSettingsService {
  apiPath = 'https://localhost:5000/'

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<TelegramSetting[]>(this.apiPath + 'TelegramSettings');
  }

  editSetting(tgSetting: {}) {
    return this.http.put(this.apiPath + 'TelegramSettings/Edit', tgSetting);
  }
}
