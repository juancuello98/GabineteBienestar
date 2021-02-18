import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormularioComponent } from './components/formulario/formulario.component';
import { HeaderComponent } from './components/header/header.component';
import { MatSliderModule } from '@angular/material/slider';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor} from './services/interceptors.service';
import {FormsModule} from '@angular/forms';
// import { provideRoutes } from '@angular/router';
// import { SolicitudService } from './services/solicitud.service';

@NgModule({
  declarations: [
    AppComponent,
    FormularioComponent,
    HeaderComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    MatSliderModule,
    MatSelectModule,
    MatInputModule,
    MatButtonModule,
    MatCheckboxModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  providers: [[{provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true}]
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
