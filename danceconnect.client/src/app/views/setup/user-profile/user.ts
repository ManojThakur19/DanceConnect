export interface User {
  name: string;
  gender?: string;
  dob: Date;
  phone: string;
  profilePic?: File;
  identityDocument?: File;
  street: string;
  city?: string;
  province?: string;
  postalCode?: string;
}
