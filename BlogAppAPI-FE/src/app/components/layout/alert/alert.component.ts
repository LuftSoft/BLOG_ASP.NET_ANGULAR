import { Component, OnInit, OnChanges, OnDestroy, SimpleChanges } from '@angular/core';
import { DataService } from 'src/app/services/Data.service';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css']
})
export class AlertComponent implements OnInit, OnChanges, OnDestroy {

  constructor(public data: DataService) { }
  ngOnChanges(changes: SimpleChanges): void {
    if (this.data.message == '') this.ngOnDestroy()
    else this.ngOnInit()
  }
  ngOnDestroy(): void {

  }

  ngOnInit(): void {
  }




}
