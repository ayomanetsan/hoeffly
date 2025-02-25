import { Injectable } from '@angular/core';
import {HttpService} from "../../shared/data-access/http.service";
import { GiftCreateRequest, GiftResponse, GiftUpdateRequest } from '../models/gift';

@Injectable({
  providedIn: 'root'
})
export class GiftService {
  constructor(private http: HttpService) { }

  get(id: string) {
    return this.http.get<GiftResponse>(`/gifts/${id}`);
  }

  create(gift: GiftCreateRequest) {
    return this.http.post<GiftCreateRequest>('/gifts', gift);
  }

  update(gift: GiftUpdateRequest) {
    return this.http.put<GiftUpdateRequest>(`/gifts`, gift);
  }

  delete(id: string) {
    return this.http.delete('/gifts', id);
  }
}
