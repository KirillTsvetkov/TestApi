import { Component, OnInit } from '@angular/core';
import { FormServiceService } from '../form-service.service';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.scss']
})
export class ResultComponent implements OnInit {
  resultForm=0;
  
  constructor(public svc: FormServiceService) { }

  ngOnInit(): void {
    this.resultForm=this.svc.resultForm;
  }

}
