import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule} from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MessageFormComponent } from './message-form/message-form.component';
import {HttpClientModule} from '@angular/common/http';
import { ResultComponent } from './result/result.component';
import { FormServiceService } from './form-service.service';
@NgModule({
  declarations: [
    AppComponent,
    MessageFormComponent,
    ResultComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [FormServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
