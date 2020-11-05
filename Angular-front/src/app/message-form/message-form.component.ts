import { Component, OnInit } from '@angular/core';
import {Message} from '../message';
import {FormGroup, FormControl, Validator} from '@angular/forms';
import {HttpClient} from '@angular/common/http';
import { FormServiceService } from '../form-service.service';


@Component({
  selector: 'app-message-form',
  templateUrl: './message-form.component.html',
  styleUrls: ['./message-form.component.scss']
})
export class MessageFormComponent implements OnInit {
  //public message: Message;
  formShow:boolean;
  constructor(public svc: FormServiceService) { }
  resultForm=0;
 
  public formSubmited: boolean;

  ngOnInit(): void {
    this.formShow=this.svc.formShow;
    /*this.formSubmited=false;
    this.message={
      "mssgText":"",
      "mssgContact":1,
      "mssgTopic":1,
      "mssgTel":"",
      "mssgEmail":"",
      "mssgName":"",
      "mssgContactNavigation":null,
      "mssgTopicNavigation":null,
   }*/
  }
  
  public onSubmited(){
    this.formSubmited=true;
  }

  /*public postData(){
    
    let url = "/api/Mssgs";
    this.message.mssgTopic=Number(this.message.mssgTopic);
    console.log(typeof(this.message.mssgTopic));
    this.http.post(url,this.message
    ).toPromise().then((data:any)=>{
      console.log(data);
      this.resultForm=data;
    })
    this.formShow=false;
  }*/
}
