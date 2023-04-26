import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.css']
})
export class LoadingComponent implements OnInit {
  public readonly text = 'loading'.split('');
  public readonly lastindex = this.text.length - 1
  public readonly duration = 2;
  public readonly delay = (this.duration * 0.5) / this.lastindex;
  constructor() { }

  ngOnInit(): void {

  }

}
