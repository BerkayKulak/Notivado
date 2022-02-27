import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Model, Work, WorkAdd } from './Model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  baseUrl: string = 'https://localhost:44318/api/';
  model = new Model();

  constructor(private http: HttpClient) {}

  getProducts(): Observable<any> {
    const token = localStorage.getItem('accessToken');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + token,
    });
    console.log(this.http.get(this.baseUrl + 'Work', { headers: headers }));
    return this.http.get(this.baseUrl + 'Work', { headers: headers });
  }

  addProduct(product: WorkAdd): Observable<WorkAdd> {
    const token = localStorage.getItem('accessToken');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + token,
    });
    return this.http.post<WorkAdd>(this.baseUrl + 'work', product, {
      headers: headers,
    });
  }

  updateProduct(product: Work) {
    const token = localStorage.getItem('accessToken');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + token,
    });
    return this.http.put<Work>(this.baseUrl + 'work/' + product.id, product, {
      headers: headers,
    });
  }

  deleteProduct(product: Work): Observable<Work> {
    const token = localStorage.getItem('accessToken');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + token,
    });
    return this.http.delete<Work>(this.baseUrl + 'work/' + product.id, {
      headers: headers,
    });
  }

  getProductById(id: number) {
    return this.model.products.find((i) => i.id == id);
  }

  saveProduct(product: Work) {
    if (product.id == 0) {
      this.model.products.push(product);
    } else {
      const p = this.getProductById(product.id);
      p.name = product.name;
      p.id = product.id;
      p.id = product.id;
    }
  }
}
