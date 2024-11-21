import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = 'https://localhost:7155/api';
  private endpoint = 'user';

  constructor(private http: HttpClient) { }

  getItems(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/${this.endpoint}`);
  }

  getItemById(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${this.endpoint}/${id}`);
  }

  uploadUser(item: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/${this.endpoint}`, item);
  }

  updateItem(id: number, item: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${this.endpoint}/${id}`, item, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    });
  }

  deleteItem(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${this.endpoint}/${id}`);
  }
}
