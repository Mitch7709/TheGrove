import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import {
  AuthResponse,
  LoginCreds,
  RegisterInstructorCreds,
  RegisterStudentCreds,
} from '../../types/DTOs/UserDTOs';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private readonly ROLE_CLAIM = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';

  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;

  login(creds: LoginCreds) {
    return this.http.post<AuthResponse>(`${this.baseUrl}/login`, creds).pipe(
      tap((response) => {
        localStorage.setItem('token', response.token);
      }),
    );
  }

  registerStudent(creds: RegisterStudentCreds) {

    return this.http.post<AuthResponse>(`${this.baseUrl}/register/student`, creds).pipe(
      tap((response) => {
        localStorage.setItem('token', response.token);
      }),
    );
  }

  registerInstructor(creds: RegisterInstructorCreds) {
    return this.http.post<AuthResponse>(`${this.baseUrl}/register/instructor`, creds).pipe(
      tap((response) => {
        localStorage.setItem('token', response.token);
      }),
    );
  }

  getRole(): 'Student' | 'Instructor' | null {
    const token = localStorage.getItem('token');
    if (!token) return null;
    try {
      const payload = JSON.parse(atob(token.split('.')[1]));
      return payload[this.ROLE_CLAIM] as 'Student' | 'Instructor';
    } catch {
        return null;
    }
  }
}
