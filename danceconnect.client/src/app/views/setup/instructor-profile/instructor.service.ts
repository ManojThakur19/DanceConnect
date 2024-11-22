import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InstructorResponse } from './instructor';

@Injectable({
  providedIn: 'root'
})
export class InstructorService {

  private apiUrl = 'https://localhost:7155/api';
  private endpoint = 'instructor';

  constructor(private http: HttpClient) { }

  getInstructors(): Observable<InstructorResponse[]> {
    return this.http.get<InstructorResponse[]>(`${this.apiUrl}/${this.endpoint}`);
  }

  getInstructorById(id: number): Observable<InstructorResponse> {
    return this.http.get<InstructorResponse>(`${this.apiUrl}/${this.endpoint}/${id}`);
  }

  addInstructor(item: any): Observable<InstructorResponse> {
    return this.http.post<InstructorResponse>(`${this.apiUrl}/${this.endpoint}`, item);
  }

  updateInstructor(id: number, item: any): Observable<InstructorResponse> {
    return this.http.put<InstructorResponse>(`${this.apiUrl}/${this.endpoint}/${id}`, item);
  }

  deleteInstructor(id: number): Observable<InstructorResponse> {
    return this.http.delete<InstructorResponse>(`${this.apiUrl}/${this.endpoint}/${id}`);
  }
}
