import { Injectable } from '@angular/core';
import { News } from './news.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class NewsService {
  constructor(private http: HttpClient) {}

  readonly baseURL = 'https://localhost:44377/api/news';
  formData: News = new News();
  list: News[] = [];

  postNews() {
    return this.http.post(this.baseURL, this.formData);
  }

  putNews() {
    return this.http.put(`${this.baseURL}/${this.formData.id}`, this.formData);
  }

  deleteNews(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshList(search = '') {
    this.http
      .get(`${this.baseURL}/all${!!search ? `?search=${search}` : ''}`)
      .toPromise()
      .then((res) => (this.list = res as News[]));
  }
}
