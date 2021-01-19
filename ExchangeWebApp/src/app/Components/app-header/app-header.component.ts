import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import {MenuItem} from 'primeng/api';   

@Component({
  selector: 'app-header',
  templateUrl: './app-header.component.html',
  styleUrls: ['./app-header.component.css']
})
export class AppHeaderComponent implements OnInit {

  public menu: MenuItem[]; 

  constructor(private router: Router) {     
  }

  ngOnInit(): void {
    this.buildMenu();
  }

  private buildMenu() {
    this.menu = [
      {label: 'Currency Exchange', command: () => this.routeToCurrencyExchange()},
      {label: 'Rate History', command: () => this.routeToRateHistory()}
    ];
  }

  private routeToCurrencyExchange() {
    this.router.navigate(['currency-exchange']);
  }

  private routeToRateHistory() {
    this.router.navigate(['rate-change-history']);
  }

}
