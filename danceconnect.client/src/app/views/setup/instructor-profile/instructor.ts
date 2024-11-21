export interface Instructor {
  name: string;
  gender?: string;
  dob: Date;
  phone: string;
  profilePic?: File;
  identityDocument?: File;
  shortIntroVideo?: File;
  street: string;
  city?: string;
  province?: string;
  postalCode?: string;
}
