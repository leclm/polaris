import { CUSTOM_ELEMENTS_SCHEMA, DEFAULT_CURRENCY_CODE, LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './auth';
import { ClienteModule } from './cliente';
import { IConfig, NgxMaskModule } from 'ngx-mask';
import { CurrencyMaskConfig, CurrencyMaskModule, CURRENCY_MASK_CONFIG } from 'ng2-currency-mask';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
import { GerenteModule } from './gerente/gerente.module';
import { FormsModule } from '@angular/forms';

export const options: Partial<IConfig> | (() => Partial<IConfig>) = {};
export const CustomCurrencyMaskConfig: CurrencyMaskConfig = {
  align: "right",
  allowNegative: true,
  decimal: ",",
  precision: 2,
  prefix: "R$ ",
  suffix: "",
  thousands: "."
};

registerLocaleData(localePt, 'pt');

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    AuthModule,
    ClienteModule,
    NgxMaskModule.forRoot(),
    CurrencyMaskModule,
    GerenteModule,
    FormsModule
  ],
  providers: [
    { provide: CURRENCY_MASK_CONFIG, useValue: CURRENCY_MASK_CONFIG },
    {
      provide: LOCALE_ID,
      useValue: 'pt'
    },

    /* if you don't provide the currency symbol in the pipe, this is going to be the default symbol (R$) ... */
    {
      provide: DEFAULT_CURRENCY_CODE,
      useValue: 'BRL'
    },
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
