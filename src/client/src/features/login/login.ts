import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { TextInput } from '../../shared/text-input/text-input';
import { UserService } from '../../core/services/user-service';

@Component({
  selector: 'app-login',
  imports: [TextInput, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrls: ['./login.css'],
})
export class Login {
  private userService = inject(UserService);
  private fb = inject(FormBuilder);
  protected credentialsForm: FormGroup;

  constructor() {
    this.credentialsForm = this.fb.group({
      email: [''],
      password: [''],
    });
  }

  login() {
    const formData = this.credentialsForm.value;

    const loginCreds = {
      email: formData.email,
      password: formData.password,
    };

    this.userService.login(loginCreds).subscribe({
      next: (response) => {
        console.log('Login successful:', response);
      },
      error: (error: HttpErrorResponse) => {
        // console.log(error.status);
        if (error.status === 400 && error.error?.errors) {
          // Validation errors from EndpointValidationFilter
          const validationErrors: Record<string, string[]> = error.error.errors;
          Object.entries(validationErrors).forEach(([field, messages]) => {
            console.error(`Validation error - ${field}:`, messages);
          });
        } else if (error.status === 401 && error.error?.error) {
          // Auth failure from Login handler
          console.error('Login failed:', error.error.error);
        } else {
          console.error('Login failed:', error);
        }
      },
    });
  }
}
