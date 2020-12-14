import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public products: Product[];
  public coins: Coin[];
  public baseUrl: string;
  public http: HttpClient;
  public message = "";
  public coin: number;
  public product: number;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'response-Type': 'application/json',
    }),
  };
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Product[]>(baseUrl + 'VendingMachine').subscribe(result => {
      this.products = result;
      console.log(this.products);
    }, error => console.error(error));
    this.baseUrl = baseUrl;
    this.http = http;
  }

  public addCoin() {
    this.http.post<Coin[]>(this.baseUrl + 'VendingMachine', this.coin, this.httpOptions).pipe()
      .subscribe(result => {
        this.message = 'Inserted Coins';
        this.coins = result;
        this.coin = null;
        console.log();
      }, error => this.message = error.error.error
      );
  }
  public buy() {
    this.http.post<Coin[]>(this.baseUrl + 'VendingMachine/buy', this.product, this.httpOptions).pipe()
      .subscribe(result => {
        this.message = 'Rest';
        this.product = null;
        this.coins = result;
      }, error => this.message = error.error.error
      );
  }
  public refund() {
    this.http.post<Coin[]>(this.baseUrl + 'VendingMachine/refund', null, this.httpOptions).pipe()
      .subscribe(result => {
        this.message = 'Returned Coins';
        this.coins = result;
      }, error => this.message = error.error.error
      );
  }
}

interface Product {
  name: string;
  price: number;
  index: number;
}
interface Coin {
  value: number;
}
