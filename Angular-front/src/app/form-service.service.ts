import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Message } from './message';


@Injectable({
  providedIn: 'root'
})
export class FormServiceService {
  public message: Message;
  formShow=true;
  public formSubmited: boolean;
  resultForm;
  constructor(private http:HttpClient) {
    this.formSubmited=false;
    this.message={
      "mssgText":"",
      "mssgContact":1,
      "mssgTopic":1,
      "mssgTel":"",
      "mssgEmail":"",
      "mssgName":"",
      "mssgContactNavigation":null,
      "mssgTopicNavigation":null,
   }
  }
  postData(){
    
    let url = "/api/Mssgs";
    this.message.mssgTopic=Number(this.message.mssgTopic);
    console.log(typeof(this.message.mssgTopic));
    this.http.post(url,this.message
    ).toPromise().then((data:any)=>{
      console.log(data);
      this.resultForm=data;
    })
    this.formShow=false;
    console.log(this.formShow);
  }
  
}
