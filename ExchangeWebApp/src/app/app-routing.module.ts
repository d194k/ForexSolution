import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CurrencyConversionComponent } from './Components/currency-conversion/currency-conversion.component';
import { RateHistoryComponent } from './Components/rate-history/rate-history.component';

const routes: Routes = [
  {path: 'currency-exchange', component: CurrencyConversionComponent},
  {path: 'rate-change-history', component: RateHistoryComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
