import { Injectable } from '@angular/core';
import { HttpService } from '../../shared/data-access/http.service';
import { UserResponse } from '../../friends/ui/users';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  constructor(private http: HttpService) { }

  getUserByEmail(email: string) {
    return this.http.get<UserResponse>(`/users?email=${email}`);
  }
}
