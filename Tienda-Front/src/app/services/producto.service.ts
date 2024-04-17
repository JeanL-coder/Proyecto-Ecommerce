import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Producto } from '../models/Producto';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

private baseUrl: string = "https://localhost:7246/api/Product/";
  
  constructor(private http: HttpClient, private router : Router) { }

  registrarBusqueda(productId: number): Observable<void> {
    return this.http.post<void>(`${this.baseUrl}buscar`, { productId });
  }

  getProductosMasBuscados(): Observable<Producto[]> {
    return this.http.get<any[]>(`${this.baseUrl}mas-buscados`);
  }

  agregarProducto(proObj: any){
    return this.http.post<any>(`${this.baseUrl}agregar`, proObj);
  }
}
