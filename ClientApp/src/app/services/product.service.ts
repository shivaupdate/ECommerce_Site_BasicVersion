import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { userSelectedQuantity } from '../product/models/userSelectedQuantity';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseurl: string;
  httpOptions:any;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseurl = baseUrl;
    // Http Headers
  this.httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
}
  public getProductlist(): Observable<any[]> {
    return this.http.get<any[]>(this.baseurl + 'Product');
  }

  public addtoCart(selectedProducts:userSelectedQuantity): Observable<any> {
 
    return this.http.post(this.baseurl +'Product/Product/AddOrUpdateCart', selectedProducts, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandl)
    )
}
 // Error handling
 errorHandl(error) {
  let errorMessage = '';
  if(error.error instanceof ErrorEvent) {
    // Get client-side error
    errorMessage = error.error.message;
  } else {
    // Get server-side error
    errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
  }
  console.log(errorMessage);
  return throwError(errorMessage);
} 
}