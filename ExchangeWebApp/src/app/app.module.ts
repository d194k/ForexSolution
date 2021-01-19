import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";  

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CurrencyConversionComponent } from './Components/currency-conversion/currency-conversion.component';
import { RateHistoryComponent } from './Components/rate-history/rate-history.component';
import { AppHeaderComponent } from './Components/app-header/app-header.component';
import { MenubarModule } from 'primeng/menubar';
import { ChartModule  } from 'primeng/chart';

@NgModule({
  declarations: [
    AppComponent,
    CurrencyConversionComponent,
    RateHistoryComponent,
    AppHeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MenubarModule,
    FormsModule,
    HttpClientModule,
    ChartModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
