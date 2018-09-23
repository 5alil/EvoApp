import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { EvoDto } from '../models/models';

@Injectable()
export class EvoServices {
  public baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getAllEvos(): any {
    return this.http.get<EvoDto[]>(this.baseUrl + 'api/Evo/GetEvos');
  }

  DeleteEvo(id: number): any {
    const params = new HttpParams().set('id', id.toString());
    return this.http.delete<EvoDto>(this.baseUrl + 'api/Evo/DeleteEvo/', { params });
  }

  InsertEvo(evo: EvoDto): any {
    return this.http.post<EvoDto>(this.baseUrl + 'api/Evo/AddEvo/', evo);
  }

}
