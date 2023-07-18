import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  items: any[] = [];
  
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<any[]>('./assets/Items.json').subscribe(items => {
      this.items = items;
    });
  }
}
