import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DoctorDto } from '../_interfaces/user/doctorDto';
import { CategoryWithDoctorsCountDto } from '../_interfaces/user/categoryWithDoctorsCountDto';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { JwtService } from './jwt.service';
import { UserDto } from '../_interfaces/user/userDto';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient, private jwtService: JwtService) {}


  public getCategories(categoryName?: string) {
    const baseUrl = 'https://localhost:5001/api/Categories';
    const categoryNameParam = categoryName
      ? `?categoryName=${categoryName}`
      : '';
    const url = `${baseUrl}${categoryNameParam}`;
    return this.http.get<CategoryWithDoctorsCountDto[]>(url);
  }

  public getDoctors(limit: number, offset: number, categoryId: string | null, name: string | null) {
    const baseUrl = 'https://localhost:5001/api/Users/Doctors';
    const categoryIdParam = categoryId ? `&categoryId=${categoryId}` : '';
    const nameParam = name ? `&name=${name}` : '';
    const url = `${baseUrl}?limit=${limit}&offset=${offset}${categoryIdParam}${nameParam}`;
  
    return this.http.get<DoctorDto[]>(url);
  }
  

  public getDoctor(id: string | null) {
    return this.http.get<DoctorDto>(
      `https://localhost:5001/api/Users/Doctors/${id}`
    );
  }
}
