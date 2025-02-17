import { Injectable } from '@angular/core';
import {HttpService} from "../../shared/data-access/http.service";
import {GiftCreateRequest, GiftUpdateRequest} from "../models/gift";

@Injectable({
  providedIn: 'root'
})
export class GiftService {
  constructor(private http: HttpService) { }

  create(gift: GiftCreateRequest) {
    return this.http.post<GiftCreateRequest>('/gifts', gift);
  }

  delete(id: string) {
    return this.http.delete('/gifts', id);
  }
}
