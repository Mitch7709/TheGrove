export type LoginCreds = {
  email: string;
  password: string;
};

export type RegisterStudentCreds = {
    firstName: string;
    lastName: string;
    email: string;
    dateOfBirth: string;
    phoneNumber: string;
    password: string;
};

export type RegisterInstructorCreds = {
    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: string;
    password: string;
    bio: string;
};

export type RegisterResponse = {
    userId: string;
    token: string;
};

export type LoginResponse = {
    userId: string;
    token: string;
};
