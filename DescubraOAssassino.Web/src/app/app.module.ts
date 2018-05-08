import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { DescubraComponent } from './descubra/descubra.component';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
import { JogoService } from './services/jogo.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    DescubraComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [JogoService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
