import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ImgBBResponse } from '../models/thirdPartyApi';

@Injectable({
  providedIn: 'root'
})
export class ImageService {

  constructor(private http: HttpClient) { }

  private apiUrl = 'https://api.imgbb.com/1/upload';
  private apiKey = '4da1b0901d3529915d0786b71a7abc02';

  uploadImage(image: File, fileName: string): Observable<ImgBBResponse> {
    const formData = new FormData();
    formData.append('key', this.apiKey);
    formData.append('image', image);
    formData.append('name', `${fileName} ${new Date().toISOString()}`);

    return this.http.post<ImgBBResponse>(this.apiUrl, formData);
  }

}
