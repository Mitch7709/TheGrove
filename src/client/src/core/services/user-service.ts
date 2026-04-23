import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { LoginCreds, RegisterInstructorCreds, RegisterResponse, RegisterStudentCreds } from '../../types/DTOs/UserDTOs';
import { tap } from 'rxjs/internal/operators/tap';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private http = inject(HttpClient);

  private baseUrl = environment.apiUrl;

  login(creds: LoginCreds) {
    return this.http.post<RegisterResponse>(`${this.baseUrl}/login`, creds)
    .pipe(
      tap(response => {
        localStorage.setItem('token', response.token);
      })
    );
  }
  
  registerStudent(creds: RegisterStudentCreds) {
    return this.http.post<RegisterResponse>(`${this.baseUrl}/register/student`, creds)
    .pipe(
      tap(response => {
        localStorage.setItem('token', response.token);
      })
    );
  }

  registerInstructor(creds: RegisterInstructorCreds) {
    return this.http.post<RegisterResponse>(`${this.baseUrl}/register/instructor`, creds)
    .pipe(
      tap(response => {
        localStorage.setItem('token', response.token);
      })
    );
  }
}
