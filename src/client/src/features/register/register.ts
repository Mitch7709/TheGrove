import { Component, inject } from '@angular/core';
import { UserService } from '../../core/services/user-service';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { TextInput } from '../../shared/text-input/text-input';

@Component({
  selector: 'app-register',
  imports: [TextInput, ReactiveFormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
  private userService = inject(UserService);
  private fb = inject(FormBuilder);
  protected credentialsForm: FormGroup;
  role: 'Student' | 'Instructor' = 'Student';

  constructor() {
    this.credentialsForm = this.fb.group({
      email: [''],
      password: [''],
      firstName: [''],
      lastName: [''],
      phone: [''],
      dob: [''],
      bio: [''],
    });
  }

  onRoleChange(event: Event) {
    const target = event.target as HTMLInputElement;
    this.role = target.value as 'Student' | 'Instructor';
    // console.log('Selected role:', this.role);
  }

  register() {
    const formData = this.credentialsForm.value;
    // console.log('Form Data:', formData);

    if (this.role === 'Student') {
      const studentCreds = {
        email: formData.email,
        password: formData.password,
        firstName: formData.firstName,
        lastName: formData.lastName,
        phoneNumber: formData.phone,
        dateOfBirth: formData.dob,
      };

      this.userService.registerStudent(studentCreds).subscribe({
        next: (response) => {
          console.log('Student registration successful:', response);
        },
        error: (error) => {
          console.error('Student registration failed:', error);
        },
      });
    } else if (this.role === 'Instructor') {
      const instructorCreds = {
        email: formData.email,
        password: formData.password,
        firstName: formData.firstName,
        lastName: formData.lastName,
        phoneNumber: formData.phone,
        bio: formData.bio,
      };

      this.userService.registerInstructor(instructorCreds).subscribe({
        next: (response) => {
          console.log('Instructor registration successful:', response);
        },
        error: (error) => {
          console.error('Instructor registration failed:', error);
        },
      });
    }
  }
}
