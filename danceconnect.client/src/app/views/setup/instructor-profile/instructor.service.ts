import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InstructorService {

  private apiUrl = 'https://localhost:7155/api';
  private endpoint = 'instructor';

  constructor(private http: HttpClient) { }

  getInstructors(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/${this.endpoint}`);
  }

  getInstructorById(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${this.endpoint}/${id}`);
  }

  addInstructor(item: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/${this.endpoint}`, item, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }), withCredentials: true
    });
  }

  updateInstructor(id: number, item: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${this.endpoint}/${id}`, item, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    });
  }

  deleteInstructor(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${this.endpoint}/${id}`);
  }
}
