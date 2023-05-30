import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TelegramSetting } from '../models/telegramSetting';

@Injectable({
  providedIn: 'root'
})
export class TelegramSettingsService {

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<TelegramSetting[]>('TelegramSettings');
  }

  editSetting(tgSetting: {}) {
    return this.http.put('TelegramSettings/Edit', tgSetting);
  }
}
